package com.example.ktuperks.ui.home;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class HomeViewModel extends ViewModel {

    private final MutableLiveData<String> mWelcomeText;
    private final MutableLiveData<String> mSubtitleText;

    public HomeViewModel() {
        mWelcomeText = new MutableLiveData<>();
        mWelcomeText.setValue("Welcome to BenefitED!");

        mSubtitleText = new MutableLiveData<>();
        mSubtitleText.setValue("A one-for-all app for all your needs to stay fit, healthy and happy.");
    }

    public LiveData<String> getWelcomeText() {
        return mWelcomeText;
    }

    public LiveData<String> getSubtitleText() {
        return mSubtitleText;
    }
}