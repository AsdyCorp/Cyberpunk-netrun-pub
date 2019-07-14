using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_Emission : MonoBehaviour
{

    public LineRenderer Lazer_lineRenderer;
    public float test;
    float width = 0f;
    void Start()
    {
        Lazer_lineRenderer.widthMultiplier = 1;
        
    }
    void Update()
    {

        Lazer_lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y - 30, transform.position.z));
        Lazer_lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y + 30, transform.position.z));
        if (width < 1f)
        {
            width += Time.deltaTime/4;
        }
        Lazer_lineRenderer.widthMultiplier=width;

    }
}
