using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}

    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval = 1;
    public float obstacleSpeed = 1;
    public float obstacleOffsetX = 0.50f;
    public Vector2 obstacleOffsetY = new Vector2(0, 0);

    [HideInInspector]
    public int score = 0;

    [HideInInspector]
    private bool isGameOver = false;

    void Awake()
    {
        // Singleton
        if(Instance != null && Instance != this){
                Destroy(this);
        }else{
            Instance = this;
        }
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void EndGame()
    {
        // set flag
        isGameOver = true;
        
        // Alert of the End game
        Debug.Log("Game Over!");

        StartCoroutine(ReloadingScene(2));
    }
    
    private IEnumerator ReloadingScene(float delay)
    {
        // Await 2 seconds of delay
        yield return new WaitForSeconds(delay);

        // Reload Scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload Scene Now!");
    }
}
