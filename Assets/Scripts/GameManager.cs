using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private bool gameStarted;
    public bool gameFinish=false;
    private float spawnPointZ;
    private int maxSpawn=8;
    private float randomNumber;
    private Vector3 screenBounds;

    public List<Transform> SpawnPosition=new List<Transform>();
    [SerializeField] private PlayerContScript player;
    [SerializeField] private PlayerCollisionHandler playerCollisionHandler;
    [SerializeField] private UiScript uiScript;
    public int targetFrameRate = 30;
    [SerializeField] private GameObject carPrefab;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        
        screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 
                Screen.height, Camera.main.transform.position.z));
        
        spawnPointZ = SpawnPosition[0].transform.position.z;
        
        StartCoroutine(CarWawe());
    }

    void CarSpawner(float randomx)
    {
        GameObject car = Instantiate(carPrefab) as GameObject;
        car.transform.position = new Vector3(randomx,0.187f,spawnPointZ);
        Destroy(car,10.0f);
        
    }


    private void Update()
    {
        gameStarted = uiScript.gamestart;
        gameFinish = playerCollisionHandler.finish;
        if (gameFinish)
        {
            StopAllCoroutines();
        }
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator CarWawe()
    {
        for (int i = 0; i < maxSpawn; i++)
        {
             if (i >= 2)
             {
                 i = 0;
             }
             randomNumber = Random.Range(0.5f, 2.0f);
             yield return new WaitForSeconds(randomNumber);
             CarSpawner(SpawnPosition[i].position.x);
             yield return null;
        }
    }
}
