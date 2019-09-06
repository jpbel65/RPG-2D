using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Détuit tout les monstre encore en vie
public class Despawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject[] Monsters =  GameObject.FindGameObjectsWithTag("Monster");
            foreach(GameObject Monster in Monsters)
            {
                Destroy(Monster);
            }
        }
    }
}
