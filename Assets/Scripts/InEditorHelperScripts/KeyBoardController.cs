using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : MonoBehaviour
{
    /// <summary>
    /// вспомогательный скрипт для реактора, чтобы управлять без мышки
    /// </summary>

    simple_controller playerController;
    void Start()
    {
        playerController = gameObject.GetComponent<simple_controller>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerController.left_start();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerController.left_stop();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerController.right_start();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerController.right_stop();
        }
    }
}
