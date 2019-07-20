using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro_Controller : MonoBehaviour
{

    Gyroscope gyro;
    simple_controller playerController;
    float sensitivityLevel;
    int isGyroActive;
    Quaternion staticGyro;
    // Start is called before the first frame update
    void Start()
    {
        isGyroActive= PlayerPrefs.GetInt("gyro_toggle", 0);
        gyro = Input.gyro;
        playerController = gameObject.GetComponent<simple_controller>();
        sensitivityLevel= PlayerPrefs.GetFloat("sensitivity_slider", 0.5f);
        if (isGyroActive == 1)
        {
            staticGyro = gyro.attitude;
        }
    }


    void GetNewStaticGyroVector()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (isGyroActive == 1)
        {
            Debug.Log(gyro.attitude);
        }
    }
}
