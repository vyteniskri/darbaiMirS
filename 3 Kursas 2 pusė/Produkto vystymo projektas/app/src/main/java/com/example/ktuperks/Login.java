package com.example.ktuperks;

import static android.content.ContentValues.TAG;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.android.material.textfield.TextInputEditText;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.SetOptions;
import com.google.firebase.messaging.FirebaseMessaging;

import java.util.Collections;

public class Login extends AppCompatActivity {
    TextInputEditText editTextEmail, editTextPassword;
    Button buttonLogin;
    FirebaseAuth mAuth;
    ProgressBar progressBar;
    TextView textView;
    FirebaseAuth auth = FirebaseAuth.getInstance();



    @Override
    public void onStart() {
        super.onStart();
        FirebaseUser currentUser = mAuth.getCurrentUser();

        if(currentUser != null && currentUser.isEmailVerified()){
            Intent intent = new Intent(getApplicationContext(), MainActivity.class);
            startActivity(intent);
            finish();
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        mAuth = FirebaseAuth.getInstance();
        editTextEmail = findViewById(R.id.email);
        editTextPassword = findViewById(R.id.password);
        buttonLogin = findViewById(R.id.btn_login);
        progressBar = findViewById(R.id.progressBar);
        textView = findViewById(R.id.registerNow);

        textView.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(), Register.class);
                startActivity(intent);
                finish();
            }
        });


        buttonLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                progressBar.setVisibility(View.VISIBLE);
                String email, password;
                email = String.valueOf(editTextEmail.getText());
                password = String.valueOf(editTextPassword.getText());

                if (TextUtils.isEmpty(email)) {
                    Toast.makeText(Login.this, "Enter email.", Toast.LENGTH_SHORT).show();
                    progressBar.setVisibility(View.GONE);
                    return;
                }

                if (TextUtils.isEmpty(password)) {
                    Toast.makeText(Login.this, "Enter password.", Toast.LENGTH_SHORT).show();
                    progressBar.setVisibility(View.GONE);
                    return;
                }

                mAuth.signInWithEmailAndPassword(email, password)
                        .addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                            @Override
                            public void onComplete(@NonNull Task<AuthResult> task) {
                                progressBar.setVisibility(View.GONE);


                                if (task.isSuccessful()) {
                                    FirebaseUser currentUser = mAuth.getCurrentUser();
                                    if (mAuth.getCurrentUser().isEmailVerified()) {

                                        FirebaseMessaging.getInstance().getToken().addOnCompleteListener(tokenTask -> {
                                            if (!tokenTask.isSuccessful()) {
                                                Log.w(TAG, "Fetching FCM registration token failed", tokenTask.getException());
                                                return;
                                            }

                                            // Get new FCM registration token
                                            String token = tokenTask.getResult();
                                            FirebaseFirestore db = FirebaseFirestore.getInstance();

                                            // Update the FCM token in Firestore under the user's reservation document
                                            db.collection("usersTokens").document(token)
                                                    .set(Collections.singletonMap("userId", currentUser.getUid()), SetOptions.merge())
                                                    .addOnSuccessListener(aVoid -> Log.d(TAG, "FCM token successfully updated!"))
                                                    .addOnFailureListener(e -> Log.w(TAG, "Error updating FCM token", e));

                                        });

                                        Toast.makeText(Login.this, "Login Successful", Toast.LENGTH_SHORT).show();
                                        Intent intent = new Intent(getApplicationContext(), Login.class);
                                        startActivity(intent);
                                        finish();
                                    } else {
                                        Toast.makeText(Login.this, "Please verify your email address.", Toast.LENGTH_SHORT).show();
                                    }


                                } else {
                                    // If sign in fails, display a message to the user.
                                    Toast.makeText(Login.this, "Authentication failed.",
                                            Toast.LENGTH_SHORT).show();
                                }
                            }
                        });

            }


        });
    }
}
