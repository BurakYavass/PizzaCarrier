using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private PizzaStackSc pizzaStack;

    [SerializeField] private PlayerContScript playerContScript;
    
    public bool finish = false;
    public bool obstacle = false;
    
    void Start()
    {
        DOTween.Init();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("collectible"))
        {
            pizzaStack.PizzaList.Add(collision.gameObject);
            collision.collider.isTrigger = true;
            playerContScript.collectCount++;
            playerContScript.gold += 2;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            obstacle = true;
            playerContScript.collectCount = 0;
            playerContScript._hSpeed = 0;
            playerContScript._vSpeed = 0;
            playerContScript.transform.DOPunchPosition(new Vector3(0, 0, 0.1f), 0.5f);
            StartCoroutine(TimeCounter());

        }
        
       

        if (finish)
        {
            return;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            other.GetComponentInParent<FinalSc>().StartColorChange();
            finish = true;
        }
    }

    IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(1);
        playerContScript._hSpeed = 2;
        playerContScript._vSpeed = 2.5f;
        obstacle = false;
        yield return null;
        
    }
}
