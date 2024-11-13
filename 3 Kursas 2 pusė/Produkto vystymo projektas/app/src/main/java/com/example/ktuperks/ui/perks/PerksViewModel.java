package com.example.ktuperks.ui.perks;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class PerksViewModel extends ViewModel {

    private final MutableLiveData<String> mTitle;

    public PerksViewModel() {
        mTitle = new MutableLiveData<>();
//        mTitle.setValue("This is perks fragment");
    }

    public LiveData<String> getTitle() {
        return mTitle;
    }
}