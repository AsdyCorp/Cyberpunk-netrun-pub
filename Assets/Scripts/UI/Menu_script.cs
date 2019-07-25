using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_script : MonoBehaviour
{
    public string CyberDeck;
    UnityEngine.UI.Text Gui_Text_element;
    public GameObject UI_Text;
    string complete_string;
    string about_path ;

    public GameObject Enter_button_obj;
    public GameObject Esc_button_obj;
    public GameObject Settings_button_obj;
    public GameObject About_button_obj;

    public GameObject Settings_UI_parent_obj;

    public GameObject adManager;


    private int UI_level=0;  //0 - menu/ 1 - settings // 2 - about



   
    void Start()
    {
        Time.timeScale = 1.0f;//after pause ui we have time stoped, need to start it


        
        about_path = "about.txt";
        UI_level = 0;
        Enter_button_obj.GetComponent<Button>().interactable=true;
        Esc_button_obj.GetComponent<Button>().interactable = true;
        Settings_button_obj.GetComponent<Button>().interactable = true;
        About_button_obj.GetComponent<Button>().interactable = true;

        Settings_UI_parent_obj.SetActive(false);

        //Inicial screen data 
        Gui_Text_element = UI_Text.GetComponent<UnityEngine.UI.Text>();
        complete_string += CyberDeck;
        complete_string += "\n";
        complete_string += ">Software version "+ Application.version; ///get app version
        complete_string += "\n";
        complete_string += System.DateTime.Now; //get date and time
        complete_string += "\n";
        complete_string += ">Your max score: "+PlayerPrefs.GetInt("Score", 0); //get max score 
        complete_string += "\n\n\n";
        complete_string += ">Cyber construct ver.4 load....... ";
        complete_string += "\n";
        complete_string += ">Are you ready?.. Y/N";
        complete_string += "\n";
        complete_string += ">Yes";
        Gui_Text_element.text = complete_string;
        //Inicial screen data

        adManager.GetComponent<AdManager>().Display_Banner();
    }

    public void Start_button()
    {
        if (adManager.GetComponent<AdManager>().bannerAD != null)
        {
            adManager.GetComponent<AdManager>().bannerAD.Destroy();
        }
        
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        
    }
    public void Exit_button()
    {
        switch (UI_level)
        {
            case 0:
                Application.Quit();
                break;
            case 1:
                PlayerPrefs.Save();
                menu_back();
                Settings_UI_parent_obj.SetActive(false);
                break;
            case 2:
                menu_back();
                break;
            default:
                menu_back();
                break;

        }   
    }


    void Blink_Enter()///blink effect of enter screen 
    {

        if(Gui_Text_element.text.Length != 0 && Gui_Text_element.text[Gui_Text_element.text.Length-1]== '█')
        {
            Gui_Text_element.text = Gui_Text_element.text.Remove(Gui_Text_element.text.Length - 1);
        }
        else
        {
            if(Gui_Text_element.text.Length != 0)
            {
                Gui_Text_element.text += "█";
            }
            
        }
    }
    float timer = 1.0f;//timer for blinker
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            Blink_Enter();//enter blink
            timer = 1.0f;
        }
    }
    
    public void Settings()
    {
        UI_level = 1;
        Gui_Text_element.text = "";
        Settings_UI_parent_obj.SetActive(true);
        Enter_button_obj.GetComponent<Button>().interactable = false;
        Esc_button_obj.GetComponent<Button>().interactable = true;
        Settings_button_obj.GetComponent<Button>().interactable = false;
        About_button_obj.GetComponent<Button>().interactable = false;
    }

    public void About()
    {
        UI_level = 2;
        Gui_Text_element.text = "";
        TextAsset about_text_asset = (TextAsset)Resources.Load(about_path);
        Gui_Text_element.text = about_text_asset.text;
        Enter_button_obj.GetComponent<Button>().interactable = false;
        Esc_button_obj.GetComponent<Button>().interactable = true;
        Settings_button_obj.GetComponent<Button>().interactable = false;
        About_button_obj.GetComponent<Button>().interactable = false;
    } 
    public void menu_back()
    {
        Enter_button_obj.GetComponent<Button>().interactable = true;
        Esc_button_obj.GetComponent<Button>().interactable = true;
        Settings_button_obj.GetComponent<Button>().interactable = true;
        About_button_obj.GetComponent<Button>().interactable = true;

        UI_level = 0;
        Gui_Text_element.text = "";
        Gui_Text_element.text = complete_string;
    }

}
