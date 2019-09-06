using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//respawn des monstres
public class Respawn : MonoBehaviour
{
    GameObject[] Spawner;
    public List<GameObject> Monsters;//list de tous les monstres possible

    
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
        if (collision.gameObject.name == "Player")
        {
            Spawner = GameObject.FindGameObjectsWithTag("Respawn");

            foreach(GameObject item in Spawner)
            {
                GameObject Monster =  Monsters.Find(x => item.name.Contains(x.name));
                Debug.Log(Monster.name);
                Debug.Log(item.name);
                if(Monster.tag == "Monster")
                {
                    Instantiate(Monster, item.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
