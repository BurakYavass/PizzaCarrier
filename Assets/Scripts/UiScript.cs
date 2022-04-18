using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;


public class UiScript : MonoBehaviour
{
    [SerializeField] private PlayerContScript _playerController;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI collectText;
    [SerializeField] private GameObject runTimePanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject finalPanel;
    
    private int collectCount;
    public bool gamestart = false;

    [SerializeField] private Transform _hand;
    void Start()
    {
        DOTween.Init();
        _hand.DOLocalMoveX(-100, 1).SetLoops(-1,LoopType.Yoyo);
        
    }
    

    // Update is called once per frame
    void LateUpdate()
    { 
        collectText.SetText(_playerController.collectCount.ToString());
        goldText.SetText(_playerController.gold.ToString());
        
        
        if (Input.GetMouseButtonUp(0))
        {
            gamestart = true;
        }
        
        if (gamestart)
        {
            menuPanel.SetActive(false);
            runTimePanel.SetActive(true);
        }
        else if (!gamestart)
        {
            menuPanel.SetActive(true);
            runTimePanel.SetActive(false);
        }

        if (_gameManager.gameFinish)
        {
            finalPanel.SetActive(true);
        }
    }
        
    

   

    
}
