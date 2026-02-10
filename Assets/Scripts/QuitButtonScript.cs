using System;
using UnityEngine;
using UnityEngine.UIElements;

public class QuitButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject confirmationWindow;

    public void OnMouseDown()
    {
        confirmationWindow.SetActive(true);
        Console.WriteLine("Quit button clicked");
    }
}
