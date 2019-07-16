using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SendMessage("tttt", 5.0);
    }

    
}
