using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps_spawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Spike_prefab;
    public GameObject Lazer_prefab;
 

    [HideInInspector]
    public List<GameObject> Spikes = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> Lazers = new List<GameObject>();
    public GameObject Player;
    [HideInInspector]
    public Plate_individual_array plate_array;

    int i_spike_mod = 0; //mod spikes_count for spiek array


    int[] Spike_lines_id;
    public Plate_generator plate_script;
    List<GameObject> Plate_Lines = new List<GameObject>();

    [HideInInspector]

    void Start()
    {
        plate_script = Player.GetComponent<Plate_generator>();
        Plate_Lines = plate_script.Plate_Lines;
        Spike_lines_id = new int[50];
        for (int i = 0; i < 50; i++)
        {
            Spike_lines_id[i] = -1;
            GameObject spike = Instantiate(Spike_prefab, new Vector3(-100, -100, -100), Quaternion.identity);
            Spikes.Add(spike);
            GameObject lazer = Instantiate(Lazer_prefab, new Vector3(-100, -100, -100), Quaternion.identity);
            Lazers.Add(lazer);
        }

        //Spikes[10].transform.position = Plate_Lines[5].GetComponent<Plate_individual_array>().plates[3].transform.position;
    }

    // Update is called once per frame

    public void Respawn_spikes(GameObject plate)
    {

        Plate_individual_array plate_array_loc = plate.GetComponent<Plate_individual_array>();
        for (int i = 0; i < plate_array_loc.plates.Count; i++)
        {
            if (i_spike_mod > Spikes.Count - 1)
            {
                i_spike_mod = 0;
            }

            if (Random.Range(0, 20) == 13)
            {
                Spike_lines_id[i_spike_mod] = i;//save column position for soike;
                Spikes[i_spike_mod].transform.position = new Vector3(plate_array_loc.plates[i].transform.position.x, plate_array_loc.plates[i].transform.position.y - 10, plate_array_loc.plates[i].transform.position.z);
                i_spike_mod++;
            }
        }
    }


    public void Loop()
    {
        for (int i = 0; i < Spikes.Count; i++)
        {
            Spikes[i].transform.position = new Vector3(Spikes[i].transform.position.x, Spikes[i].transform.position.y, Spikes[i].transform.position.z - 100);
        }

    }
    
}
