package com.example.ktuperks;

import android.content.Intent;
import android.os.Bundle;
import android.text.InputType;
import android.text.TextUtils;
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

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Register extends AppCompatActivity {

    TextInputEditText editTextEmail, editTextPassword, editTextConfirmPassword;
    Button buttonReg, buttonShow;
    FirebaseAuth mAuth;
    ProgressBar progressBar;
    TextView textView;
    boolean isPasswordVisible = false;

    private static final String EMAIL_PATTERN = "^[a-zA-Z0-9]+\\.[a-zA-Z0-9]+@ktu\\.lt";


    public static boolean isValidEmail(String email) {
        Pattern pattern = Pattern.compile(EMAIL_PATTERN);
        Matcher matcher = pattern.matcher(email);
        return matcher.matches();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        mAuth = FirebaseAuth.getInstance();
        editTextEmail = findViewById(R.id.email);
        editTextPassword = findViewById(R.id.password);
        editTextConfirmPassword = findViewById(R.id.confirmPassword);
        buttonReg = findViewById(R.id.btn_register);
        progressBar = findViewById(R.id.progressBar);
        textView = findViewById(R.id.loginNow);
        buttonShow = findViewById(R.id.btn_show);

        textView.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(), Login.class);
                startActivity(intent);
                finish();
            }
        });



        buttonShow.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isPasswordVisible) {
                    // Show the password
                    editTextPassword.setInputType(InputType.TYPE_TEXT_VARIATION_VISIBLE_PASSWORD);
                    editTextPassword.setTransformationMethod(null); // Clear transformation method to show plain text
                    buttonShow.setText("Hide");
                } else {
                    // Hide the password
                    editTextPassword.setInputType(InputType.TYPE_TEXT_VARIATION_PASSWORD);
                    editTextPassword.setTransformationMethod(android.text.method.PasswordTransformationMethod.getInstance()); // Mask the password
                    buttonShow.setText("Show");
                }

                isPasswordVisible = !isPasswordVisible; // Toggle the visibility state

                // Move cursor to the end of the text
                editTextPassword.setSelection(editTextPassword.getText().length());

                // Request focus again to force the EditText to refresh its appearance
                editTextPassword.requestFocus();
            }
        });


        buttonReg.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view){
                progressBar.setVisibility(View.VISIBLE);
                String email, password, confirmPassword;
                email = String.valueOf(editTextEmail.getText());
                password = String.valueOf(editTextPassword.getText());
                confirmPassword = String.valueOf(editTextConfirmPassword.getText());

                if (TextUtils.isEmpty(email)){
                    Toast.makeText(Register.this, "Enter email.", Toast.LENGTH_SHORT).show();
                    progressBar.setVisibility(View.GONE);
                    return;
                }

                if (TextUtils.isEmpty(password)){
                    Toast.makeText(Register.this, "Enter password.", Toast.LENGTH_SHORT).show();
                    progressBar.setVisibility(View.GONE);
                    return;
                }

                if (password.length() < 6) {
                    Toast.makeText(Register.this, "Password needs to be at least 6 characters long.", Toast.LENGTH_SHORT).show();
                    progressBar.setVisibility(View.GONE);
                    return;
                }

                if (!password.equals(confirmPassword)){
                    Toast.makeText(Register.this, "Passwords don't match.", Toast.LENGTH_SHORT).show();
                    progressBar.setVisibility(View.GONE);
                    return;
                }
                //Tikrina su regex, kad prisidet savo accounta reikia uzkomentuoti!
                if (!isValidEmail(email)) {
                    Toast.makeText(Register.this, "This email address is not valid for registration.", Toast.LENGTH_SHORT).show();
                    progressBar.setVisibility(View.GONE);
                    return;
                }

                mAuth.createUserWithEmailAndPassword(email, password)
                        .addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                            @Override
                            public void onComplete(@NonNull Task<AuthResult> task) {
                                progressBar.setVisibility((View.GONE));
                                if (task.isSuccessful()) {
                                    mAuth.getCurrentUser().sendEmailVerification().addOnCompleteListener(new OnCompleteListener<Void>() {
                                        @Override
                                        public void onComplete(@NonNull Task<Void> task) {
                                            if (task.isSuccessful()){
                                                Toast.makeText(Register.this, "Account created. Please verify your email address.", Toast.LENGTH_SHORT).show();
                                                Intent intent = new Intent(getApplicationContext(), Login.class);
                                                startActivity(intent);
                                                finish();
                                            } else {

                                                Toast.makeText(Register.this, task.getException().getMessage(), Toast.LENGTH_SHORT).show();
                                            }
                                        }
                                    });
                                } else {
                                    // If sign in fails, display a message to the user.
                                    Toast.makeText(Register.this, "Authentication failed.",
                                            Toast.LENGTH_SHORT).show();
                                }
                            }
                        });
            }
        });
    }
}