package com.example.ktuperks.ui.mindletic;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import com.example.ktuperks.R;

public class MindleticFragment extends Fragment {

    private MindleticViewModel mindleticViewModel;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        mindleticViewModel = new ViewModelProvider(this).get(MindleticViewModel.class);
        View root = inflater.inflate(R.layout.fragment_mindletic, container, false);
        final TextView textView = root.findViewById(R.id.text_mindletic);
        mindleticViewModel.getText().observe(getViewLifecycleOwner(), textView::setText);

        final TextView firststepsTextView = root.findViewById(R.id.first_step);
        firststepsTextView.setText(getString(R.string.first_step));

        Button linkButton = root.findViewById(R.id.button_link);
        linkButton.setOnClickListener(v -> {
            Intent browserIntent = new Intent(Intent.ACTION_VIEW, Uri.parse("https://be.mindletic.com/BEcHiE"));
            startActivity(browserIntent);
        });

        final TextView stepsTextView = root.findViewById(R.id.text_steps);
        stepsTextView.setText(getString(R.string.mindletic_steps));



        return root;
    }
}