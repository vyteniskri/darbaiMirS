package com.example.ktuperks.ui.calendar;

import static androidx.constraintlayout.widget.ConstraintLayoutStates.TAG;

import android.content.Context;
import android.graphics.Color;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.ktuperks.R;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Set;

public class TimeIntervalsAdapter extends ArrayAdapter<String> {
    private Context context;
    private List<String> timeIntervals;
    private Map<String, Integer> remainingSpaceMap; // Map to store remaining space for each interval
    private FirebaseFirestore firestore;
    private String currentDate;

    private FirebaseAuth firebaseAuth;

    private FirebaseUser currentUser;

    private String userUid;
    private OnDataSetChangedListener dataSetChangedListener;

    private int NumberOfFreeSpace;
    Set<String> reservationsList;
    Set<String> notificationsList;
    public TimeIntervalsAdapter(Context context, List<String> timeIntervals, int year, int month, int dayOfMonth) {
        super(context, R.layout.list_item_time_interval, timeIntervals);
        this.context = context;
        this.timeIntervals = timeIntervals;
        this.remainingSpaceMap = new HashMap<>();
        this.NumberOfFreeSpace = 1;
        this.firestore = FirebaseFirestore.getInstance();

        Calendar calendar = Calendar.getInstance();
        calendar.set(year, month, dayOfMonth);
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyyMMdd", Locale.getDefault());
        this.currentDate = dateFormat.format(calendar.getTime());
        remainingSpaceMap.clear(); //Clear

        this.firebaseAuth = FirebaseAuth.getInstance();
        this.currentUser = firebaseAuth.getCurrentUser();
        this.userUid = currentUser.getUid();

        // Initialize remaining space for each interval
        for (String interval : timeIntervals) {
            remainingSpaceMap.put(interval, NumberOfFreeSpace); // Assuming initial remaining space is 30 for all intervals
        }

        // Query Firestore to get selected time intervals and update remaining space
        querySelectedTimeIntervals();
        reservationsList = isIntervalSelected("reservations");
        notificationsList = isIntervalSelected("notifications");
    }


    public void setOnDataSetChangedListener(OnDataSetChangedListener listener) {
        this.dataSetChangedListener = listener;
    }

    private void notifyDataSetUpdated() {
        if (dataSetChangedListener != null) {
            dataSetChangedListener.onDataSetChanged();
        }
    }

    // Interface for data set changed listener
    public interface OnDataSetChangedListener {
        void onDataSetChanged();
    }

