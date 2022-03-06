using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Utility;

public class camfollow : MonoBehaviour
{
    [SerializeField] private PlayerContScript Player;
    [SerializeField] private CinemachineVirtualCamera playerCam;
    [SerializeField] private CinemachineVirtualCamera finalCam;
    [SerializeField] private FinalSc _finalSc;
    [SerializeField] private Transform _bikeFollower;
    
    // Update is called once per frame
    void Update()
    {
        _bikeFollower.transform.position = Player.transform.position;
        if (Player.finish)
        {
            finalCam.enabled=true;
        }
    }
}
