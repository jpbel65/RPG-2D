using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    GameObject player;
    Vector3 distanceSlashPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distanceSlashPlayer = gameObject.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "end") Destroy(gameObject);
        gameObject.transform.position = player.transform.position + distanceSlashPlayer;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            Debug.Log("slash touch: " + collision.name);
            collision.gameObject.SendMessage("TakeDamage", Inventory.force / 2);//les instance de slash touche 2 fois les monstres
        }
    }
}
