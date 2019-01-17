using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour {

    SpriteRenderer m_SpriteRenderer;
    int timeCount = 0;
    bool dmg = false;

    public ClassSort Sort;
    // Use this for initialization
    void Start () {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
       
    }
	
	// Update is called once per frame
	void Update () {
      
    }

    void FixedUpdate()
    {
        
        if (timeCount  == 1 ) m_SpriteRenderer.color = new Color(1, 0.561f, 0.584f, 1);
        if (timeCount == 11) m_SpriteRenderer.color = new Color(1, 1, 1, 1);
        if (dmg == true) timeCount++;
        if (timeCount == 12)
        {
            dmg = false;
            timeCount = 0;
        }
    }

    public void Talk ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        print("salut, je suis "+gameObject.name+" -1 de vie");
        player.SendMessage("takeDamage");
    }

    public void Fire ()
    {
        Debug.Log("Wouah une boule de feu!");
        GetComponent<Animator>().SetBool("lol", true);
        dmg = true;
    }

    public void Reward (GameObject cible)
    {
        Debug.Log("rewerd");
        cible.SendMessage("addSpell", Sort);
    }
}
