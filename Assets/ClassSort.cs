using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClassSort
{
    public Sprite m_sprite;
    public int m_mana;
    public GameObject m_sort;
    


    public ClassSort(Sprite p_sprite, int p_mana, GameObject p_sort)
    {
        m_sprite = p_sprite;
        m_mana = p_mana;
        m_sort = p_sort;
        
    }

    public int get_mana()
    {
        return m_mana;
    }

    public Sprite get_sprite()
    {
        return m_sprite;
    }

    public GameObject get_gameobject()
    {
        return m_sort;
    }

}
