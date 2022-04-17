using UnityEngine;
using static UnityEngine.Quaternion;
using DG.Tweening;


public class PlayerContScript : MonoBehaviour
{
    private float _horizontal;
    public float _hSpeed;
    public float _vSpeed;
    
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
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -0.6f, 0.6f);
        transform.position = clampedPosition;
        
         if (!_collisionHandler.finish && _uiScript.gamestart)
         {
             transform.position += Vector3.forward * _vSpeed * Time.fixedDeltaTime;
             //transform.rotation =  Quaternion.Lerp(transform.rotation,Quaternion.Euler(0f, 0f, 10f*( transform.position.x - targetPositionX)),5f*Time.fixedDeltaTime);
             MousePosition();
         }
         else if (_collisionHandler.finish)
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
            
            float xDiff = endPos.x - firstPos.x;
            transform.Translate(xDiff*Time.fixedDeltaTime * _hSpeed/100, 0, 0);
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }

    }
    
}
