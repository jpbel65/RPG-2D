using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//objet que les monstre laisse tomber
public class Loot : MonoBehaviour
{
    public stats Stats;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log(collision.name+" ramase le "+gameObject.name);
            collision.SendMessage("Loot", Stats);//ajoute objet a l'inventaire du player
            Destroy(gameObject);
        }
    }
}

[System.Serializable]
public struct keyValue
{
    public string key;
    public float value;
}

//stats de l'objet
[System.Serializable]
public class stats
{
    public Sprite m_sprite;
    public int m_Pos_Equip;
    public string m_desc;
    public List<keyValue> m_bonusGear;

    public stats(Sprite p_sprite, int p_Pos_Equip, string p_desc, List<keyValue> p_bonusGear)
    {
        m_sprite = p_sprite;
        m_Pos_Equip = p_Pos_Equip;
        m_desc = p_desc;
        m_bonusGear = p_bonusGear;

    }

    public int get_Pos_Equip()
    {
        return m_Pos_Equip;
    }

    public Sprite get_sprite()
    {
        return m_sprite;
    }

    public string get_desc()
    {
        return m_desc;
    }
}
