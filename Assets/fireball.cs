using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 5f;
    float translationY = 0f;
    int timer = 0;
    bool timerGo = false;

    // Start is called before the first frame update
    void Start()
    {
        translationY = -1f * speed;
        Debug.Log(translationY);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "End") Destroy(gameObject);
    }
    void FixedUpdate()
    {
        //Move the GameObject
        if (timerGo == true) timer++;
        if (timer == 5) gameObject.GetComponent<Animator>().SetBool("death", true);
        if (timer < 5) transform.Translate(new Vector3(0, translationY * Time.fixedDeltaTime, 0));

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            Debug.Log("fire touch: "+collision.name);
            timerGo = true;
            collision.SendMessage("Fire");
        }
    }
   
}
