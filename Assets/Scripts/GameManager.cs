using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private bool gameStarted;
    private bool gameFinish=false;
    private float spawnPointZ;
    private int maxSpawn=8;
    private float randomNumber;
    private Vector3 screenBounds;

    public List<Transform> SpawnPosition=new List<Transform>();
    [SerializeField] private PlayerContScript player;
    [SerializeField] private UiScript uiScript;
    [SerializeField] private GameObject carPrefab;
    void Start()
    {
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
        gameFinish = player.finish;
        if (gameFinish)
        {
            StopAllCoroutines();
        }

       
    }

    // public void CarWaweStarter()
    // {
    //     if (gameStarted)
    //         return;
    //     StartCoroutine(CarWawe());
    //
    // }

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
