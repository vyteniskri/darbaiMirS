package com.example.ktuperks.ui.calendar;

import static android.content.ContentValues.TAG;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.CalendarView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.example.ktuperks.R;
import com.example.ktuperks.databinding.CalendarFragmentBinding;
import com.example.ktuperks.ui.reservations.ReservationHistoryFragment;
import com.example.ktuperks.ui.reservations.UserReservationsFragment;
import com.google.android.gms.tasks.Task;
import com.google.android.gms.tasks.TaskCompletionSource;
import com.google.android.gms.tasks.Tasks;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.Query;
import com.google.firebase.firestore.QueryDocumentSnapshot;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.concurrent.atomic.AtomicInteger;

public class CalendarFragment extends Fragment {
    Context context;
    private CalendarFragmentBinding binding;
    //private Set<Integer> selectedPositionsForRezervation = new HashSet<>();
    private Map<Integer, String> selectedPositions = new HashMap<>();
    private FirebaseAuth firebaseAuth;
    private FirebaseFirestore firestore;
    private FirebaseUser currentUser;

    private int NumberOfFreeSpace;
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        binding = CalendarFragmentBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        this.firestore = FirebaseFirestore.getInstance();
        // Access the CalendarView and customize as needed
        CalendarView calendarView = binding.calendarView;

        firebaseAuth = FirebaseAuth.getInstance();
        currentUser = firebaseAuth.getCurrentUser();

        this.NumberOfFreeSpace = 1;
        // Get the instance of the calendar
        Calendar calendar = Calendar.getInstance();

        // Set the minimum date to today
        long today = calendar.getTimeInMillis();
        calendarView.setMinDate(today);

        // Calculate the remaining days in the week
        int daysInWeek = 7;
        int remainingDaysInWeek = daysInWeek - calendar.get(Calendar.DAY_OF_WEEK);

        // Calculate the number of days to add
        int daysToAdd = 7 + remainingDaysInWeek;

        // Set the maximum date to the calculated date
        calendar.add(Calendar.DAY_OF_YEAR, daysToAdd);
        long maxDate = calendar.getTimeInMillis();
        calendarView.setMaxDate(maxDate);

