using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//equipement du personnage
public class Equipement : MonoBehaviour
{
    public Sprite[] SlotEquip;//nombre de slot
    public Sprite Border;//Sprite pour les emplacements vide
    Image[] Equip;//Image pour les élément équipé
    public Image[] Inventaire;//Image pour les élément dans l'inventaire
    int selected_item = 0;//numero de item qui est selectionner
    public Text Desc;//le texte de l'objet selectionner
    Image[] items_player;//array contenant tout les items du player
    stats[] EquipStats = new stats[12];//array qui contient les statistique des 12 items équiper
    // Start is called before the first frame update

    void Start()
    {
        Equip = gameObject.GetComponentsInChildren<Image>(true);

        items_player = new Image[Equip.Length + Inventaire.Length];//construit items_player
        Equip.CopyTo(items_player, 0);
        Inventaire.CopyTo(items_player, Equip.Length);
        text();//affiche le text de l'objet 0
    }

    // Update is called once per frame
    void Update()
    {
        text();
        for(int i = 0;i < Inventaire.Length; i++)//met a jour les sprete des objet de l'inventaire
        {
            if (i < Inventory.obj.Count) Inventaire[i].sprite = Inventory.obj[i].get_sprite();
            else Inventaire[i].sprite = Border;
        }

        if (Input.GetKeyDown("down"))//descend une ligne pour selectionner objet
        {
            if (selected_item >= 12)
            {
                items_player[selected_item].color = new Color(1, 1, 1, 1);
                selected_item += 13;
                if (selected_item > 50) selected_item -= 13;
                items_player[selected_item].color = new Color(0, 1, 0, 1);
            }
            if (selected_item < 12)
            {
                items_player[selected_item].color = new Color(1, 1, 1, 1);
                selected_item += 4;
                items_player[selected_item].color = new Color(0, 1, 0, 1);
            }
            
        }
        if (Input.GetKeyDown("up"))//monter une ligne pour selectionner objet
        {
            if (selected_item < 16)
            {
                items_player[selected_item].color = new Color(1, 1, 1, 1);
                selected_item -= 4;
                if (selected_item < 0) selected_item += 4;
                items_player[selected_item].color = new Color(0, 1, 0, 1);
            }
            if (selected_item >= 16 && selected_item < 25)
            {
                items_player[selected_item].color = new Color(1, 1, 1, 1);
                selected_item = 11;
                items_player[selected_item].color = new Color(0, 1, 0, 1);
            }
            if(selected_item >= 25)
            {
                items_player[selected_item].color = new Color(1, 1, 1, 1);
                selected_item -= 13;
                items_player[selected_item].color = new Color(0, 1, 0, 1);
            }
            
        }
        if (Input.GetKeyDown("left"))//bouge une case pour selectionner objet
        {
            items_player[selected_item].color = new Color(1, 1, 1, 1);
            selected_item -= 1;
            if (selected_item < 0) selected_item += 1;
            items_player[selected_item].color = new Color(0, 1, 0, 1);
            

        }
        if (Input.GetKeyDown("right"))//bouge une case pour selectionner objet
        {
            items_player[selected_item].color = new Color(1, 1, 1, 1);
            selected_item += 1;
            if (selected_item > 50) selected_item -= 1;
            items_player[selected_item].color = new Color(0, 1, 0, 1);
            
        }
        if (Input.GetKeyDown("x") && PauseMenu.GameIsPaused == true)//équiper ou déséquiper un objet
        {
            if (selected_item < 12)//objet choisit est dans les équiper
            {
                if (EquipStats[selected_item] != null)
                {
                    Inventory.obj.Add(EquipStats[selected_item]);
                    Equip[selected_item].sprite = SlotEquip[selected_item];
                    foreach(keyValue bonus in EquipStats[selected_item].m_bonusGear)
                    {
                        if (bonus.key == "Force") Inventory.force -= bonus.value;
                        if (bonus.key == "Intelligence") Inventory.intelligence -= bonus.value;
                    }
                    EquipStats[selected_item] = null;
                }
                
            }
            else//l'objet est dans l'inventaire
            {
                if (EquipStats[Inventory.obj[selected_item - 12].get_Pos_Equip()] != null)//désequipe l'objet qui utilise la meme que l'objet a équiper
                {
                    Inventory.obj.Add(EquipStats[Inventory.obj[selected_item - 12].get_Pos_Equip()]);
                    foreach (keyValue bonus in EquipStats[Inventory.obj[selected_item - 12].get_Pos_Equip()].m_bonusGear)
                    {
                        if (bonus.key == "Force") Inventory.force -= bonus.value;
                        if (bonus.key == "Intelligence") Inventory.intelligence -= bonus.value;
                    }
                }
                Equip[Inventory.obj[selected_item - 12].get_Pos_Equip()].sprite = items_player[selected_item].sprite;
                EquipStats[Inventory.obj[selected_item - 12].get_Pos_Equip()] = Inventory.obj[selected_item - 12];
                foreach (keyValue bonus in EquipStats[Inventory.obj[selected_item - 12].get_Pos_Equip()].m_bonusGear)
                {
                    if (bonus.key == "Force") Inventory.force += bonus.value;
                    if (bonus.key == "Intelligence") Inventory.intelligence += bonus.value;
                }
                Inventory.obj.Remove(Inventory.obj[selected_item - 12]);
            }
        }
        
        
    }

    void OnDisable()//remet le selected objet a 0
    {
        items_player[selected_item].color = new Color(1, 1, 1, 1);
        selected_item = 0;
        items_player[selected_item].color = new Color(0, 1, 0, 1);
    }

    void text()//affiche le text de l'objet selectionner
    {
        try
        {
            if (selected_item < 12)//0 a 12 item est dans les équiper 
            {
                Desc.text = EquipStats[selected_item].get_desc() + "\n";
                foreach (keyValue bonus in EquipStats[selected_item].m_bonusGear)
                {
                    Desc.text += "\n" +bonus.key+": +"+ bonus.value.ToString();
                }
            }
            if (selected_item >= 12)//plus grand que 12 l'objet est dans l'inventaire
            {
                Desc.text = Inventory.obj[selected_item - 12].get_desc() + "\n";
                foreach (keyValue bonus in Inventory.obj[selected_item - 12].m_bonusGear)
                {
                    Desc.text += "\n" + bonus.key + ": +" + bonus.value.ToString();
                }
            }
        }
        catch //si erreur outOfBound du array qui lever c'est a cause que selected_tem est sur une case vide 
        {
            Desc.text = "Empty";
        }
    }

}
