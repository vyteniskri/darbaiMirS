package com.example.ktuperks.ui.mindletic;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class MindleticViewModel extends ViewModel {

    private final MutableLiveData<String> mText;

    public MindleticViewModel() {
        mText = new MutableLiveData<>();
        mText.setValue("Mindletic is an app designed to help you maintain mental well-being. " +
                "It offers a variety of tools and resources for mental health.");
    }

    public LiveData<String> getText() {
        return mText;
    }
}