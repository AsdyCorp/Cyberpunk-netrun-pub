using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer_controller : MonoBehaviour
{

    simple_controller playerController;
    int is_accel; //load controller settings
    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<simple_controller>();
        is_accel= PlayerPrefs.GetInt("accel_toggle", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (is_accel == 1)
        {
            if (Input.acceleration.x < -0.1f)
            {
                playerController.left_start();
                playerController.right_stop();
                playerController.horizontal_speed_multiplier = Mathf.Abs(Input.acceleration.x * 5);
            }
            else if(Input.acceleration.x > 0.1f)
            {
                playerController.right_start();
                playerController.left_stop();
                playerController.horizontal_speed_multiplier = Mathf.Abs(Input.acceleration.x * 5);
            }
            else
            {
                playerController.left_stop();
                playerController.right_stop();
                playerController.horizontal_speed_multiplier = 1.0f;
            }
        }
        
    }
}
