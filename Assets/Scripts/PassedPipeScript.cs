using System;
using Unity.VisualScripting;
using UnityEngine;

public class PassedPipeScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdJumpingScript birdJumpingScript;
    public GameObject middlePrefab;
    
    private Renderer topPipeRenderer;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdJumpingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdJumpingScript>();
        middlePrefab = gameObject;
        
        Transform parentTransform = middlePrefab.transform.parent;
        if (parentTransform != null && parentTransform.childCount > 0)
        {
            topPipeRenderer = parentTransform.GetChild(0).GetComponent<Renderer>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!birdJumpingScript.isAlive) return;

        Color pipeColor = topPipeRenderer.material.color;

            if (pipeColor == Color.yellow)
            {
                logic.AddScore(5); // more points for yellow pipes
            }
            else
            {
                logic.AddScore(1);
            }
    }
}
