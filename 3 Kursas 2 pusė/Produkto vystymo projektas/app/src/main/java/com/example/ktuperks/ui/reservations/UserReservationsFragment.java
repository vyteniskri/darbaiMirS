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

public class UserReservationsFragment extends AppCompatActivity {

    private FirebaseFirestore firestore;
    private FirebaseAuth firebaseAuth;
    private FirebaseUser currentUser;
    private ListView upcomingReservationsListView;
    private ReservationsAdapter upcomingAdapter;
    private List<String> upcomingReservationsList;
    private List<String> upcomingDateIds;
    private List<String> upcomingIntervalIds;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fragment_user_reservations);

        upcomingReservationsListView = findViewById(R.id.upcomingReservationsListView);
        upcomingReservationsList = new ArrayList<>();
        upcomingDateIds = new ArrayList<>();
        upcomingIntervalIds = new ArrayList<>();

        upcomingAdapter = new ReservationsAdapter(this, upcomingReservationsList, upcomingDateIds, upcomingIntervalIds);
        upcomingReservationsListView.setAdapter(upcomingAdapter);

        firestore = FirebaseFirestore.getInstance();
        firebaseAuth = FirebaseAuth.getInstance();
        currentUser = firebaseAuth.getCurrentUser();

        if (currentUser != null) {
            loadUserReservations(currentUser.getUid());
        } else {
            Toast.makeText(this, "User not logged in", Toast.LENGTH_SHORT).show();
        }

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    @Override
    public boolean onSupportNavigateUp() {
        finish();
        return true;
    }

    private void loadUserReservations(String userUid) {
        firestore.collection("reservations")
                .document(userUid)
                .collection("dates")
                .get()
                .addOnCompleteListener(task -> {
                    if (task.isSuccessful()) {
                        Calendar now = Calendar.getInstance();
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
                                                    if (!isPastDate(date)) {
                                                        upcomingReservationsList.add(formattedDate + " " + interval);
                                                        upcomingDateIds.add(date);
                                                        upcomingIntervalIds.add(intervalDocument.getId());
                                                    }
                                                }
                                            }
                                            upcomingAdapter.notifyDataSetChanged();
                                        }
                                    });
                        }
                    } else {
                        Toast.makeText(this, "Failed to load reservations", Toast.LENGTH_SHORT).show();
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
