using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}
