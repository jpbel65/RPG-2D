using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    public static List<stats> obj = new List<stats>();//list public des objets que le player tient dans sont inventaire
    public static float force = 10;
    public static float intelligence = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p")) Debug.Log(force);
        if (Input.GetKeyDown("o")) Debug.Log(intelligence);
    }

    void Loot(stats loot)//ajoute un objet a la list 
    {
        obj.Add(loot);
        Debug.Log(obj.Count);
    }

   
}
