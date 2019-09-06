using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBut : MonoBehaviour
{
    public GameObject Door;
    private SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Door.SendMessage("ActionBut", gameObject.name);
            SpriteRenderer.enabled = true;
        }
    }
}
