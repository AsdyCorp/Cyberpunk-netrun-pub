using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_test_mover : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0.005f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0.005f);
        }
    }
}
