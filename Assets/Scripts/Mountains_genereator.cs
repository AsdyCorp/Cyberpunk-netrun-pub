using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountains_genereator : MonoBehaviour
{

    public GameObject Mountain;
    public Transform Mountain_start_point;
    public Transform Player;
    [HideInInspector]
    public Vector3 mountain_next_point;
    [HideInInspector]
    public List<GameObject> Mountains = new List<GameObject>();
    void Start()
    {
        mountain_next_point = Mountain_start_point.transform.position;
        for (int i = 0; i < 6; i++)
        {
            GameObject mountain_clone = Instantiate(Mountain, new Vector3(mountain_next_point.x, mountain_next_point.y, mountain_next_point.z + (i * 40)), Quaternion.identity);
            Mountains.Add(mountain_clone);

        }
        mountain_next_point = Mountains[5].transform.position;
    }


    void FixedUpdate()
    {
        foreach (GameObject mountain_obj in Mountains)
        {
            if (mountain_obj.transform.position.z + 30 < Player.position.z)
            {
                mountain_obj.transform.position = new Vector3(mountain_obj.transform.position.x, mountain_obj.transform.position.y, mountain_next_point.z + 40);
                mountain_next_point = mountain_obj.transform.position;
            }
        }
    }
}
