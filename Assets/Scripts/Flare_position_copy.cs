using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare_position_copy : MonoBehaviour
{

    public Transform Car_model;
    public Transform Flare_Camera;
    public Transform Car_par;

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector3(Car_model.position.x, transform.position.y, transform.position.z);
        transform.rotation = Car_model.rotation;
        Flare_Camera.position = new Vector3(Car_par.position.x, Flare_Camera.position.y, Flare_Camera.position.z);


    }
}
