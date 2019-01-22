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
    Bounds Edge = new Bounds();
    GameObject player;
    float MX = 0;
    float MY = 0;
    Vector3 DiffPos;
    
    //Random rng = new Random();
    // Start is called before the first frame update
    void Start()
    {
        maxLife = Life;
        Edge.center = gameObject.transform.position;
        Edge.extents = new Vector3(4, 4, 0);
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("posPlayer ="+ player.transform.position+" /posCBounds: "+Edge.center+" extend: "+Edge.extents);
    }

    // Update is called once per frame
    void Update()
    {
        Edge.center = gameObject.transform.position;
        DiffPos = gameObject.transform.position - player.transform.position;
        if (DiffPos.x > 0f) MX = -1.3f;
        if (DiffPos.x < 0f) MX = 1.3f;
        if (DiffPos.y > 0f) MY = -1.3f;
        if (DiffPos.y < 0f) MY = 1.3f;

    }

    void FixedUpdate()
    {
        if (Edge.Contains(player.transform.position))
        {
            Debug.Log("diffpos: "+DiffPos);
            transform.Translate(new Vector3(MX * Time.fixedDeltaTime, MY * Time.fixedDeltaTime, 0));
        }
    }

    void Fire()
    {
        Life -= 25;//fire ball font 50 double hit
        if (Bar.activeSelf == false) Bar.SetActive(true);
        float move = (25 / maxLife) * 1.2f;
        Debug.Log(move);
        LifeBar.transform.Translate(new Vector3(-move, 0, 0));//les healthbar on 0.6 de taille
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
