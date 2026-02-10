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
            
            if (confirmationWindow == null)
            {
                Debug.LogError("Confirmation window is not assigned!", this);
                enabled = false;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowWindow()
    {
        
        if (confirmationWindow.activeSelf) return;
        
        confirmationWindow.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void HideWindow()
    {
        
        if (!confirmationWindow.activeSelf) return;
        
        confirmationWindow.SetActive(false);
        Time.timeScale = 1; // Resume the game
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

