using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Cinemachine;


public class FinalSc : MonoBehaviour
{
    [SerializeField] private PlayerContScript _player;
    [SerializeField] private List<Renderer> _windows = new List<Renderer>();
    [SerializeField] private List<TextMeshProUGUI> _point;
    [SerializeField] private Transform _camPoint;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject flat;
    
    private int Score = 0;

    private void Start()
    {
        DOTween.Init();
        _point.AddRange(gameObject.GetComponentsInChildren<TextMeshProUGUI>());
        int pointcount=0;
        for (int i = 1; i <= _point.Count; i++)
        {
            _point[pointcount].SetText((i*10).ToString());
            pointcount++;
        }
    }

    public void StartColorChange()
    {
        StartCoroutine(ColorChange());
    }
    private void LateUpdate()
    {
        Score = _player.collectCount;
    }
    

    IEnumerator ColorChange()
    {
        for (int i = 0; i < Score; i++)
        {
           yield return new WaitForSeconds(_delay);
           _player.gold += 5;
           _windows[i].material.DOColor(Color.yellow,_delay*0.6f);
           _camPoint.transform.DOKill();
           _camPoint.transform.DOMove(_windows[i].transform.position,_delay*0.6f);
           yield return null;
          
        }
        
    }


}
