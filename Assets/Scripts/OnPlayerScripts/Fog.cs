using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class Fog : MonoBehaviour
{
    float multiplier = 0.0f;
    public float fog_str;
    BloomOptimized camera_bloom;
    void Start()
    {
        RenderSettings.fogMode = FogMode.Exponential;
        camera_bloom = Camera.main.gameObject.GetComponent<BloomOptimized>();
    }
    void FixedUpdate()
    {

        if (fog_str < 0.01f || fog_str> 0.163)
        {
            multiplier += Time.fixedDeltaTime/20;
        }
        else
        {
            multiplier += Time.fixedDeltaTime*10;
        }
        
     
        if (multiplier > 8*Mathf.PI) ///синус гугли, на графике на глаз подбирал
        {
            multiplier = 0.0f;
        }

        //максимум на 4 пи, минимум на 8 пи или 0 
        fog_str = (0.5f + 0.5f*Mathf.Sin(0.25f*multiplier - 1.5708f))/6;
        //Debug.Log(fog_str);
        RenderSettings.fogDensity = fog_str;
        //camera_bloom.intensity = (fog_str) * 6+0.7f;
        //RenderSettings.fog
        //RenderSettings.fogColor = new Color(255-(fog_str * 255), 0, 0,0);
    }
}
