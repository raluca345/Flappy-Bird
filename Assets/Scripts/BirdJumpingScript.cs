using UnityEngine;

public class BirdJumpingScript : MonoBehaviour
{
    private Rigidbody2D birdRigidbody;
    public float jumpForce;
    public LogicScript logic;
    public bool isAlive;
    private Renderer birdRenderer;
    private float birdHeight;

    void Start()
    {
        isAlive = true;
        birdRigidbody = GetComponent<Rigidbody2D>();
        birdRenderer = GetComponent<Renderer>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        birdHeight = birdRenderer.bounds.size.y;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ConfirmationWindowScript confirmationScript = ConfirmationWindowScript.Instance;
            
            if (confirmationScript == null)
            {
                confirmationScript = FindFirstObjectByType<ConfirmationWindowScript>(FindObjectsInactive.Include);
            }
            
            if (confirmationScript != null)
            {
                confirmationScript.ShowWindow();
            }
        }
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isAlive)
        {
            birdRigidbody.linearVelocity = Vector2.up * jumpForce;
        }

        // Check if the bird falls off the bottom of the screen completely
        float bottomScreenY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        if (transform.position.y < bottomScreenY - birdHeight / 2)
        {
            logic.GameOver();
            isAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        isAlive = false;
    }
}

