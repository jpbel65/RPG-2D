using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    public static List<stats> obj = new List<stats>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Loot(stats loot)
    {
        obj.Add(loot);
        Debug.Log(obj.Count);
    }

}
