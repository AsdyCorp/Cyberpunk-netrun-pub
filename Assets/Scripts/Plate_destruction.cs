using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate_destruction : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 0.7f);
    }
}
