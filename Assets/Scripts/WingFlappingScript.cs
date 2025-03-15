using UnityEngine;

public class WingFlappingScript : MonoBehaviour
{
    public Sprite wingUp;
    public Sprite wingDown;
    private SpriteRenderer spriteRenderer;

    private bool isJumping = false;
    private float fallTimer = 0f;
    public float fallDelay = 0.2f;
    private Vector3 WingPosition;

    void Start()
    {
        WingPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            isJumping = true;
            fallTimer = fallDelay;
            spriteRenderer.sprite = wingUp;
        }

        // simulate falling by using a timer
        if (isJumping)
        {
            fallTimer -= Time.deltaTime;
            if (fallTimer <= 0)
            {
                isJumping = false;
                spriteRenderer.sprite = wingDown;
            }
        }

        transform.position = transform.parent.position + WingPosition;
    }
}
