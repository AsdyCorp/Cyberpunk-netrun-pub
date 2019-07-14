using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simple_mover_trasy : MonoBehaviour
{
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward*speed);
    }
}
