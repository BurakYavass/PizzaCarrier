using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Quaternion;
using DG.Tweening;
using Unity.Mathematics;
using Cinemachine;

public class PlayerContScript : MonoBehaviour
{
    private float _horizontal;
    public float _hSpeed;
    public float _vSpeed;
    
    private Vector3 firstPos, endPos;

    public int collectCount = 0;
    public int gold=100;
    public bool finish = false;
    public bool obstacle = false;
    
    [SerializeField] private PizzaStackSc pizzaStack;
    [SerializeField] private UiScript _uiScript;
    private FinalSc _finalSc;
    

    void Start()
    {
        DOTween.Init();
    }
    
    void LateUpdate()
    {
        transform.position += Vector3.forward * _vSpeed * Time.deltaTime;
        // if (!finish && _uiScript.gamestart)
        // {
        //     transform.position += Vector3.forward * _vSpeed * Time.deltaTime;
        //     //transform.rotation =  Quaternion.Lerp(transform.rotation,Quaternion.Euler(0f, 0f, 10f*( transform.position.x - targetPositionX)),5f*Time.fixedDeltaTime);
        //     //MousePosition();
        // }
        // else if (finish)
        // {
        //     _vSpeed = 0;
        //     transform.position = new Vector3(0, transform.position.y, 23.65f);
        //     transform.rotation= Euler(new Vector3(0,-68f,3.54f));
        // }
    }
    
    void MousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            
            float xDiff = endPos.x - firstPos.x;
            transform.Translate(xDiff*Time.deltaTime * _hSpeed/200, 0, 0);
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }

    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            pizzaStack.PizzaList.Add(other.gameObject);
            other.collider.isTrigger = true;
            collectCount++;
            gold += 5;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            //pizzaStack.PizzaList.Clear();
            obstacle = true;
            collectCount = 0;
            _hSpeed = 0;
            _vSpeed = 0;
            transform.DOPunchPosition(new Vector3(0, 0, 0.1f), 0.5f);
            StartCoroutine(TimeCounter());

        }

        if (finish)
        {
            return;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            other.GetComponent<FinalSc>().StartColorChange();
            finish = true;
        }
    }

    IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(2);
        _hSpeed = 2;
        _vSpeed = 2.5f;
        obstacle = false;
        yield return null;
        
    }
}
