using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipement : MonoBehaviour
{
    public Sprite[] SlotEquip;
    public Sprite Border;
    Image[] Equip;
    public Image[] Inventaire;
    int current = 0;
    public Text Desc;
    Image[] All;
    stats[] EquipStats = new stats[12];
    // Start is called before the first frame update

    void Start()
    {
        Equip = gameObject.GetComponentsInChildren<Image>(true);

        All = new Image[Equip.Length + Inventaire.Length];
        Equip.CopyTo(All, 0);
        Inventaire.CopyTo(All, Equip.Length);
        text();
    }

    // Update is called once per frame
    void Update()
    {
        text();
        for(int i = 0;i < Inventaire.Length; i++)
        {
            if (i < Inventory.obj.Count) Inventaire[i].sprite = Inventory.obj[i].get_sprite();
            else Inventaire[i].sprite = Border;
        }

        if (Input.GetKeyDown("down"))
        {
            if (current >= 12)
            {
                All[current].color = new Color(1, 1, 1, 1);
                current += 13;
                if (current > 50) current -= 13;
                All[current].color = new Color(0, 1, 0, 1);
            }
            if (current < 12)
            {
                All[current].color = new Color(1, 1, 1, 1);
                current += 4;
                All[current].color = new Color(0, 1, 0, 1);
            }
            
        }
        if (Input.GetKeyDown("up"))
        {
            if (current < 16)
            {
                All[current].color = new Color(1, 1, 1, 1);
                current -= 4;
                if (current < 0) current += 4;
                All[current].color = new Color(0, 1, 0, 1);
            }
            if (current >= 16 && current < 25)
            {
                All[current].color = new Color(1, 1, 1, 1);
                current = 11;
                All[current].color = new Color(0, 1, 0, 1);
            }
            if(current >= 25)
            {
                All[current].color = new Color(1, 1, 1, 1);
                current -= 13;
                All[current].color = new Color(0, 1, 0, 1);
            }
            
        }
        if (Input.GetKeyDown("left"))
        {
            All[current].color = new Color(1, 1, 1, 1);
            current -= 1;
            if (current < 0) current += 1;
            All[current].color = new Color(0, 1, 0, 1);
            

        }
        if (Input.GetKeyDown("right"))
        {
            All[current].color = new Color(1, 1, 1, 1);
            current += 1;
            if (current > 50) current -= 1;
            All[current].color = new Color(0, 1, 0, 1);
            
        }
        if (Input.GetKeyDown("x") && PauseMenu.GameIsPaused == true)
        {
            if (current < 12)
            {
                if (EquipStats[current] != null)
                {
                    Inventory.obj.Add(EquipStats[current]);
                    Equip[current].sprite = SlotEquip[current];
                    EquipStats[current] = null;
                }
                
            }
            else
            {
                if (EquipStats[Inventory.obj[current - 12].get_Pos_Equip()] != null)
                {
                    Inventory.obj.Add(EquipStats[Inventory.obj[current - 12].get_Pos_Equip()]);
                }
                Equip[Inventory.obj[current - 12].get_Pos_Equip()].sprite = All[current].sprite;
                EquipStats[Inventory.obj[current - 12].get_Pos_Equip()] = Inventory.obj[current - 12];
                Inventory.obj.Remove(Inventory.obj[current - 12]);
            }
        }
        
        
    }

    void OnDisable()
    {
        All[current].color = new Color(1, 1, 1, 1);
        current = 0;
        All[current].color = new Color(0, 1, 0, 1);
    }

    void text()
    {
        try
        {
            if (current < 12)
            {
                Desc.text = EquipStats[current].get_desc();
            }
            if (current >= 12)
            {
                Desc.text = Inventory.obj[current - 12].get_desc();
            }
        }
        catch 
        {
            Desc.text = "Empty";
        }
    }

}
