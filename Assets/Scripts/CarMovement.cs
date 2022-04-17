using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5.0f;
    
    void Update()
    {
        transform.position += new Vector3(0, 0,-1*speed)*Time.deltaTime;
        
    }
}
