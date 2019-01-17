using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    int timeCount = -1;
    bool dmg = false;

    public int health = 40;
    public int maxHealth = 80;

    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite QHeart;
    public Sprite halfHeart;
    public Sprite TQHeart;
    public Sprite life;

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
            if (reste != 0)
            {
                switch (reste)
                {
                    case 1:
                        hearts[health/4].sprite = QHeart;
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
        if (dmg == true) timeCount++;
        if (timeCount == 0) GetComponent<SpriteRenderer>().color = new Color(0.5607843f, 0.7884067f, 1, 1);
        if (timeCount == 50)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            dmg = false;
            timeCount = -1;
        }
    }

    public void takeDamage ()
    {
        if (dmg == false)
        {
            health--;
            dmg = true;
        }
    }

    void RestoreHealth()
    {
        health = maxHealth;
    }
}
