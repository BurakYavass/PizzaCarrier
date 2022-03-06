using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = System.Random;


public class CollectPointSc : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private bool finished = false;

    //private ArrayList randomNumber=new ArrayList();
    float[] randomnum = {-4f, -3.5f, -2f, 1f, 2.5f, 3.37f, 4.3f};
    private float randomLocate;
    [SerializeField] private int timer;
    [SerializeField] private float zPosOffSet;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        DOTween.Init();
        StartCoroutine(RandomNumberGenerator());
    }


    void Update()
    {
        // X movement cycle
        // var seq = DOTween.Sequence();
        // seq.Append(transform.DOMoveX(4, 0.5f));
        // seq.Append(transform.DOMoveX(-3, 0.5f));


        transform.position = new Vector3(randomLocate, 0.37f, _player.transform.position.z + zPosOffSet);

        //transform.DOMoveX(4, 1).SetLoops(-1,LoopType.Restart);

    }

    IEnumerator RandomNumberGenerator()
    {
        while (!finished)
        {
            int randomIndex = UnityEngine.Random.Range(0,6);
            yield return new WaitForSeconds(timer);
            float randomFloatFromNumbers = randomnum[randomIndex];
            randomLocate = randomFloatFromNumbers;
            yield return null;
        }
    }
}




