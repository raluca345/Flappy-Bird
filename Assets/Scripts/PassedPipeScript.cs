using System;
using Unity.VisualScripting;
using UnityEngine;

public class PassedPipeScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdJumpingScript birdJumpingScript;
    public GameObject middlePrefab;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdJumpingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdJumpingScript>();
        middlePrefab = gameObject;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!birdJumpingScript.isAlive) return;

        if (middlePrefab != null)
        {
            Transform parentTransform = middlePrefab.transform.parent;
            Color pipeColor = parentTransform.GetChild(0).GetComponent<Renderer>().material.color; // top pipe color

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
}
