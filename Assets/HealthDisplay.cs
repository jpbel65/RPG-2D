using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    int timeCount = -1;
    bool dmg = false;

    public int health = 40;
    public int maxHealth = 80;

    public Image[] hearts;//images des coeurs
    public Sprite emptyHeart;//coeur vide
    public Sprite QHeart;//quart de coeur
    public Sprite halfHeart;//demi coeur
    public Sprite TQHeart;//3 quart de coeur
    public Sprite life;//ceour plein

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health/4)
            {
                hearts[i].sprite = life;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            int reste = health % 4;
            if (reste != 0)//gestion pour le dernier coeur 
            {
                switch (reste)
                {
                    case 1:
                        hearts[health / 4].sprite = QHeart;
                        break;
                    case 2:
                        hearts[health / 4].sprite = halfHeart;
                        break;
                    case 3:
                        hearts[health / 4].sprite = TQHeart;
                        break;
                    default:
                        break;
                }
            }
            if (i < maxHealth/4)
            {
                hearts[i].enabled = true;
            }else
            {
                hearts[i].enabled = false;
            }
        }
	}

    void FixedUpdate()
    {
        //debut frame invulnerabilité
        if (dmg == true) timeCount++;
        if (timeCount == 0) GetComponent<SpriteRenderer>().color = new Color(0.5607843f, 0.7884067f, 1, 1);
        if (timeCount == 75)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            dmg = false;
            timeCount = -1;
        }
        //fin frame invulnerabilité
    }

    public void takeDamage ()//player subit des dommages
    {
        if (dmg == false)
        {
            health--;
            dmg = true;
        }
    }

    void RestoreHealth()//restore tout la vie du player
    {
        health = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")//si player touche monstre
        {
            Debug.Log("toucher: ");
            takeDamage();
        }
    }
}
