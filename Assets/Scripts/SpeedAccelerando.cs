using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAccelerando : MonoBehaviour
{
    simple_controller playerController;
    // Update is called once per frame
    void Start()
    {
        playerController = gameObject.GetComponent<simple_controller>();
    }
    void Update()
    {
        playerController.forwardSpeed += Time.deltaTime / 1000;
    }
}
