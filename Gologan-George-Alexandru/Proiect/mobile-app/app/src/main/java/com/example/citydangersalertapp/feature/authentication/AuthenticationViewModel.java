package com.example.citydangersalertapp.feature.authentication;

import android.app.Activity;
import android.content.Intent;

import androidx.annotation.NonNull;
import androidx.lifecycle.ViewModel;

import com.example.citydangersalertapp.HomeActivity;

public class AuthenticationViewModel extends ViewModel {
    public void onLogInButtonClickHandler(@NonNull Activity currentActivity) {
        currentActivity.finish();
        currentActivity.startActivity(new Intent(currentActivity, HomeActivity.class));
    }
}