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

    /*void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 500, 100), ""+ Input.acceleration.x);
    }*/

    // Update is called once per frame
    void Update()
    {
        if (is_accel == 1)
        {
            if (Input.acceleration.x < -0.03)
            {
                playerController.left_start();
                
                playerController.horizontal_speed_multiplier = Mathf.Abs(Input.acceleration.x * 5);
            }
            else if(Input.acceleration.x > 0.03)
            {
                playerController.right_start();
                
                playerController.horizontal_speed_multiplier = Mathf.Abs(Input.acceleration.x * 5);
            }
            else
            {
                playerController.right_stop();
                playerController.left_stop();
               
            }
            
            
            
        }
        
    }
}
