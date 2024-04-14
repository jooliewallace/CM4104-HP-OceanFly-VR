using UnityEngine;
using TMPro;

public class UIControls : MonoBehaviour
{
    public TextMeshProUGUI missionFailedText; // Reference to the mission failed message text

    public void DisplayMissionFailedMessage(string message)
    {
        if (missionFailedText != null)
        {
            missionFailedText.text = message;
        }
    }
}
