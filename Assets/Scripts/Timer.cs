using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the UI text element to display the timer
    private float elapsedTime = 0f; // Elapsed time in seconds
    private bool timerRunning = false; // Flag to indicate if the timer is running
    private bool isLanded = true; // Flag to indicate if the drone is landed

    void Update()
    {
        if (timerRunning)
        {
            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Format the elapsed time into minutes and seconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);

            // Update the UI text to display "Flight Time" followed by the formatted time
            timerText.text = "Flight Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (!isLanded)
            {
                // Drone has landed
                timerRunning = false;
                isLanded = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (isLanded)
            {
                // Drone has lifted off
                timerRunning = true;
                isLanded = false;
            }
        }
    }
}
