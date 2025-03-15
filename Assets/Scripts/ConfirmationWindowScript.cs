using UnityEngine;

public class ConfirmationWindowScript : MonoBehaviour
{
    public static ConfirmationWindowScript Instance { get; private set; }
    public GameObject confirmationWindow;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowWindow()
    {
        if (confirmationWindow != null)
        {
            confirmationWindow.SetActive(true);
            Time.timeScale = 0; // Pause the game
        }
        else
        {
            Debug.LogError("Confirmation window is null");
        }
    }

    public void HideWindow()
    {
        if (confirmationWindow != null)
        {
            confirmationWindow.SetActive(false);
            Time.timeScale = 1; // Resume the game
        }
        else
        {
            Debug.LogError("Confirmation window is null");
        }
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnCancelButtonClicked()
    {
        HideWindow();
    }
}

