using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PizzaStackSc : MonoBehaviour
{

    public List<GameObject> PizzaList;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;

    [SerializeField]private float stackSpeed = 1f;
    [SerializeField] private float stackHeight = 0.01f;
    void Start()
    {
        DOTween.Init();
        PizzaList.Add(gameObject);
        
    }
    
    void FixedUpdate()
    {
        if (PizzaList.Count==0)
        {
            PizzaList.Add(gameObject);
        }
        else if (PizzaList.Count >1)
        {
            for (int i = 1; i < PizzaList.Count; i++)
            {
                var downGameObject = PizzaList[i-1];
                var CurrentPizza = PizzaList[i];
                var xPosition = Mathf.Lerp( CurrentPizza.transform.position.x, downGameObject.transform.position.x,stackSpeed);
                CurrentPizza.transform.rotation = downGameObject.transform.rotation;
                CurrentPizza.transform.position = new Vector3(xPosition, downGameObject.transform.position.y + stackHeight,downGameObject.transform.position.z);
                
            }
        }
        if (_playerCollisionHandler.obstacle)
        {
            PizzaList.Clear();
        }
        
    }
    
}
