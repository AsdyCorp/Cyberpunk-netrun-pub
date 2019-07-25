using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_drift_visualizer : MonoBehaviour
{

    LineRenderer lazerLineRenderer;
    public GameObject centerLine;
    public GameObject player;
    public GameObject dataPacket;//prefab
    [HideInInspector]
    public GameObject dataPacketClone; //instantiated prefab

    Vector3 linePoint; //point of line on one line with car

    // Start is called before the first frame update
    void Start()
    {
        lazerLineRenderer = gameObject.GetComponent<LineRenderer>();
        lazerLineRenderer.SetPosition(0, centerLine.transform.position);
        lazerLineRenderer.SetPosition(1, player.transform.position);
       
        dataPacketClone = Instantiate(dataPacket, player.transform.position, Quaternion.identity);
        dataPacketClone.transform.localScale = new Vector3(50f, 50f, 50f);
    }


  
    // Update is called once per frame
    void Update()
    {
  

        linePoint = new Vector3(centerLine.transform.position.x, centerLine.transform.position.y, player.transform.position.z);

        dataPacketClone.transform.position = Vector3.MoveTowards(dataPacketClone.transform.position, linePoint, Time.deltaTime*2);
        dataPacketClone.transform.position = new Vector3(dataPacketClone.transform.position.x, linePoint.y, linePoint.z);
       

        if(Mathf.Abs(dataPacketClone.transform.position.x - linePoint.x)>Mathf.Abs(player.transform.position.x - linePoint.x)) //если тачка обгоняет датапакет на горизонтале 
        {
            dataPacketClone.transform.position = player.transform.position;
        }
        if (Vector3.Distance(dataPacketClone.transform.position, linePoint) < 0.1f)
        {
            dataPacketClone.transform.position = player.transform.position;
        }


        lazerLineRenderer.SetPosition(0, linePoint);
        lazerLineRenderer.SetPosition(1, new Vector3(player.transform.position.x, centerLine.transform.position.y, player.transform.position.z));
    }
}
