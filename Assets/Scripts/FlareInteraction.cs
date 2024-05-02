using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class FlareZone : MonoBehaviour
{
    public float interactionDistance = 3f; // Adjust the distance as needed
    public TMP_Text messageText;

    private bool isInRange = false;

    void Start()
    {
        // Disable the TMP text initially
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isInRange)
        {
            DisplayMessage();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;

            // Display the message using TMPro
            if (messageText != null)
            {
                messageText.text = "You are flying too close to the flare, move back!";
                messageText.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;

            // Hide the message
            if (messageText != null)
            {
                messageText.gameObject.SetActive(false);
            }
        }
    }

    void DisplayMessage()
    {
        // Implement what you want to happen when player is in range
        //Debug.Log("Performing automatic interaction with the flare zone");
    }
}
