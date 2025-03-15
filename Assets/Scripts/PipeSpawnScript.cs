using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipePrefab;
    public float baseSpawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    public LogicScript logic;

    void Start()
    {
        SpawnPipe();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        float adjustedSpawnRate = logic.GetAdjustedSpawnRate(baseSpawnRate);

        if (timer < adjustedSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (!logic.isGameOver)
            {
                SpawnPipe();
                timer = 0;
            }
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Vector3 spawnPosition = new(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        GameObject spawnedPipe = Instantiate(pipePrefab, spawnPosition, transform.rotation);

        float rareChance = 0.1f; // 10% chance for a yellow pipe

        if (Random.value < rareChance)
        {
            for (int i = 0; i < spawnedPipe.transform.childCount; i++) // Including middle (trigger)
            {
                Renderer pipeRenderer = spawnedPipe.transform.GetChild(i).GetComponent<Renderer>();

                if (pipeRenderer != null)
                {
                    pipeRenderer.material = new Material(pipeRenderer.material)
                    {
                        color = Color.yellow // Change color safely
                    };
                }
            }
            spawnedPipe.AddComponent<YellowPipeMarker>(); // Add the marker component to yellow pipes
        }
    }
}
