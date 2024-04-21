using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using TMPro;
using System.Diagnostics;

public class ScreenshotController : MonoBehaviour
{
    public RenderTexture Drone_View; // Reference to the render texture used in Drone_View
    public InputActionReference droneControlsActionMap;
    public string screenshotPath = "/Screenshots/";
    public TextMeshProUGUI screenshotCountText;

    private InputAction screenshotAction;
    private int screenshotCount = 0;

    private void OnEnable()
    {
        droneControlsActionMap.action.Enable();
        screenshotAction = droneControlsActionMap.action;
        screenshotAction.performed += TakeScreenshot;
    }

    private void OnDisable()
    {
        droneControlsActionMap.action.Disable();
        screenshotAction.performed -= TakeScreenshot;
    }

    private void TakeScreenshot(InputAction.CallbackContext context)
    {
        UnityEngine.Debug.Log("Button pressed!");

        if (context.ReadValue<float>() > 0.5f) // Ensure thumbstick is fully pressed
        {
            UnityEngine.Debug.Log("Thumbstick fully pressed!");

            // Capture screenshot from the render texture
            Texture2D screenshot = new Texture2D(Drone_View.width, Drone_View.height, TextureFormat.RGB24, false);
            RenderTexture.active = Drone_View;
            screenshot.ReadPixels(new Rect(50, 100, Drone_View.width, Drone_View.height), 50, 100);
            screenshot.Apply();
            RenderTexture.active = null;

            UnityEngine.Debug.Log("Screenshot captured.");

            // Save the screenshot to an external folder
            string filePath = Application.persistentDataPath + screenshotPath;
            if (!Directory.Exists(filePath))
            {
                UnityEngine.Debug.Log("Screenshot directory does not exist. Creating directory...");
                Directory.CreateDirectory(filePath);
            }

            string fileName = "screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            string fullPath = filePath + fileName;

            UnityEngine.Debug.Log("Attempting to save screenshot to: " + fullPath);

            File.WriteAllBytes(fullPath, screenshot.EncodeToPNG());

            if (File.Exists(fullPath))
            {
                UnityEngine.Debug.Log("Screenshot saved successfully: " + fullPath);
            }
            else
            {
                UnityEngine.Debug.LogError("Failed to save screenshot!");
            }

            // Update screenshot count and display it on screen
            screenshotCount++;
            if (screenshotCountText != null)
                screenshotCountText.text = "Screenshots taken: " + screenshotCount.ToString();
        }
    }
}
