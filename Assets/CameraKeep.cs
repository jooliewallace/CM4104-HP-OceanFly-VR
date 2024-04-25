using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static Camera mainCameraInstance;

    void Awake()
    {
        if (mainCameraInstance == null)
        {
            // If no main camera instance exists, check if there is a main camera in the scene
            Camera[] cameras = FindObjectsOfType<Camera>();
            foreach (Camera camera in cameras)
            {
                if (camera.CompareTag("MainCamera"))
                {
                    mainCameraInstance = camera;
                    break;
                }
            }

            // If no main camera is found, set this camera as the main camera instance
            if (mainCameraInstance == null)
            {
                mainCameraInstance = GetComponent<Camera>();
                mainCameraInstance.tag = "MainCamera";
            }

            // Set this camera as the main camera instance
            mainCameraInstance.gameObject.SetActive(true);
            DontDestroyOnLoad(mainCameraInstance.gameObject);
        }
        else
        {
            // If a main camera instance already exists and this is not the main camera instance,
            // destroy this camera instance to ensure only one Main Camera exists
            if (mainCameraInstance != GetComponent<Camera>())
            {
                Destroy(gameObject);
            }
        }
    }
}