    private void querySelectedTimeIntervals() {
        // Query all documents in the top-level collection
        firestore.collection("reservations")
                .get()
                .addOnCompleteListener(task -> {
                    if (task.isSuccessful()) {
                        boolean exsistDoc = false;
                        for (QueryDocumentSnapshot userDocument : task.getResult()) {
                            exsistDoc = true;
                            // For each user, query their documents
                            firestore.collection("reservations")
                                    .document(userDocument.getId()) // UserUid
                                    .collection("dates")
                                    .document(currentDate) // YearMonthDay
                                    .collection("timeIntervals")
                                    .get()
                                    .addOnCompleteListener(dayTask -> {
                                        if (dayTask.isSuccessful()) {
                                            for (QueryDocumentSnapshot intervalDocument : dayTask.getResult()) {
                                                // Get the selected interval from each document
                                                String selectedInterval = intervalDocument.getString("selectedInterval");
                                                if (selectedInterval != null && remainingSpaceMap.containsKey(selectedInterval)) {
                                                    // If the selected interval exists in our map, decrement its remaining space
                                                    int remainingSpace = remainingSpaceMap.get(selectedInterval);
                                                    if (remainingSpace > 0) {
                                                        remainingSpaceMap.put(selectedInterval, remainingSpace - 1);
                                                    }
                                                }
                                            }
                                            notifyDataSetChanged(); // Notify adapter of data change
                                            notifyDataSetUpdated();
                                        } else {
                                            // Handle the error
                                            Exception e = dayTask.getException();
                                            if (e != null) {
                                                Log.e(TAG, "Error accessing Firestore: " + e.getMessage());
                                            } else {
                                                Log.e(TAG, "Unknown error accessing Firestore.");
                                            }
                                        }
                                    });
                        }
                        if (!exsistDoc) {
                            notifyDataSetChanged();

                        }
                    } else {
                        // Handle the error
                        Exception e = task.getException();
                        if (e != null) {
                            Log.e(TAG, "Error accessing Firestore: " + e.getMessage());
                        } else {
                            Log.e(TAG, "Unknown error accessing Firestore.");
                        }
                    }
                });
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder holder;

        if (convertView == null) {
            convertView = LayoutInflater.from(context).inflate(R.layout.list_item_time_interval, parent, false);
            holder = new ViewHolder();
            holder.intervalTextView = convertView.findViewById(R.id.intervalTextView);
            holder.remainingSpaceTextView = convertView.findViewById(R.id.remainingSpaceTextView);
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        // Set the time interval text
        String interval = timeIntervals.get(position);
        holder.intervalTextView.setText(interval);
        int remainingSpace = remainingSpaceMap.get(interval);

        if (reservationsList.contains(interval)) {
            convertView.setBackgroundColor(Color.WHITE);
            holder.remainingSpaceTextView.setText("(Reservation set)");
            holder.remainingSpaceTextView.setTextColor(Color.GREEN);

        } else if (notificationsList.contains(interval)) {
            convertView.setBackgroundColor(Color.WHITE);
            holder.remainingSpaceTextView.setText("(Notifications set)");
            holder.remainingSpaceTextView.setTextColor(Color.CYAN);

        } else {
                convertView.setBackgroundColor(Color.WHITE); // Reset to default background color
            if (remainingSpace == 0) {
                holder.remainingSpaceTextView.setText("(No remaining space)");
                holder.remainingSpaceTextView.setTextColor(Color.RED);
            } else {
                holder.remainingSpaceTextView.setText("Remaining: " + remainingSpace);
                holder.remainingSpaceTextView.setTextColor(Color.BLACK);
            }
        }




        return convertView;
    }

    private Set<String> isIntervalSelected(String collectionName) {
        Set<String> selectedIntervals = new HashSet<>();
            firestore.collection(collectionName)
                    .get()
                    .addOnCompleteListener(task -> {
                        if (task.isSuccessful()) {
                            for (QueryDocumentSnapshot userDocument : task.getResult()) {
                                // For each user, query their documents
                                firestore.collection(collectionName)
                                        .document(userUid) // UserUid
                                        .collection("dates")
                                        .document(currentDate) // YearMonthDay
                                        .collection("timeIntervals")
                                        .get()
                                        .addOnCompleteListener(dayTask -> {
                                            if (dayTask.isSuccessful()) {
                                                for (QueryDocumentSnapshot intervalDocument : dayTask.getResult()) {
                                                    // Get the selected interval from each document
                                                    String selectedInterval = intervalDocument.getString("selectedInterval");
                                                    if (selectedInterval != null) {
                                                        selectedIntervals.add(selectedInterval);
                                                    }
                                                }
                                                notifyDataSetChanged(); // Notify adapter of data change
                                                notifyDataSetUpdated();
                                            } else {
                                                // Handle the error
                                                Exception e = dayTask.getException();
                                                if (e != null) {
                                                    Log.e(TAG, "Error accessing Firestore: " + e.getMessage());
                                                } else {
                                                    Log.e(TAG, "Unknown error accessing Firestore.");
                                                }
                                            }
                                        });
                            }
                        } else {
                            // Handle the error
                            Exception e = task.getException();
                            if (e != null) {
                                Log.e(TAG, "Error accessing Firestore: " + e.getMessage());
                            } else {
                                Log.e(TAG, "Unknown error accessing Firestore.");
                            }
                        }
                    });
            return selectedIntervals;
    }

    // ViewHolder class
    static class ViewHolder {
        TextView intervalTextView;
        TextView remainingSpaceTextView;
    }
}