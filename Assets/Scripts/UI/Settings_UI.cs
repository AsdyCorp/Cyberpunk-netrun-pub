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
    public GameObject Accel_toggle;
    public GameObject Gui_buttons_toggle;
    public GameObject Accelerometer_text;

    private Toggle gui_buttons_toogle;
    private Toggle accel_toggle;
    private Slider sound_Slider;
    private Slider sensitivity_slider;

    private int is_accel=0;
    private int is_button=0;
    private float sound_level=1.0f;
    private float sensitivity_level=1.0f;
    // Start is called before the first frame update

    bool is_accel_exist = true; //check if accelerometr exist in device


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
        is_accel_exist = SystemInfo.supportsAccelerometer;
       
        gui_buttons_toogle = Gui_buttons_toggle.GetComponent<Toggle>();
        accel_toggle = Accel_toggle.GetComponent<Toggle>();
        sound_Slider = Sound_Slider.GetComponent<Slider>();
        sensitivity_slider = Sensitivity_slider.GetComponent<Slider>();
        if (is_accel_exist == false)
        {
            Accelerometer_text.SetActive(true);
            accel_toggle.isOn = false;
            accel_toggle.enabled = false;
        }
        /******/
        if (is_accel_exist)
        {
            is_accel = PlayerPrefs.GetInt("accel_toggle", 0);///get preferences from playerprefs to settings vars
            is_button = PlayerPrefs.GetInt("gui_buttons_toogle", 1);
        }
        else
        {
            is_button = 1;
            is_accel = 0;
        }
        sound_level = PlayerPrefs.GetFloat("sound_Slider", 0.5f);
        sensitivity_level = PlayerPrefs.GetFloat("sensitivity_slider", 0.5f); ///
        if ((is_button == 1 && is_accel == 1) || (is_button == 0 && is_accel == 0)) //check for only one option
        {
            PlayerPrefs.SetInt("accel_toggle", 0);
            PlayerPrefs.SetInt("gui_buttons_toogle", 1);
            is_button = 1;
            is_accel = 0;
        }


        ///set gui to prefs
        gui_buttons_toogle.isOn = ToBoolean(is_button);
        accel_toggle.isOn = ToBoolean(is_accel);
        sound_Slider.value = sound_level;
        sensitivity_slider.value = sensitivity_level;
        ///

        sound_Slider.onValueChanged.AddListener(delegate { Change_Sound(); });
        sensitivity_slider.onValueChanged.AddListener(delegate { Change_Sensitivity(); });
        if (is_accel_exist)
        {
            accel_toggle.onValueChanged.AddListener(delegate { Change_accel_toggle(); });
            gui_buttons_toogle.onValueChanged.AddListener(delegate { Change_gui_button_toggle(); });
        }
        

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
        is_accel = ToInt(accel_toggle.isOn);
        PlayerPrefs.SetInt("accel_toggle", is_accel);
        PlayerPrefs.SetInt("gui_buttons_toogle", is_button);
        PlayerPrefs.Save();
    }

    public void Change_accel_toggle() ///change to gyro
    {
        is_accel = ToInt(accel_toggle.isOn);
        is_button = ToInt(gui_buttons_toogle.isOn);
        PlayerPrefs.SetInt("accel_toggle", is_accel);
        PlayerPrefs.SetInt("gui_buttons_toogle", is_button);
        PlayerPrefs.Save();
    }





}
