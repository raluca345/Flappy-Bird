using System;
using UnityEngine;
using UnityEngine.UIElements;

public class QuitButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject confirmationWindow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        confirmationWindow.SetActive(true);
        Console.WriteLine("Quit button clicked");
    }
}
