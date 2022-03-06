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

    public int collectCount = 0;
    public int gold=100;
    public bool finish = false;
    public bool obstacle = false;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private PizzaStackSc pizzaStack;
    [SerializeField] private UiScript _uiScript;
    private FinalSc _finalSc;

    void Start()
    {
        DOTween.Init();
        _finalSc = FindObjectOfType<FinalSc>();

    }
    
    void FixedUpdate()
    {
        if (!finish && _uiScript.gamestart)
        {
            _horizontal = _joystick.Horizontal;
            //_vertical = Input.GetAxis("Vertical");
            var targetPositionX = Mathf.Lerp(transform.position.x, _horizontal, 3f);
            transform.position += new Vector3(targetPositionX*_hSpeed,0, 1*_vSpeed)*Time.fixedDeltaTime;
            transform.rotation =  Quaternion.Lerp(transform.rotation,Quaternion.Euler(0f, 0f, 10f*( transform.position.x - targetPositionX)),5f*Time.fixedDeltaTime);
            
        }
        else if (finish)
        {
            _vSpeed = 0;
            transform.position = new Vector3(0, transform.position.y, 23.65f);
            transform.rotation= Euler(new Vector3(0,-68f,3.54f));
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
            Debug.Log("çalıştı");
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
           _finalSc.StartColorChange();
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
