package com.example.ktuperks.ui.detail;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import com.example.ktuperks.R;
import com.example.ktuperks.databinding.FragmentDetailBinding;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import java.util.ArrayList;

public class DetailFragment extends Fragment implements OnMapReadyCallback {

    private TextView textTitle;
    private TextView textInfo;
    private FragmentDetailBinding binding;
    private GoogleMap mMap;
    private SupportMapFragment mapFragment;

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        binding = FragmentDetailBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        textTitle = view.findViewById(R.id.text_title);
        textInfo = view.findViewById(R.id.text_info);
        mapFragment = (SupportMapFragment) getChildFragmentManager().findFragmentById(R.id.map);

        if (getArguments() != null) {
            String title = getArguments().getString("title");
            String info = getArguments().getString("information");

            if (info != null) {
                // Replace literal "\n \n" with actual new line characters
                info = info.replace("\\n", "\n");
            }

            textTitle.setText(title);
            textInfo.setText(info);

            ArrayList<Double> latitudes = (ArrayList<Double>) getArguments().getSerializable("latitudes");
            ArrayList<Double> longitudes = (ArrayList<Double>) getArguments().getSerializable("longitudes");

            if (latitudes != null && longitudes != null && !latitudes.isEmpty() && !longitudes.isEmpty()) {
                if (mapFragment != null) {
                    mapFragment.getMapAsync(this);
                }
            } else {
                if (mapFragment != null) {
                    getChildFragmentManager().beginTransaction().remove(mapFragment).commit();
                }
            }
        }

        return view;
    }

    @Override
    public void onMapReady(GoogleMap googleMap) {
        mMap = googleMap;
        if (getArguments() != null) {
            ArrayList<Double> latitudes = (ArrayList<Double>) getArguments().getSerializable("latitudes");
            ArrayList<Double> longitudes = (ArrayList<Double>) getArguments().getSerializable("longitudes");

            if (latitudes != null && longitudes != null && latitudes.size() == longitudes.size()) {
                for (int i = 0; i < latitudes.size(); i++) {
                    LatLng location = new LatLng(latitudes.get(i), longitudes.get(i));
                    mMap.addMarker(new MarkerOptions().position(location).title("Marker " + (i + 1)));
                }
                if (!latitudes.isEmpty() && !longitudes.isEmpty()) {
                    LatLng firstLocation = new LatLng(latitudes.get(0), longitudes.get(0));
                    mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(firstLocation, 15));
                }
            }
        }
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}