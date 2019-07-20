using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    int is_accel;
    public GameObject[] onGUIControllers; //if acceloremeter enabled - disable them
    // Start is called before the first frame update
    void Start()
    {

        is_accel = PlayerPrefs.GetInt("accel_toggle", 0);
        if (is_accel == 1)
        {
            foreach(GameObject onGUIbuttons in onGUIControllers)
            {
                onGUIbuttons.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
