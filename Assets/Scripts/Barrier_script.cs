using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_script : MonoBehaviour
{
    public GameObject Player;
   
    Renderer barrier_mat;
    simple_controller Player_controller;
    float dist; //distance между игроком и барьером
    float color_str;
    public int right_barrier; //проверяем это правый барьер или нет 
    void Start()
    {
        barrier_mat = gameObject.GetComponent<MeshRenderer>();
        Player_controller = Player.GetComponent<simple_controller>();   
    }
    void Update()
    {
        dist = Mathf.Abs(transform.position.x - Player.transform.position.x);
        //change color block ***
        color_str = Mathf.Clamp(1024/(dist*10), 60, 255);
        //Debug.Log(color_str);
        barrier_mat.material.SetColor("_Color", new Color(1, 0, 0, (color_str-41)/255));
        //change color block ***

        /*if (dist <= 0.2f)
        {
            Handheld.Vibrate();
            
         
        }*/
       
        
    }
}
