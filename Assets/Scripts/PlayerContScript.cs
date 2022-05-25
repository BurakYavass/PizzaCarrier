using System;
using UnityEngine;
using static UnityEngine.Quaternion;
using DG.Tweening;


public class PlayerContScript : MonoBehaviour
{
    private float _horizontal;
    public float _hSpeed;
    public float _vSpeed;

    private float xDiff=0;
    
    private Vector3 firstPos, endPos;

    public int collectCount = 0;
    public int gold=100;

    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private UiScript _uiScript;
    private FinalSc _finalSc;
    
    void Start()
    {
        DOTween.Init();
    }
    
    void FixedUpdate()
    {
         if (!_collisionHandler.finish && _uiScript.gamestart)
         {
             transform.position += Vector3.forward * _vSpeed * Time.fixedDeltaTime;
             
             Vector3 clampedPosition = transform.position;
         
             clampedPosition.x = Mathf.Clamp(clampedPosition.x, -0.5f, 0.5f);
             transform.position = clampedPosition;
             
             MousePosition();
             
             // transform.rotation =  Quaternion.Lerp(transform.rotation,
             //                                  Quaternion.Euler(0f, 0f, 10f*( transform.position.x)),
             //                                                                  5f*Time.fixedDeltaTime);
         }
         
         if (_collisionHandler.finish)
         {
             _vSpeed = 0;
             transform.position = new Vector3(0, transform.position.y, 23.65f);
             transform.rotation= Euler(new Vector3(0,-68f,3.54f));
         }
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
            xDiff = endPos.x - firstPos.x;
            
            //float smoothPosition = Mathf.Lerp(transform.position.x, xDiff, _hSpeed);
            transform.Translate(xDiff*_hSpeed/Screen.width*100*Time.fixedDeltaTime , 0, 0);
            firstPos = endPos;
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            // firstPos = Vector3.zero;
            // endPos = Vector3.zero;
            xDiff = 0;
        }
    }
    
}
