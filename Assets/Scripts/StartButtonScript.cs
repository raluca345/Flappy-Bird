using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        // Load the game scene
        SceneManager.LoadScene("MainScene");
    }
}
