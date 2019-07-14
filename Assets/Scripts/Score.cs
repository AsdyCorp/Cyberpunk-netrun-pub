using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour
{
    public GameObject Score_obj;
    UnityEngine.UI.Text Gui_Text_element;
    public int score_res;
    void Start()
    {
        Gui_Text_element = Score_obj.GetComponent<UnityEngine.UI.Text>();
    }
    void FixedUpdate()
    {
        score_res += 1;
        Gui_Text_element.text = "" + score_res;
    }
}
