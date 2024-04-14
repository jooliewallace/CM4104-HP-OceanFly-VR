using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public int points = 1; // Number to add when collision occurs
    public AudioClip collectSound; // Sound to play when drone collides with game object

    // OnTriggerEnter should not have an explicit access modifier
    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("I hit something!!");

        if (other.CompareTag("OilRig")) // Check for the oilrig tag instead of the player tag
        {
            // Assuming the player has a ScoreManager component
            ScoreManager scoreManager = GetComponent<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.CollectCollision(points);
            }

            // Play the collect sound
            PlayCollectSound();

            //// Optionally, you can add particles, or destroy the present after a small delay
            //Destroy(gameObject, 0.01f); // Adjust the delay here
        }
    }

    private void PlayCollectSound()
    {
        if (collectSound != null)
        {
            // Create an empty GameObject to handle audio playback
            GameObject audioObject = new GameObject("CollectSoundObject");
            audioObject.transform.position = transform.position;

            // Add an AudioSource component to the audio object
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = collectSound;

            // Adjust spatialBlend to control 3D audio effect
            audioSource.spatialBlend = 0f; // 0.0 makes it 2D, 1.0 makes it 3D

            audioSource.volume = 1.0f; // Adjust as needed

            // Play the sound
            audioSource.Play();

            // Destroy the audio object after the sound finishes playing
            Destroy(audioObject, collectSound.length + 0.01f);

            //// Debug message to check if the sound is playing
            //Debug.Log("Collect sound is playing!");
        }
    }
}
