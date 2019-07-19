using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShoot_maker : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ScreenCapture.CaptureScreenshot("SomeLevel"+Random.Range(0,100)+".png");
        }
    }
}
