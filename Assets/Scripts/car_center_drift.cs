using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_center_drift : MonoBehaviour
{
    public Transform Light_line;
    void FixedUpdate()
    {
        if(transform.position.x>Light_line.position.x+0.05 || transform.position.x < Light_line.position.x-0.05)
        {

            float drift_frc = (transform.position.x - Light_line.position.x) / (Mathf.Abs(transform.position.x - Light_line.position.x)*-1);
            transform.Translate(new Vector3(drift_frc/6, 0, 0) * Time.fixedDeltaTime);
        }
    }
}
