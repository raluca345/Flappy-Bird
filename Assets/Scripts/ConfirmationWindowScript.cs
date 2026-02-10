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
        if (confirmationWindow == null) return;
        if (confirmationWindow.activeSelf) return;
        
        confirmationWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideWindow()
    {
        if (confirmationWindow == null) return;
        if (!confirmationWindow.activeSelf) return;
        
        confirmationWindow.SetActive(false);
        Time.timeScale = 1;
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

