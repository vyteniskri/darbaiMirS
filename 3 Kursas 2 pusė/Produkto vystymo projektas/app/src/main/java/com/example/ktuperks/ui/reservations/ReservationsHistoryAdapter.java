package com.example.ktuperks.ui.reservations;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.ktuperks.R;

import java.util.List;

public class ReservationsHistoryAdapter extends ArrayAdapter<String> {

    public ReservationsHistoryAdapter(Context context, List<String> reservations) {
        super(context, 0, reservations);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if (convertView == null) {
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.history_list_item_reservation, parent, false);
        }

        TextView reservationTextView = convertView.findViewById(R.id.reservationTextView);
        String reservation = getItem(position);
        reservationTextView.setText(reservation);

        return convertView;
    }
}

