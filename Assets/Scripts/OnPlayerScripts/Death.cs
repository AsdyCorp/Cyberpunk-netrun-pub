using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    public GameObject Death_explosion;
    public GameObject Flares;
    public GameObject Car_model;
    public GameObject After_Death_UI;
    public GameObject[] Controll_UI_buttons;
    public GameObject carDriftVisulizer;
    public GameObject Pause_button; 
    //public GameObject[] After_Death_UI_buttons;
    //public GameObject[] After_Death_UI_text;


    public void DeathCall()
    {

        Pause_button.SetActive(false);//при смерти выключаем кнопку паузы

        carDriftVisulizer.SetActive(false); //отключаем линию и шарик от машины до белой линии 
        carDriftVisulizer.GetComponent<car_drift_visualizer>().dataPacketClone.SetActive(false);


        gameObject.GetComponent<simple_mover_trasy>().speed = 0;
        gameObject.GetComponent<car_center_drift>().enabled = false;
        gameObject.GetComponent<simple_controller>().enabled = false;
        gameObject.GetComponent<Music_Player_manager>().DeathSoundEvent(); //играем звуковой эффект смерти

        Death_explosion.transform.position = transform.position;
        Car_model.SetActive(false);
        Flares.SetActive(false);
        Death_explosion.GetComponent<ParticleSystem>().Emit(500);
        Death_explosion.GetComponent<ParticleSystem>().Stop();
        int score = PlayerPrefs.GetInt("Score", 0);
        if (score< gameObject.GetComponent<Score>().score_res)
        {
            PlayerPrefs.SetInt("Score", gameObject.GetComponent<Score>().score_res);
            PlayerPrefs.Save();
        }
        gameObject.GetComponent<Score>().enabled = false;

       
        
        Camera.main.gameObject.GetComponent<Grayscale>().enabled = true;
        After_Death_UI.SetActive(true);
        foreach(GameObject controll_button in Controll_UI_buttons)
        {
            controll_button.SetActive(false);
        }
        /*foreach (GameObject game_ui in After_Death_UI_buttons)
        {
            Vector3 posit = game_ui.GetComponent<RectTransform>().localPosition;
            game_ui.GetComponent<RectTransform>().localPosition = new Vector3(posit.x + 10000, posit.y, posit.z);
        }
        foreach (GameObject game_ui in After_Death_UI_text)
        {
            game_ui.GetComponent<RectTransform>().position = new Vector3(game_ui.GetComponent<RectTransform>().position.x + 10000, game_ui.GetComponent<RectTransform>().position.y, game_ui.GetComponent<RectTransform>().position.z);
        }*/

    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void Menu_exit()
    {
        //Debug.Log("dsfds");
        SceneManager.LoadScene("main_menu", LoadSceneMode.Single);
    }

   
}
