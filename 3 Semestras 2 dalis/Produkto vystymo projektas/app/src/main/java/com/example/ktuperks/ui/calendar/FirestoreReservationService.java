package com.example.ktuperks.ui.calendar;

import android.app.Service;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.IBinder;
import android.util.Log;

import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;

import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;
import java.util.UUID;

import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;

public class FirestoreReservationService extends Service {

    private FirebaseFirestore firestore;
    private static final String TAG = "FirestoreReservationService";
    private static final String FCM_URL = "https://fcm.googleapis.com/fcm/send";
    private static final String SERVER_KEY = "AAAAt3724dc:APA91bFOVlqGPq30J4IaWhCQWL8-Tp45xR9RLJNLxfLUxVa8xfNIp8kKkrYtnKKeIG8Lm54lEPvDh0LylfWFNBhMnR_4yireGCXEPU4XEBgD3kkJ9KOWnFPS2a-L5lSU0HMGoP4kaXiK"; // Replace with your actual server key
    @Override
    public IBinder onBind(Intent intent) {
        // This method is required when extending Service class, but it can remain unimplemented if not needed
        return null;
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        firestore = FirebaseFirestore.getInstance();
        String yearMonthDay = intent.getStringExtra("yearMonthDay");
        String timeInterval = intent.getStringExtra("timeInterval");

        if (yearMonthDay != null && timeInterval != null) {
            compareWithNotifications(yearMonthDay, timeInterval);
        }

        // If we get killed, after returning from here, restart
        return START_STICKY;
    }

    private void compareWithNotifications(String yearMonthDay, String timeInterval) {
        firestore.collection("notifications")
                .get()
                .addOnCompleteListener(task -> {
                    if (task.isSuccessful()) {
                        for (QueryDocumentSnapshot document : task.getResult()) {
                            String currentUserID = document.getId();
                            firestore.collection("notifications")
                                    .document(currentUserID) // UserUid
                                    .collection("dates")
                                    .document(yearMonthDay) // YearMonthDay
                                    .collection("timeIntervals")
                                    .get()
                                    .addOnCompleteListener(intervalTask -> {
                                        if (intervalTask.isSuccessful()) {
                                            for (QueryDocumentSnapshot doc : intervalTask.getResult()) {
                                                String notificationSelectedInterval = doc.getString("selectedInterval");
                                                if (timeInterval.equals(notificationSelectedInterval)) {
                                                    firestore.collection("usersTokens")
                                                            .get()
                                                            .addOnCompleteListener(t ->{
                                                                if (t.isSuccessful()) {
                                                                    for (QueryDocumentSnapshot d : t.getResult()) {
                                                                        String currentUserId = d.getString("userId");
                                                                        if (currentUserId.equals(currentUserID)){

                                                                            String userToken = d.getId();
                                                                            new NotificationTask().execute(userToken, notificationSelectedInterval, yearMonthDay);
                                                                            doc.getReference().delete();
                                                                        }
                                                                    }
                                                                }
                                                            });

                                                }
                                            }
                                        }
                                    });
                        }
                    } else {
                        Log.e(TAG, "Error getting documents: ", task.getException());
                    }
                });
    }

    private static class NotificationTask extends AsyncTask<String, Void, Void> {

        @Override
        protected Void doInBackground(String... strings) {
            String userToken = strings[0];
            String selectedInterval = strings[1];
            String yearMonthDay = strings[2];

            SimpleDateFormat inputFormat = new SimpleDateFormat("yyyyMMdd", Locale.getDefault());
            Date date = null;
            try {
                date = inputFormat.parse(yearMonthDay);
            } catch (ParseException e) {
                throw new RuntimeException(e);
            }
            SimpleDateFormat outputFormat = new SimpleDateFormat("yyyy-MM-dd", Locale.getDefault());
            String formattedDate = outputFormat.format(date);

            OkHttpClient client = new OkHttpClient();
            String messageId = UUID.randomUUID().toString();

            String jsonPayload = "{"
                    + "\"to\":\"" + userToken + "\","
                    + "\"data\":{"
                    + "\"title\":\"Reservation Available \","
                    + "\"body\":\"" + formattedDate + ", at: " + selectedInterval + "\""
                    + "}"
                    + "}";

            RequestBody body = RequestBody.create(
                    jsonPayload,
                    MediaType.get("application/json; charset=utf-8")
            );

            Request request = new Request.Builder()
                    .url(FCM_URL)
                    .post(body)
                    .addHeader("Authorization", "key=" + SERVER_KEY)
                    .addHeader("Content-Type", "application/json")
                    .build();

            try {
                Response response = client.newCall(request).execute();
                if (response.isSuccessful()) {
                    Log.d(TAG, "Successfully sent message to user: " + userToken);
                } else {
                    Log.e(TAG, "Error sending message 1: " + response.message() + "\nResponse body: " + response.body().string());
                }
            } catch (IOException e) {
                Log.e(TAG, "Error sending message: " + e.getMessage(), e);
            }

            return null;
        }
    }


}