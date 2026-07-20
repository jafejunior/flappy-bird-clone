using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public float cooldown = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get GameManager
        var gameManager = GameManager.Instance;

        // Ignore if game is over
        if(gameManager.IsGameOver()) return;

        // Update cooldown
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f){
            if (gameManager){
                cooldown = gameManager.obstacleInterval;

                // Spawn obstacle
                int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
                GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];
                float x = gameManager.obstacleOffsetX;
                float y = Random.Range(gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y);
                Vector3 position = new Vector3(x, y, -0.2f);
                Quaternion rotation = prefab.transform.rotation;
                // Create object obstacle
                Instantiate(prefab, position, rotation);   
            }
        }
    }
}
