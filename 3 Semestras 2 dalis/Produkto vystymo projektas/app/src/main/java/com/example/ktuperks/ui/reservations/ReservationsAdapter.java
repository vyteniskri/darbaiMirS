package com.example.ktuperks.ui.reservations;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.example.ktuperks.R;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.FirebaseFirestore;

import java.util.List;

public class ReservationsAdapter extends ArrayAdapter<String> {

    private Context context;
    private List<String> reservations;
    private List<String> dateIds;
    private List<String> intervalIds;
    private FirebaseFirestore firestore;

    public ReservationsAdapter(Context context, List<String> reservations, List<String> dateIds, List<String> intervalIds) {
        super(context, 0, reservations);
        this.context = context;
        this.reservations = reservations;
        this.dateIds = dateIds;
        this.intervalIds = intervalIds;
        this.firestore = FirebaseFirestore.getInstance();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.list_item_reservation, parent, false);
        }

        TextView reservationTextView = convertView.findViewById(R.id.reservationTextView);
        String reservation = getItem(position);
        reservationTextView.setText(reservation);

        Button cancelButton = convertView.findViewById(R.id.cancelButton);
        cancelButton.setOnClickListener(v -> {
            // Get the reservation to cancel
            String dateId = dateIds.get(position);
            String intervalId = intervalIds.get(position);
            // Perform cancellation
            cancelReservation(dateId, intervalId, position);
        });

        return convertView;
    }

    private void cancelReservation(String dateId, String intervalId, int position) {
        FirebaseUser currentUser = FirebaseAuth.getInstance().getCurrentUser();
        if (currentUser != null) {
            firestore.collection("reservations")
                    .document(currentUser.getUid())
                    .collection("dates")
                    .document(dateId)
                    .collection("timeIntervals")
                    .document(intervalId)
                    .delete()
                    .addOnSuccessListener(aVoid -> {
                        // Reservation successfully canceled
                        Toast.makeText(context, "Reservation canceled", Toast.LENGTH_SHORT).show();
                        // Update UI: Remove canceled reservation from the list
                        reservations.remove(position);
                        dateIds.remove(position);
                        intervalIds.remove(position);
                        notifyDataSetChanged();
                    })
                    .addOnFailureListener(e -> {
                        // Failed to cancel reservation
                        Toast.makeText(context, "Failed to cancel reservation", Toast.LENGTH_SHORT).show();
                    });
        }
    }
}
