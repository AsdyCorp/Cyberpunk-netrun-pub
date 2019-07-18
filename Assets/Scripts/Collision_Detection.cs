using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Detection : MonoBehaviour
{
    private BoxCollider playerCollider;
    private Death deathScript;
    // Start is called before the first frame update
    void Awake()
    {
        playerCollider = gameObject.GetComponent<BoxCollider>();
        deathScript = GetComponentInParent<Death>();
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        otherCollider.enabled = false;
        playerCollider.enabled = false;
        deathScript.DeathCall();
    }
}
