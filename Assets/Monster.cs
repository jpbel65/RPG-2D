using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour
{
    public GameObject Loot_Blanc;
    public GameObject Loot_Vert;
    public GameObject Loot_Bleu;
    public GameObject LifeBar;
    public GameObject Bar;
    public float Life = 100;

    float maxLife;
    //Random rng = new Random();
    // Start is called before the first frame update
    void Start()
    {
        maxLife = Life;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        Life -= 50;//fire ball font 50
        if (Bar.activeSelf == false) Bar.SetActive(true);
        LifeBar.transform.Translate(new Vector3(-0.30f,0,0));//-0.1 car en 2 coup elle meurt
        if (Life <= 0f)
        {
            Died();
        }
    }

    void TakeDamage(float dg)
    {
        Life -= dg;
        if (Bar.activeSelf == false) Bar.SetActive(true);
        float move = (dg / maxLife) * 1.2f;
        Debug.Log(move);
        LifeBar.transform.Translate(new Vector3(-move, 0, 0));//les healthbar on 0.6 de taille
        if (Life <= 0f)
        {
            Died();
        }
    }

    void Died()
    {
        Debug.Log(gameObject.name + " Died");
        float rng = Random.value;
        Debug.Log(rng);
        if (rng < 0.45) Instantiate(Loot_Blanc, gameObject.transform.position, gameObject.transform.rotation);
        if (rng >= 0.45 && rng < 0.7) Instantiate(Loot_Vert, gameObject.transform.position, gameObject.transform.rotation);
        if (rng >= 0.7) Instantiate(Loot_Bleu, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

}
