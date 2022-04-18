using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PizzaAnimSc : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool trigger;
    private bool isPicked=false;

    void Start()
    {
        DOTween.Init();
        MoveY();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        trigger = transform.GetComponent<BoxCollider>().isTrigger;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPicked = true;
            transform.DOKill();
        }
    }

    void MoveY()
    {
        if (!isPicked)
        {
            transform.DOKill();
            transform.DORotate(new Vector3(0.3f, 0), 1f).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
