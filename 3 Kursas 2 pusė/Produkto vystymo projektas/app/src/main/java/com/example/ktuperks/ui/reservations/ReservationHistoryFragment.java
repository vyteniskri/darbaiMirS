package com.example.ktuperks.ui.reservations;

import android.os.Bundle;
import android.widget.ListView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.ktuperks.R;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class ReservationHistoryFragment extends AppCompatActivity {

    private FirebaseFirestore firestore;
    private FirebaseAuth firebaseAuth;
    private FirebaseUser currentUser;
    private ListView historyListView;
    private ReservationsHistoryAdapter historyAdapter;
    private List<String> historyList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fragment_reservation_history);

        historyListView = findViewById(R.id.pastReservationsListView);
        historyList = new ArrayList<>();
        historyAdapter = new ReservationsHistoryAdapter(this, historyList);
        historyListView.setAdapter(historyAdapter);

        firestore = FirebaseFirestore.getInstance();
        firebaseAuth = FirebaseAuth.getInstance();
        currentUser = firebaseAuth.getCurrentUser();

        if (currentUser != null) {
            loadReservationHistory(currentUser.getUid());
        } else {
            Toast.makeText(this, "User not logged in", Toast.LENGTH_SHORT).show();
        }

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

    }

    @Override
    public boolean onSupportNavigateUp() {
        // This method is called when the up button in the action bar is pressed.
        // Go back to the previous activity (in this case, the calendar activity)
        finish();
        return true;
    }

    private void loadReservationHistory(String userUid) {
        firestore.collection("reservations")
                .document(userUid)
                .collection("dates")
                .get()
                .addOnCompleteListener(task -> {
                    if (task.isSuccessful()) {
                        for (QueryDocumentSnapshot dateDocument : task.getResult()) {
                            String date = dateDocument.getId();
                            dateDocument.getReference()
                                    .collection("timeIntervals")
                                    .get()
                                    .addOnCompleteListener(intervalTask -> {
                                        if (intervalTask.isSuccessful()) {
                                            for (QueryDocumentSnapshot intervalDocument : intervalTask.getResult()) {
                                                String interval = intervalDocument.getString("selectedInterval");
                                                if (interval != null) {
                                                    String formattedDate = formatDateString(date);
                                                    if (isPastDate(date)) {
                                                        historyList.add(formattedDate + " " + interval);
                                                    }
                                                }
                                            }
                                            historyAdapter.notifyDataSetChanged();
                                        }
                                    });
                        }
                    } else {
                        Toast.makeText(this, "Failed to load reservation history", Toast.LENGTH_SHORT).show();
                    }
                });
    }

    private String formatDateString(String date) {
        if (date.length() == 8) {
            String year = date.substring(0, 4);
            String month = date.substring(4, 6);
            String day = date.substring(6, 8);
            return year + " " + month + " " + day;
        } else {
            return date;
        }
    }

    private boolean isPastDate(String date) {
        int year = Integer.parseInt(date.substring(0, 4));
        int month = Integer.parseInt(date.substring(4, 6));
        int day = Integer.parseInt(date.substring(6, 8));
        Calendar reservationDate = Calendar.getInstance();
        reservationDate.set(year, month - 1, day);
        return reservationDate.before(Calendar.getInstance());
    }
}
