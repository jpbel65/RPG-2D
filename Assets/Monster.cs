using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class pour les monstres
public class Monster : MonoBehaviour
{
    public GameObject Loot_Blanc;
    public GameObject Loot_Vert;
    public GameObject Loot_Bleu;
    public GameObject LifeBar;
    public GameObject Bar;
    public float Life = 100;

    float maxLife;
    Bounds Edge = new Bounds();//zone d'aggression des monstres
    GameObject player;
    float MX = 0;
    float MY = 0;
    Vector3 DiffPos;
    Animator animator;

    //Random rng = new Random();
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        //savoir la direction que le monstre doit prendre pour s'approcher du player
        if (DiffPos.x > 0f) MX = -1.3f;
        if (DiffPos.x < 0f) MX = 1.3f;
        if (DiffPos.y > 0f) MY = -1.3f;
        if (DiffPos.y < 0f) MY = 1.3f;

        if (Edge.Contains(player.transform.position))
        {
            if (Mathf.Abs(DiffPos.x) >= Mathf.Abs(DiffPos.y))
            {
                if (DiffPos.x > 0f) animator.SetInteger("Move", 4);
                else animator.SetInteger("Move", 2);
            }
            else
            {
                if (DiffPos.y > 0f) animator.SetInteger("Move", 3);
                else animator.SetInteger("Move", 1);
            }
        }
        else animator.SetInteger("Move", 0);
    }

    void FixedUpdate()
    {
        if (Edge.Contains(player.transform.position))
        {
            Debug.Log("diffpos: "+DiffPos);
            transform.Translate(new Vector3(MX * Time.fixedDeltaTime, MY * Time.fixedDeltaTime, 0));
        }
    }

    void Fire(float dg)//fonction appeler par la fireball
    {
        Life -= dg;//fire ball font (double hit)
        if (Bar.activeSelf == false) Bar.SetActive(true);
        float move = (dg / maxLife) * 1.2f;
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
