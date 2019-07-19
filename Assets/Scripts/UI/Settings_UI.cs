using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Юзаем для сохранения новых и загрузки старых параметров в гуй
/// </summary>
public class Settings_UI : MonoBehaviour
{

    public GameObject Sound_Slider;
    public GameObject Sensitivity_slider;
    public GameObject Gyro_toggle;
    public GameObject Gui_buttons_toggle;


    private Toggle gui_buttons_toogle;
    private Toggle gyro_toggle;
    private Slider sound_Slider;
    private Slider sensitivity_slider;

    private int is_gyro=0;
    private int is_button=0;
    private float sound_level=1.0f;
    private float sensitivity_level=1.0f;
    // Start is called before the first frame update


    bool ToBoolean(int x)
    {
        if (x == 0)
        { 
            return false;
        }
        else
        {
            return true;
        }
    }

    int ToInt(bool x)
    {
        if (x == true)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    void Start()
    {
        
        gui_buttons_toogle = Gui_buttons_toggle.GetComponent<Toggle>();
        gyro_toggle = Gyro_toggle.GetComponent<Toggle>();
        sound_Slider = Sound_Slider.GetComponent<Slider>();
        sensitivity_slider = Sensitivity_slider.GetComponent<Slider>();
        /******/
        is_gyro = PlayerPrefs.GetInt("gyro_toggle", 0);///get preferences from playerprefs to settings vars
        is_button = PlayerPrefs.GetInt("gui_buttons_toogle", 1);
        sound_level =  PlayerPrefs.GetFloat("sound_Slider", 0.5f);
        sensitivity_level = PlayerPrefs.GetFloat("sensitivity_slider", 0.5f); ///

        if ((is_button == 1 && is_gyro == 1) || (is_button == 0 && is_gyro == 0)) //check for only one option
        {
            PlayerPrefs.SetInt("gyro_toggle", 0);
            PlayerPrefs.SetInt("gui_buttons_toogle", 1);
            is_button = 1;
            is_gyro = 0;
        }


        ///set gui to prefs
        gui_buttons_toogle.isOn = ToBoolean(is_button);
        gyro_toggle.isOn = ToBoolean(is_gyro);
        sound_Slider.value = sound_level;
        sensitivity_slider.value = sensitivity_level;
        ///

        sound_Slider.onValueChanged.AddListener(delegate { Change_Sound(); });
        sensitivity_slider.onValueChanged.AddListener(delegate { Change_Sensitivity(); });
        gyro_toggle.onValueChanged.AddListener(delegate { Change_gyro_toggle(); });
        gui_buttons_toogle.onValueChanged.AddListener(delegate { Change_gui_button_toggle(); });

    }

    public void Change_Sensitivity() ///sensitivity slider
    {
        sensitivity_level = sensitivity_slider.value;
        PlayerPrefs.SetFloat("sensitivity_slider", sensitivity_level);
      
      
    }
    public void Change_Sound()
    {
        sound_level = sound_Slider.value;
        PlayerPrefs.SetFloat("sound_Slider", sound_level);
       
    }


    public void Change_gui_button_toggle()///change to gui buttons
    {
        is_button = ToInt(gui_buttons_toogle.isOn);
        is_gyro = ToInt(gyro_toggle.isOn);
        PlayerPrefs.SetInt("gyro_toggle", is_gyro);
        PlayerPrefs.SetInt("gui_buttons_toogle", is_button);
        PlayerPrefs.Save();
    }

    public void Change_gyro_toggle() ///change to gyro
    {
        is_gyro = ToInt(gyro_toggle.isOn);
        is_button = ToInt(gui_buttons_toogle.isOn);
        PlayerPrefs.SetInt("gyro_toggle", is_gyro);
        PlayerPrefs.SetInt("gui_buttons_toogle", is_button);
        PlayerPrefs.Save();
    }





}
