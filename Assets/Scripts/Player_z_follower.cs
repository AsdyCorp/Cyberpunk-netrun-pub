using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_z_follower : MonoBehaviour
{
    public Transform Player;
    
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.position.z);
    }
}
