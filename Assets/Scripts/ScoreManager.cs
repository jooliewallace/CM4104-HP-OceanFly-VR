// ScoreManager.cs

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI collideText; // Use TextMeshProUGUI for TMP text
    public TextMeshProUGUI inspectionText; // Use TextMeshProUGUI for TMP text
    private int collideScore = 0;
    private int inspectionScore = 0;

    private void Start()
    {
        UpdateScoreUI();
        UpdateInspectionScoreUI();
    }

    public void CollectCollision(int points)
    {
        collideScore += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        collideText.text = "Collisions: " + collideScore.ToString();
    }

    public void CollectInspection(int points)
    {
        inspectionScore += points;
        UpdateInspectionScoreUI();
    }

    private void UpdateInspectionScoreUI()
    {
        inspectionText.text = "Inspection Area Reached: " + inspectionScore.ToString();
    }
}
