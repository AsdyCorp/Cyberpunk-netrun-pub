using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class Pause_UI : MonoBehaviour
{
    bool pause_bool=false;
    public GameObject Pause_par_obj;
    public BlurOptimized blur_script;//блюр скрипт

    public GameObject[] UI_hide_elements;// UI элементы, которые прячем при паузе

    void Start()
    {
        blur_script.enabled = false;
        Pause_par_obj.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void pause()
    {
        pause_bool = !pause_bool;
        if (pause_bool)
        {
            blur_script.enabled = true;
            Pause_par_obj.SetActive(true);
            Time.timeScale = 0;

            foreach(GameObject ui_hide_element in UI_hide_elements)//прячем ненужные юай элементы
            {
                ui_hide_element.SetActive(false);
            }
        }
        else
        {
            blur_script.enabled = false;
            Pause_par_obj.SetActive(false);
            Time.timeScale = 1.0f;
            foreach (GameObject ui_hide_element in UI_hide_elements)//показываем элементы обратно
            {
                ui_hide_element.SetActive(true);
            }
        }
    }
}
