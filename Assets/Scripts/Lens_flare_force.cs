using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lens_flare_force : MonoBehaviour
{

    public Fog fogScript; ///get intensity from fog script
    // Start is called before the first frame update
    LensFlare flareScript;
    float lensStrength;
    bool firstEnter=true; //проверяем если игра запустилась - делаем затемняющую вспышку, потом меняем на нормальный цикл

    void Start()
    {
        flareScript = gameObject.GetComponent<LensFlare>();
    }

    // Update is called once per frame
    void Update()
    {

        if (firstEnter)
        {
            lensStrength = 1 / fogScript.fog_str / 20000;
            flareScript.brightness = Mathf.Clamp(lensStrength, 0.1f, lensStrength);
        }
        else
        {
            lensStrength = 1 / fogScript.fog_str / 20000;
            flareScript.brightness = Mathf.Clamp(lensStrength, 0.1f, 0.8f);
        }
        if (lensStrength < 0.4f)
        {
            firstEnter = false;
        }
        
    }
}
