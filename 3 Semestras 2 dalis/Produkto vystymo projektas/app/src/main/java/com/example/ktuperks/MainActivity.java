package com.example.ktuperks;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

import com.example.ktuperks.databinding.ActivityMainBinding;
import com.google.android.material.navigation.NavigationView;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.messaging.FirebaseMessaging;

import java.util.HashMap;
import java.util.Map;

public class MainActivity extends AppCompatActivity {

    private FirebaseFirestore firestore;
    private FirebaseUser currentUser;
    private AppBarConfiguration mAppBarConfiguration;
    private ActivityMainBinding binding;
    private FirebaseAuth auth;
    private FirebaseUser user;
    private TextView textView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        this.firestore = FirebaseFirestore.getInstance();
        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        auth = FirebaseAuth.getInstance();
        user = auth.getCurrentUser();

        setSupportActionBar(binding.appBarMain.toolbar);

        DrawerLayout drawer = binding.drawerLayout;
        NavigationView navigationView = binding.navView;

        // Passing each menu ID as a set of Ids because each
        // menu should be considered as top level destinations.
        mAppBarConfiguration = new AppBarConfiguration.Builder(
                R.id.nav_home, R.id.nav_perks, R.id.nav_calendar, R.id.nav_mindletic, R.id.nav_logout)
                .setOpenableLayout(drawer)
                .build();
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_main);
        NavigationUI.setupActionBarWithNavController(this, navController, mAppBarConfiguration);
        NavigationUI.setupWithNavController(navigationView, navController);

        // Map of destination IDs to titles
        Map<Integer, String> destinationTitles = new HashMap<>();
        destinationTitles.put(R.id.nav_home, "Home");
        destinationTitles.put(R.id.nav_perks, "Benefits");
        //destinationTitles.put(R.id.nav_calendar, "registratED");
        destinationTitles.put(R.id.nav_mindletic, "Mindletic");
        destinationTitles.put(R.id.nav_logout, "Logout");

        // Set up listener for destination changes
        navController.addOnDestinationChangedListener((controller, destination, arguments) -> {
            if (destinationTitles.containsKey(destination.getId())) {
                getSupportActionBar().setTitle(destinationTitles.get(destination.getId()));
            }
        });

        if (user == null){
            Intent intent = new Intent(getApplicationContext(), Login.class);
            startActivity(intent);
            finish();
        }
        else {
            textView = findViewById(R.id.user_details);
            textView.setText(user.getEmail());
        }

        navigationView.setNavigationItemSelectedListener(new NavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                if (item.getItemId() == R.id.nav_logout) {
                    logout();
                    return true;
                } else {
                    NavigationUI.onNavDestinationSelected(item, navController);
                    drawer.closeDrawer(GravityCompat.START);
                    return true;
                }
            }
        });
    }

    private void logout() {
        FirebaseMessaging.getInstance().getToken().addOnCompleteListener(task -> {

            // Get new FCM registration token
            String currentToken = task.getResult();

            // Remove the token from Firestore
            firestore.collection("usersTokens")
                    .get()
                    .addOnCompleteListener(t -> {
                        if (t.isSuccessful()) {
                            for (QueryDocumentSnapshot d : t.getResult()) {
                                if (d.getId().equals(currentToken)) {
                                    firestore.collection("usersTokens").document(d.getId()).delete();
                                }
                            }
                        }
                    });

            // Sign out the user
            auth.signOut();

            // Redirect to the login activity
            Intent intent = new Intent(getApplicationContext(), Login.class);
            startActivity(intent);

            // Finish the current activity
            finish();
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onSupportNavigateUp() {
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_main);
        return NavigationUI.navigateUp(navController, mAppBarConfiguration)
                || super.onSupportNavigateUp();
    }
}