        calendarView.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            @Override
            public void onSelectedDayChange(@NonNull CalendarView view, int year, int month, int dayOfMonth) {
                // Show popup dialog with time options
                showTimeSelectionDialog(year, month, dayOfMonth);

            }
        });

        // Initialize and set up the viewReservationsButton
        Button viewReservationsButton = view.findViewById(R.id.viewReservationsButton);
        viewReservationsButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getActivity(), UserReservationsFragment.class);
                startActivity(intent);
            }
        });


        Button historyButton = view.findViewById(R.id.historyButton);
        historyButton.setOnClickListener(v -> {
            Intent intent = new Intent(getActivity(), ReservationHistoryFragment.class);
            startActivity(intent);
        });
    }

    private void showTimeSelectionDialog(int year, int month, int dayOfMonth) {
        selectedPositions.clear();

        String[] timeIntervals;
        Calendar calendar = Calendar.getInstance();
        calendar.set(year, month, dayOfMonth);
        int dayOfWeek = calendar.get(Calendar.DAY_OF_WEEK);

        if (dayOfWeek == Calendar.SATURDAY || dayOfWeek == Calendar.SUNDAY) {
            // No time selection for Saturday
            return;
        } else if (dayOfWeek == Calendar.FRIDAY) {
            timeIntervals = new String[]{
                    "09:00 - 10:30",
                    "11:00 - 12:30",
                    "13:00 - 14:30",
                    "15:00 - 16:30",
                    "16:45 - 17:45" // Special interval for Friday
            };
        } else {
            timeIntervals = new String[]{
                    "09:00 - 10:30",
                    "11:00 - 12:30",
                    "13:00 - 14:30",
                    "15:00 - 16:30",
                    "17:00 - 18:30",
                    "19:00 - 20:45"
            };
        }

        // Calculate the current time
        Calendar currentCalendar = Calendar.getInstance();
        long currentTimeHours = currentCalendar.getTimeInMillis();

        // Filter the time intervals based on the current time plus
        ArrayList<String> filteredIntervals = new ArrayList<>();
        for (String interval : timeIntervals) {
            String startTimeStr = interval.split(" - ")[1];
            try {
                SimpleDateFormat sdf = new SimpleDateFormat("HH:mm", Locale.getDefault());
                Date startTime = sdf.parse(startTimeStr);

                Calendar intervalCalendar = Calendar.getInstance();
                intervalCalendar.set(year, month, dayOfMonth, startTime.getHours(), startTime.getMinutes());
                long intervalStartTimeMillis = intervalCalendar.getTimeInMillis();

                if (intervalStartTimeMillis >= currentTimeHours) {
                    filteredIntervals.add(interval);
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        if (filteredIntervals.isEmpty()){
            Toast.makeText(requireContext(), "No more space left for reservations or notifications on this date.", Toast.LENGTH_SHORT).show();
            return;
        }

        // Create a dialog builder
        AlertDialog.Builder builder = new AlertDialog.Builder(requireContext());
        builder.setTitle("Select Time Interval");

        // Inflate custom layout for the dialog
        View dialogView = getLayoutInflater().inflate(R.layout.dialog_time_selection, null);
        builder.setView(dialogView);

        // Find the ListView in the custom layout
        ListView listView = dialogView.findViewById(R.id.listView);
        Button saveButton = dialogView.findViewById(R.id.saveButton);

        // Set the array adapter for the ListView
        TimeIntervalsAdapter adapter = new TimeIntervalsAdapter(requireContext(), filteredIntervals,year, month, dayOfMonth);
        //listView.setAdapter(adapter);
        adapter.setOnDataSetChangedListener(new TimeIntervalsAdapter.OnDataSetChangedListener() {
            @Override
            public void onDataSetChanged() {
                // This code will be executed after notifyDataSetChanged() finishes updating the adapter
                // For example, you can show the data here
                listView.setAdapter(adapter);
            }
        });

        // Set the item click listener
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                String selectedInterval = filteredIntervals.get(position);
                boolean cant = false;

                // Parse the start time of the selected interval
                String[] intervalParts = selectedInterval.split(" - ");
                String startTimeStr = intervalParts[0];
                try {
                    SimpleDateFormat sdf = new SimpleDateFormat("HH:mm", Locale.getDefault());
                    Date startTime = sdf.parse(startTimeStr);

                    // Calculate the time difference between the current time and the start time of the selected interval
                    Calendar currentTimeCalendar = Calendar.getInstance();
                    long currentTimeMillis = currentTimeCalendar.getTimeInMillis();
                    Calendar selectedIntervalCalendar = Calendar.getInstance();
                    selectedIntervalCalendar.set(year, month, dayOfMonth, startTime.getHours(), startTime.getMinutes());
                    long selectedIntervalMillis = selectedIntervalCalendar.getTimeInMillis();
                    long timeDifferenceMillis = selectedIntervalMillis - currentTimeMillis;

                    // Convert milliseconds to hours
                    long hoursDifference = timeDifferenceMillis / (60 * 60 * 1000);

                    // Check if less than 3 hours are left until the selected interval
                    if (hoursDifference < 3) {
                        cant = true;
                    }
                } catch (ParseException e) {
                    e.printStackTrace();
                }

                Drawable background = view.getBackground();
                TextView remainingSpaceTextView = view.findViewById(R.id.remainingSpaceTextView);
                String remainingSpaceText = remainingSpaceTextView.getText().toString();
                boolean noRemainingSpace = remainingSpaceText.contains("(No remaining space)");
                boolean setNotification = remainingSpaceText.contains("(Notifications set)");
                boolean setRezervation = remainingSpaceText.contains("(Reservation set)");

                if (selectedPositions.containsKey(position)) {

                        // If already selected, clear the selection
                        selectedPositions.remove(position);
                        view.setBackgroundColor(Color.TRANSPARENT);


                } else {
                    if (setRezervation) {
                        if (cant){
                            Toast.makeText(requireContext(), "You can't cancel this reservation.", Toast.LENGTH_SHORT).show();
                            return; // Exit without selecting the interval
                        }
                        view.setBackgroundColor(Color.RED);
                        selectedPositions.put(position, "rezervation");
                    } else if (setNotification) {
                        view.setBackgroundColor(Color.RED);
                        selectedPositions.put(position, "notification");
                    } else if (noRemainingSpace) {
                        view.setBackgroundColor(Color.YELLOW);
                        selectedPositions.put(position, "notification");
                    } else {
                        // If not selected, set the selection
                        selectedPositions.put(position, "rezervation");
                        view.setBackgroundColor(Color.GREEN);
                    }
                }



            }
        });
        AlertDialog dialog = builder.create();
        dialog.show();
        saveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Handle "Save" button click
                for (Map.Entry<Integer, String> entry : selectedPositions.entrySet()) {
                    Integer position = entry.getKey();

                    String value = entry.getValue();
                    // Now you can use 'position' and 'value' as needed
                    String selectedInterval = filteredIntervals.get(position);
                    saveSelectedTimeInterval(selectedInterval, value, year, month, dayOfMonth);
                    dialog.dismiss();
                }
            }
        });


    }

    private void saveSelectedTimeInterval(String selectedInterval, String value, int year, int month, int dayOfMonth) {
        String userUid = currentUser.getUid();

        // Get the Firestore instance
        FirebaseFirestore firestore = FirebaseFirestore.getInstance();
        CollectionReference selectedTimeIntervalsCollection;
        if (value == "rezervation"){
            selectedTimeIntervalsCollection = firestore.collection("reservations"); //1 Collection
        }
        else {
            selectedTimeIntervalsCollection = firestore.collection("notifications"); //1 Collection
        }


        // Reference to the document with user's UID
        DocumentReference userDocument = selectedTimeIntervalsCollection.document(userUid); //1 Document id
        Map<String, Object> dummyMap = new HashMap<>();
        userDocument.set(dummyMap);
        // Get the current date
        Calendar calendar = Calendar.getInstance();
        calendar.set(year, month, dayOfMonth);
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyyMMdd", Locale.getDefault());
        String currentDate = dateFormat.format(calendar.getTime());

        DocumentReference dateCollection = userDocument.collection("dates").document(currentDate);
        dateCollection.set(dummyMap);
        CollectionReference timeIntervalsCollection = dateCollection.collection("timeIntervals");
        Query query = timeIntervalsCollection.whereEqualTo("selectedInterval", selectedInterval);

        // Execute the query
        query.get().addOnCompleteListener(task -> {
            if (task.isSuccessful()) {
                boolean intervalExists = false;
                for (QueryDocumentSnapshot document : task.getResult()) {
                    // Check if the document contains the selected interval
                    if (document.getString("selectedInterval").equals(selectedInterval)) {
                        // If the interval exists, delete the document
                        timeIntervalsCollection.document(document.getId()).delete();
                        intervalExists = true;
                        Toast.makeText(requireContext(), "Choice has been saved.", Toast.LENGTH_SHORT).show();
                        //Send notifications
                        if (value == "rezervation"){

                            Intent serviceIntent = new Intent(requireContext(), FirestoreReservationService.class);
                            serviceIntent.putExtra("yearMonthDay", currentDate);
                            serviceIntent.putExtra("timeInterval", selectedInterval);
                            requireContext().startService(serviceIntent);

                        }
                    }
                }

                // If the interval didn't exist previously, add it
                if (!intervalExists) {
                    final AtomicInteger count = new AtomicInteger(NumberOfFreeSpace); // or the actual count you expect
                    AtomicBoolean registrationFailed = new AtomicBoolean(false);
                    TaskCompletionSource<Void> overallTaskSource = new TaskCompletionSource<>();
                    Task<Void> overallTask = overallTaskSource.getTask();
                    //Tikrinama ar tuo paciu metu registracija besirenkantys user'iai gali tai padaryti (ar dar liko vietos registracijai)
                    firestore.collection("reservations")
                            .get()
                            .addOnCompleteListener(t -> {
                                if (t.isSuccessful()) {
                                    List<Task<?>> tasks = new ArrayList<>();
                                    for (QueryDocumentSnapshot doc : t.getResult()) {
                                        if (registrationFailed.get()) {
                                            overallTaskSource.trySetResult(null); // Stop processing if registration failed
                                            return;
                                        }
                                        // For each user, query their documents
                                        Task<Void> userTask = firestore.collection("reservations")
                                                .document(doc.getId()) // UserUid
                                                .collection("dates")
                                                .document(currentDate) // YearMonthDay
                                                .collection("timeIntervals")
                                                .get()
                                                .continueWith(task1 -> {
                                                    if (task1.isSuccessful()) {
                                                        for (QueryDocumentSnapshot intervalDocument : task1.getResult()) {
                                                            // Get the selected interval from each document
                                                            String interval = intervalDocument.getString("selectedInterval");
                                                            if ((interval != null) && interval.equals(selectedInterval) && !registrationFailed.get()) {
                                                                // If the selected interval exists in our map, decrement its remaining space

                                                                count.getAndDecrement();

                                                                if (count.get() == 0) {
                                                                    registrationFailed.set(true);
                                                                    if (value != "notification"){
                                                                        Toast.makeText(requireContext(), "Something went wrong. Please try again", Toast.LENGTH_SHORT).show();
                                                                    }
                                                                    overallTaskSource.trySetResult(null); // End the overall process
                                                                    return null;
                                                                }
                                                            }
                                                        }
                                                    } else {
                                                        // Handle the error
                                                        Exception e = task1.getException();
                                                        if (e != null) {
                                                            Log.e(TAG, "Error accessing Firestore: " + e.getMessage());
                                                        } else {
                                                            Log.e(TAG, "Unknown error accessing Firestore.");
                                                        }
                                                        registrationFailed.set(true);
                                                        Toast.makeText(requireContext(), "Something went wrong. Please try again", Toast.LENGTH_SHORT).show();
                                                        overallTaskSource.trySetResult(null); // End the overall process
                                                    }
                                                    return null;
                                                });
                                        tasks.add(userTask);
                                    }
                                    Tasks.whenAllComplete(tasks).addOnCompleteListener(listTask -> overallTaskSource.trySetResult(null));
                                } else {
                                    // Handle the error
                                    Exception e = t.getException();
                                    if (e != null) {
                                        Log.e(TAG, "Error accessing Firestore: " + e.getMessage());
                                    } else {
                                        Log.e(TAG, "Unknown error accessing Firestore.");
                                    }
                                    registrationFailed.set(true);
                                    Toast.makeText(requireContext(), "Something went wrong. Please try again", Toast.LENGTH_SHORT).show();
                                    overallTaskSource.trySetResult(null); // End the overall process
                                }
                            });

                    // Wait for all Firestore operations to complete
                    overallTask.addOnCompleteListener(overallTaskListener -> {
                        if (!registrationFailed.get() || value == "notification") {
                            Toast.makeText(requireContext(), "Choice has been saved.", Toast.LENGTH_SHORT).show();
                            addNewInterval(selectedInterval, timeIntervalsCollection);
                        }
                    });
                }

            }
        });
    }

    private void addNewInterval(String selectedInterval, CollectionReference dayDocument) {
        // Create a map with the selected interval
        Map<String, Object> data = new HashMap<>();
        data.put("selectedInterval", selectedInterval);
        dayDocument.add(data);
    }
}
