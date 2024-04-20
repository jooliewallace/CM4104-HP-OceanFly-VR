using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Function to be called when the button is clicked
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
