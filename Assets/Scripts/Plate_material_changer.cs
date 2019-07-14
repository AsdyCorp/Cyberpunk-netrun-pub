using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate_material_changer : MonoBehaviour
{
    public Material Unselected_mat;
    public Material Selected_mat;
    [HideInInspector]
    public Plate_individual_array plate_array;

    void Start()
    {
        plate_array = gameObject.GetComponent<Plate_individual_array>();

    }
    public void Select_grid(int i)
    {
       
        foreach( GameObject plate in plate_array.plates)
        {
            
                plate.GetComponent<MeshRenderer>().material = Unselected_mat;
            
        }
        plate_array.plates[i].GetComponent<MeshRenderer>().material = Selected_mat;
    }


}
