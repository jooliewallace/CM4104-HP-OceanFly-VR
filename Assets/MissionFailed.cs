using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI missionFailedText;

    public void DisplayGameOverMessage()
    {
        if (missionFailedText != null)
        {
            missionFailedText.text = "Mission Failed, you have landed in the sea!";
        }
    }
}