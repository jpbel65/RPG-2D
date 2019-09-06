using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objet Sort

[System.Serializable]
public class ClassSort
{
    public Sprite m_sprite;//Image du sort dans le UI
    public int m_mana;//Mana du sort, nombre de charge
    public GameObject m_sort;//GameObect qui est le sort dans la scéne
    

    //constructeur
    public ClassSort(Sprite p_sprite, int p_mana, GameObject p_sort)
    {
        m_sprite = p_sprite;
        m_mana = p_mana;
        m_sort = p_sort;
        
    }
    //getter
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
