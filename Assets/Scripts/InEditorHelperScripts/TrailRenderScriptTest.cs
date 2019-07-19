using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRenderScriptTest : MonoBehaviour
{
    TrailRenderer trailRenderer;
    // Start is called before the first frame update
    void Start()
    {
        trailRenderer = gameObject.GetComponent<TrailRenderer>();
        trailRenderer.AddPosition(new Vector3(0,0,0));
        trailRenderer.AddPosition(new Vector3(0, 0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
