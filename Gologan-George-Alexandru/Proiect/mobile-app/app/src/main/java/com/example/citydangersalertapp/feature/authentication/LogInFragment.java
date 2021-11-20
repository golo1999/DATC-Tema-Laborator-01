package com.example.citydangersalertapp.feature.authentication;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.databinding.DataBindingUtil;
import androidx.fragment.app.Fragment;

import com.example.citydangersalertapp.R;
import com.example.citydangersalertapp.databinding.LogInFragmentBinding;

public class LogInFragment extends Fragment {
    private LogInFragmentBinding binding;
    private AuthenticationViewModel viewModel;

    public LogInFragment() {
        // Required empty public constructor
    }

    public LogInFragment(AuthenticationViewModel viewModel) {
        this.viewModel = viewModel;
    }

    public static LogInFragment newInstance() {
        LogInFragment fragment = new LogInFragment();
        Bundle args = new Bundle();

        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {

        }
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container,
                             Bundle savedInstanceState) {
        setFragmentVariables(inflater, container);
        setLayoutVariables();

        return binding.getRoot();
    }

    private void setFragmentVariables(@NonNull LayoutInflater inflater,
                                      ViewGroup container) {
        binding = DataBindingUtil.inflate(inflater, R.layout.log_in_fragment, container, false);
    }

    private void setLayoutVariables() {
        binding.setActivity((AuthenticationActivity) requireActivity());
        binding.setViewModel(viewModel);
    }
}