using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looper : MonoBehaviour
{
    public Transform Player_start_point;
    public Transform Plates_start_point;
    public GameObject Player;
    Plate_generator plate_script;
    Mountains_genereator mountains_script;
    public GameObject dataPacketManager;
    void Start()
    {
        plate_script = Player.GetComponent<Plate_generator>();
        mountains_script = Player.GetComponent<Mountains_genereator>();
    }
    void FixedUpdate()
    {
        if (Player.transform.position.z > 100)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 100);
            ///plates
            foreach (GameObject plate_line in plate_script.Plate_Lines)
            {
                plate_line.transform.position = new Vector3(plate_line.transform.position.x, plate_line.transform.position.y, plate_line.transform.position.z - 100);
            }
            plate_script.plate_pos = new Vector3(plate_script.plate_pos.x, plate_script.plate_pos.y, plate_script.plate_pos.z - 100);
            ///mountains
            foreach (GameObject mountain in mountains_script.Mountains)
            {
                mountain.transform.position = new Vector3(mountain.transform.position.x, mountain.transform.position.y, mountain.transform.position.z - 100);
            }
            mountains_script.mountain_next_point = new Vector3(mountains_script.mountain_next_point.x, mountains_script.mountain_next_point.y, mountains_script.mountain_next_point.z - 100);

            //datapackets
            foreach(Transform child in dataPacketManager.transform)
            {
                child.transform.position = new Vector3(child.transform.position.x, child.transform.position.y, child.transform.position.z - 100);
            }

            Player.GetComponent<Traps_spawn>().Loop();
        }
    }
}
