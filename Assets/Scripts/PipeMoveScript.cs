using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    private LogicScript logic;
    public int deadZone = -45;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (!logic.isGameOver)
        {
            float speedMultiplier = logic.GetSpeedMultiplier();
            transform.position += moveSpeed * speedMultiplier * Time.deltaTime * Vector3.left;

            if (transform.position.x < deadZone)
            {
                Destroy(gameObject);
            }
        }
    }
}
