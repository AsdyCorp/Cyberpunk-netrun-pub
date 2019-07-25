using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPacketMover : MonoBehaviour
{
    public GameObject player;
    public Transform endPoint; //куда летят пакеты 
    Vector3 startPoint;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        speed = Random.Range(10f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, player.transform.position) >120)
        {
            transform.position = startPoint;
        }
    }
}
