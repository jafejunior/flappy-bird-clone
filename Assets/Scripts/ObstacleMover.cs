using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get GameManager
        var gameManager = GameManager.Instance;

        // Ignore if game is over
        if(gameManager.IsGameOver()) return;

        // Move objetct
        float x = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        // Destroy obstacle when bellow of -6 in Eix X
        if (transform.position.x <= -6f){
            Destroy(gameObject);
        }
    }
}
