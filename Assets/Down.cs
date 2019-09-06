using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script du NPC qui est une copie du personnage (script de test)
public class Down : MonoBehaviour {

    SpriteRenderer m_SpriteRenderer;
    int timeCount = 0;
    bool dmg = false;

    public ClassSort Sort;//reward d'un sort
    // Use this for initialization
    void Start () {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
       
    }
	
	// Update is called once per frame
	void Update () {
      
    }

    void FixedUpdate()
    {
        //debut gestion de la colour pour la fonction Fire
        if (timeCount  == 1 ) m_SpriteRenderer.color = new Color(1, 0.561f, 0.584f, 1);//debut du changement de couleur
        if (timeCount == 11) m_SpriteRenderer.color = new Color(1, 1, 1, 1);//fin du changement de couleur
        if (dmg == true) timeCount++;
        if (timeCount == 12)//remise a zéro du comteur 
        {
            dmg = false;
            timeCount = 0;
        }
        //fin gestion de la colour pour la fonction Fire
    }

    public void Talk ()//si player parle au NPC
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        print("salut, je suis "+gameObject.name+" -1 de vie");
        player.SendMessage("takeDamage");
    }

    public void Fire ()//si le NPC recoit une boule de feu
    {
        Debug.Log("Wouah une boule de feu!");
        GetComponent<Animator>().SetBool("lol", true);
        dmg = true;
    }

    public void Reward (GameObject cible)//fonction pour les reward lance un addspell a la cible
    {
        Debug.Log("rewerd");
        cible.SendMessage("addSpell", Sort);
    }
}
