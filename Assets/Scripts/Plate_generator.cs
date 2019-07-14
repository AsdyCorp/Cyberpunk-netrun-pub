using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate_generator : MonoBehaviour
{
    public GameObject basic_plate;
    public GameObject Pyramid;
    public GameObject Lazer;
    public Transform Start_point;
    public Transform Player;
    [HideInInspector]
    public Vector3 plate_pos;
    [HideInInspector]
    public List<GameObject> Plate_Lines = new List<GameObject>(); 
    void Start()
    {
        plate_pos = Start_point.transform.position;
        for (int i=0; i<50; i++)
        {
            GameObject plate = Instantiate(basic_plate, new Vector3(plate_pos.x,plate_pos.y,plate_pos.z + (i * 0.6f)), Quaternion.identity);
            Plate_Lines.Add(plate);

        }
        plate_pos = Plate_Lines[49].transform.position;
    }

    void FixedUpdate()
    {
        foreach (GameObject plate in Plate_Lines)
        {
            if (plate.transform.position.z + 2 < Player.position.z)
            {
                plate.transform.position = new Vector3(plate.transform.position.x, plate.transform.position.y, plate_pos.z+0.6f);
                plate_pos = plate.transform.position;
                Player.GetComponent<Traps_spawn>().Respawn_spikes(plate);
            }
        }
    }

}
