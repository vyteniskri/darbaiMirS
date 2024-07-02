package com.example.ktuperks.ui.perks;

import android.graphics.Typeface;
import android.os.Bundle;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.GridLayout;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;

import com.example.ktuperks.Perk;
import com.example.ktuperks.R;
import com.example.ktuperks.databinding.FragmentPerksBinding;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.GeoPoint;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class PerksFragment extends Fragment {

    private FragmentPerksBinding binding;

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        PerksViewModel perksViewModel =
                new ViewModelProvider(this).get(PerksViewModel.class);

        binding = FragmentPerksBinding.inflate(inflater, container, false);
        View root = binding.getRoot();

        final TextView textView = binding.textPerksTitle;
        perksViewModel.getTitle().observe(getViewLifecycleOwner(), textView::setText);

        FirebaseFirestore db = FirebaseFirestore.getInstance();
        GridLayout buttonContainer = root.findViewById(R.id.button_container);

        db.collection("/perks").get().addOnCompleteListener(task -> {
            if (task.isSuccessful()) {
                int index = 0;
                for (DocumentSnapshot document : task.getResult().getDocuments()) {
                    Perk perk = document.toObject(Perk.class);
                    assert perk != null;
                    Log.d("Firestore", "Fetched Perk: " + perk.getTitle());
                    if (perk.getLocation() != null) {
                        for (GeoPoint geoPoint : perk.getLocation()) {
                            Log.d("Firestore", "Location: " + geoPoint.getLatitude() + ", " + geoPoint.getLongitude());
                        }
                    } else {
                        Log.d("Firestore", "No locations found for perk: " + perk.getTitle());
                    }

                    // Determine the background color using index and pattern logic
                    boolean color = (index % 4 == 1 || index % 4 == 2);

                    FrameLayout button = getButton(perk, color);
                    buttonContainer.addView(button);

                    // Increment the index for the next perk
                    index++;
                }
            } else {
                Log.d("Firestore", "Error getting documents: ", task.getException());
            }
        });

        return root;
    }

    @NonNull
    private FrameLayout getButton(Perk perk, boolean color) {
        // Create the FrameLayout to hold everything
        FrameLayout frameLayout = new FrameLayout(getContext());
        GridLayout.LayoutParams params = new GridLayout.LayoutParams(
                GridLayout.spec(GridLayout.UNDEFINED, 1f),
                GridLayout.spec(GridLayout.UNDEFINED, 1f));
        params.width = 0;  // Use 0 for width for equal distribution
        params.height = GridLayout.LayoutParams.WRAP_CONTENT;

        // Set margins (adjust the values as needed)
        params.setMargins(50, 25, 50, 25);
        frameLayout.setLayoutParams(params);

        // Create a LinearLayout to hold the ImageView and TextView
        LinearLayout layout = new LinearLayout(getContext());
        layout.setOrientation(LinearLayout.VERTICAL);
        layout.setGravity(Gravity.CENTER);
        layout.setBackgroundResource(color ? R.drawable.rounded_button_even : R.drawable.rounded_button_odd);

        // Create an ImageView to hold the image
        ImageView imageView = new ImageView(getContext());
        LinearLayout.LayoutParams imageParams = new LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.WRAP_CONTENT,
                LinearLayout.LayoutParams.WRAP_CONTENT);
        imageView.setLayoutParams(imageParams);

        // Create a TextView to hold the text
        TextView textView = new TextView(getContext());
        textView.setGravity(Gravity.CENTER);
        textView.setTypeface(null, Typeface.BOLD);
        textView.setTextSize(18);

        // Use Picasso to load the image if it exists, otherwise set the text
        if (perk.getImageUrl() != null && !perk.getImageUrl().isEmpty()) {
            imageParams.setMargins(0, 25, 0, 25);  // Add top and bottom margins to the ImageView
            Picasso.get().load(perk.getImageUrl()).into(imageView);
            textView.setText("");  // Clear text if image is present
        } else {
            textView.setText(perk.getTitle());
        }

        // Add the ImageView and TextView to the LinearLayout
        layout.addView(imageView);
        layout.addView(textView);

        // Add the LinearLayout to the FrameLayout
        frameLayout.addView(layout);

        // Create a transparent Button overlay to capture click events
        Button button = new Button(getContext());
        button.setBackground(null);  // Make the button background transparent
        FrameLayout.LayoutParams buttonParams = new FrameLayout.LayoutParams(
                FrameLayout.LayoutParams.MATCH_PARENT,
                FrameLayout.LayoutParams.MATCH_PARENT);
        button.setLayoutParams(buttonParams);

        button.setOnClickListener(v -> {
            navigateToDetailFragment(perk);
        });

        // Add the Button to the FrameLayout
        frameLayout.addView(button);

        // Post a runnable to set the aspect ratio after the layout pass
        frameLayout.post(() -> {
            int width = frameLayout.getWidth();
            if (width > 0) {
                ViewGroup.LayoutParams layoutParams = frameLayout.getLayoutParams();
                layoutParams.height = (int) (width * 2.0 / 3.0);
                frameLayout.setLayoutParams(layoutParams);
            }
        });

        return frameLayout;
    }

    private void navigateToDetailFragment(Perk perk) {
        Log.d("Navigation", "Attempting to navigate to DetailFragment");
        Bundle bundle = new Bundle();
        bundle.putString("title", perk.getTitle());
        bundle.putString("information", perk.getInformation());

        // Check if locations is null or empty
        if (perk.getLocation() != null && !perk.getLocation().isEmpty()) {
            ArrayList<Double> latitudes = new ArrayList<>();
            ArrayList<Double> longitudes = new ArrayList<>();
            for (GeoPoint geoPoint : perk.getLocation()) {
                latitudes.add(geoPoint.getLatitude());
                longitudes.add(geoPoint.getLongitude());
            }
            bundle.putSerializable("latitudes", latitudes);
            bundle.putSerializable("longitudes", longitudes);
        } else {
            Log.d("Navigation", "No locations to navigate");
        }

        try {
            // Use NavController to navigate
            NavController navController = Navigation.findNavController(getActivity(), R.id.nav_host_fragment_content_main);
            navController.navigate(R.id.action_nav_perks_to_detailFragment, bundle);
            Log.d("Navigation", "Navigation should be completed");
        } catch (Exception e) {
            Log.e("NavigationError", "Failed to navigate", e);
        }
    }
}