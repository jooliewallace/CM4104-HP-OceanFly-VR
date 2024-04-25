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
                messageText.text = "Mission Failed! You have flown too close to the flare";
                messageText.gameObject.SetActive(true);
            }

            //// Restart the scene after 5 seconds
            //Invoke("RestartScene", 5f);
        }
    }

    void DisplayMessage()
    {
        // Your interaction logic here
        UnityEngine.Debug.Log("Performing automatic interaction with the flare zone");
        // You can add more actions or animations here
    }

    //void RestartScene()
    //{
    //    // Restart the current scene
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
}
