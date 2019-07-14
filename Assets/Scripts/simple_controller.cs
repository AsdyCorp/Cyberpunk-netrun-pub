﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class simple_controller : MonoBehaviour

{

    public float horizontal_speed = 1.5f; //скорость горизантального пооворота машины, т.е. чувствительность управления 

    public Transform car_object_model; //модель машины, которую вращаем 

    public Plate_generator plate_script;
    List<GameObject> Plate_Lines = new List<GameObject>();
    float max_rotation_angle=23; //максимальный угол поворота при горизонтальном перемещении
    float Y_car_angle = 0f; ///угол поворота вокруг оси при горизонтальном перемещении(рид онли) 
    
    public static bool is_left = false;
    public static bool is_right = false;
    public static bool straight_rot = true;

    public GameObject testplate;

    public TrailRenderer[] Flares; //рендерим фары только при повороте

    public int current_plate_id;

    private bool right_barrier = false; ///проверка на столкновение с барьерами
    private bool left_barrier = false;

    public GameObject Event_system;

    public bool is_gyro = false;

    ///render flares only in movement
    void Flares_Renderer_enable()
    {
        foreach(TrailRenderer flare in Flares) 
        {
            flare.emitting = true;
        }
    }
    void Flares_Renderer_disable()
    {
        foreach (TrailRenderer flare in Flares)
        {
            flare.emitting = false;
        }
    }
    ///


    public void left_start()
    {
       
        is_left = true;
        straight_rot = false;
        Flares_Renderer_enable();
    }
    public void left_stop()
    {
        is_left = false;
        straight_rot = true;
        Flares_Renderer_disable();
    }
    public void right_start()
    {
        is_right=true;
        straight_rot = false;
        Flares_Renderer_enable();
    }
    public void right_stop()
    {
        is_right = false;
        straight_rot = true;
        Flares_Renderer_disable();
    }

    

    void Start()
    {

        is_gyro = false;

        ///от заноса при перезапуске
        Event_system.SetActive(true);
        is_left = false;
        is_right = false;
        straight_rot = true;
        ///от заноса при перезапуске
        
        Plate_Lines = plate_script.Plate_Lines;
        current_plate_id = 4;
        
    }



    void FixedUpdate()
    {
       

        ////test barier 
        if ((int)(Mathf.Round(transform.position.x / 0.6f) + 5) >= 10)
        {
            right_barrier = true;
            left_barrier = false;
        }
        else if ((int)(Mathf.Round(transform.position.x / 0.6f) + 5) <= -1)
        {
            left_barrier = true;
            right_barrier = false;
        }
        else
        {
            left_barrier = false;
            right_barrier = false;
            straight_rot = true;
        }
        ////test barier 

        float angle = car_object_model.transform.eulerAngles.y;
        angle = (angle > 180) ? angle - 360 : angle; /// ебаный ui юнити ложь насчёт углов, в реале минуса нет
        Y_car_angle = angle;
        
        if(current_plate_id!= (int)(Mathf.Round(transform.position.x / 0.6f) + 5))
        {
            current_plate_id = (int)(Mathf.Round(transform.position.x / 0.6f) + 5);
            
            foreach (GameObject plate in Plate_Lines)
            {

                if (current_plate_id > plate.GetComponent<Plate_material_changer>().plate_array.plates.Count - 1)
                {
                    current_plate_id = plate.GetComponent<Plate_material_changer>().plate_array.plates.Count - 1;
                }
                if (current_plate_id < 0)
                {
                    current_plate_id = 0;
                }
                plate.GetComponent<Plate_material_changer>().Select_grid(current_plate_id);
            }
            
        }
        //Debug.Log(Mathf.Round(transform.position.x / 0.6f) + 5);
        //if(testplate!=null)


        

        if (is_left && left_barrier==false)
        {
            //Left_Flare.emitting = true;
            //Right_FLare.emitting = true;
            
                transform.Translate(Vector3.left * Time.fixedDeltaTime * horizontal_speed);
            
            
            if (Y_car_angle>= max_rotation_angle*-1)
            {
                car_object_model.Rotate(Vector3.up * Time.deltaTime * -300*(Y_car_angle / 115 + 0.5f));
            }
        }
        if (is_right && right_barrier == false)
        {
            
                transform.Translate(Vector3.right * Time.fixedDeltaTime * horizontal_speed);
            
            if (Y_car_angle<=max_rotation_angle)
            {
                car_object_model.Rotate(Vector3.up * Time.deltaTime * 300 * ((Y_car_angle*-1)/115 + 0.5f));
            }
        }
       // Debug.Log(Y_car_angle +" "+ max_rotation_angle);
        if (straight_rot) //нормализуем машину после поворота
        {

            if (Y_car_angle >1.5f)
            {
                car_object_model.Rotate(0,-2,0);
            }
            else if (Y_car_angle < -1.5f)
            {
                car_object_model.Rotate(0, 2, 0);
            }
            else
            {
                straight_rot = false;
            }

        }
    }
}