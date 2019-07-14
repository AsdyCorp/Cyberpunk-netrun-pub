using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid_erection_lol : MonoBehaviour
{

    float height;
    void Update()
    {
        if(height < 600)
        {
            height += Time.deltaTime * 300;
        }
        
        transform.localScale = new Vector3(100, height, 100);
    }


}
