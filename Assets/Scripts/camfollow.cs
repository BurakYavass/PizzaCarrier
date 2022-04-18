using UnityEngine;
using Cinemachine;

public class camfollow : MonoBehaviour
{
    [SerializeField] private PlayerContScript Player;
    [SerializeField] private PlayerCollisionHandler playerCollisionHandler;
    [SerializeField] private CinemachineVirtualCamera playerCam;
    [SerializeField] private CinemachineVirtualCamera finalCam;
    [SerializeField] private Transform _bikeFollower;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //_bikeFollower.transform.position = Player.transform.position;
        if (playerCollisionHandler.finish)
        {
            finalCam.enabled=true;
        }
    }
}
