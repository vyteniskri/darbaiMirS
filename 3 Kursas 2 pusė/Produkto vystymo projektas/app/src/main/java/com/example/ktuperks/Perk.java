package com.example.ktuperks;

import com.google.firebase.firestore.GeoPoint;

import java.util.List;

public class Perk {
    private String title;
    private String information;
    private List<GeoPoint> location;
    private String imageUrl;


    // Getters and Setters
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getInformation() {
        return information;
    }

    public void setInformation(String information) {
        this.information = information;
    }

    public List<GeoPoint> getLocation() {
        return location;
    }

    public void setLocation(List<GeoPoint> location) {
        this.location = location;
    }

    public String getImageUrl() {  // Add this getter
        return imageUrl;
    }

    public void setImageUrl(String imageUrl) {  // Add this setter
        this.imageUrl = imageUrl;
    }
}