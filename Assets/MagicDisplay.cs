using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//barre de sort UI
public class MagicDisplay : MonoBehaviour {

    public int Mana;//mana du sort actif
    public int MaxMana;//maximunh mana du sort actif
    public Image actifSpellImage;//sprite du sort actif
    public Image ManaBar;

    int actif_spell = 0;
    List<Sprite> spellName = new List<Sprite>();
    List<int> spellUse = new List<int>();
    List<GameObject> spellObject = new List<GameObject>();
   
    public GameObject Slash;//attack de melee par default

    // Use this for initialization
    void Start () {
        spellName.Add(actifSpellImage.sprite);
        spellUse.Add(Mana);
        spellObject.Add(Slash);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c") && !PauseMenu.GameIsPaused && !Shop.GameInShop )//change de sort
        {
            Debug.Log("switch");
            spellUse[actif_spell] = Mana;
            actif_spell++;
            if (actif_spell >= spellName.Count) actif_spell = 0;
            Mana = spellUse[actif_spell];
            ManaBar.fillAmount = Mana / 100f;
            actifSpellImage.sprite = spellName[actif_spell];
        }
        if (Input.GetKeyDown("x") && !PauseMenu.GameIsPaused && !Shop.GameInShop)//utilise le sort actif
        {
            //debut création de l'angle de tire
            float angle = 0;
            Vector3 vMove = Vector3.down;
            string anim = GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
            if (anim == "c1_right" || anim == "c1_walk_right")
            {
                angle = 90;
                vMove = Vector3.right;
            }
            if (anim == "c1_left" || anim == "c1_walk_left")
            {
                angle = 270;
                vMove = Vector3.left;
            }
            if (anim == "c1_up" || anim == "c1_walk_up")
            {
                angle = 180;
                vMove = Vector3.up;
            }
            //fin création de l'angle de tire
            if (actif_spell == 0)
            {
                Debug.Log("Melee Slash");
                Instantiate(Slash, gameObject.transform.position + (vMove / 2), Quaternion.AngleAxis(angle, Vector3.forward));
            }
            else
            {
                if (Mana < 10) Debug.Log("not enough mana");
                else { 
                    Instantiate(spellObject[actif_spell], gameObject.transform.position + (vMove / 2), Quaternion.AngleAxis(angle, Vector3.forward));
                    Mana = Mana - 10;
                    ManaBar.fillAmount = Mana / 100f;
                }
            }
        }
    }

    void addSpell(ClassSort sort)//ajoute le sort a la liste (grace souvent a reward)
    {
        spellName.Add(sort.get_sprite());
        spellUse.Add(sort.get_mana());
        spellObject.Add(sort.get_gameobject());
    }

    void RestoreMana()//restore tout le mana de la room
    {
        Mana = MaxMana;
        ManaBar.fillAmount = 1f;
        for (int i = 0;i<spellUse.Count;i++)
        {

            spellUse[i] = MaxMana;
        }
    }


}