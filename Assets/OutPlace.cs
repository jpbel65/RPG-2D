using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutPlace : MonoBehaviour
{
    public GameObject Destination;
    public Vector3 Sens;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
            StartCoroutine("MoveIn");
            player.gameObject.transform.position = Destination.transform.position + Sens;
            StartCoroutine("MoveOut");
        }
    }
    IEnumerator MoveIn()
    {
        //Time.timeScale = 0f;
        for (int i = 0; i < 10; i++)
        {
            //Debug.Log(i);
        }
        yield return new WaitForSeconds(3);
        
    }
    IEnumerator MoveOut()
    {
        yield return new WaitForSeconds(1);
        
        for (int i = 0; i < 10; i++)
        {
            //move
        }
        //Time.timeScale = 1f;
    }
}
