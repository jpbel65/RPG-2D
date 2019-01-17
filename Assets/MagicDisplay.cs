using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicDisplay : MonoBehaviour {

    public int Mana;
    public int MaxMana;
    public Image ActifSpell;
    public Image ManaBar;

    int usedSpell = 0;
    List<Sprite> spellName = new List<Sprite>();
    List<int> spellUse = new List<int>();
    List<GameObject> spellObject = new List<GameObject>();
   
    public GameObject Slash;

    // Use this for initialization
    void Start () {
        spellName.Add(ActifSpell.sprite);
        spellUse.Add(Mana);
        spellObject.Add(Slash);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c") && !PauseMenu.GameIsPaused && !Shop.GameInShop )
        {
            Debug.Log("switch");
            spellUse[usedSpell] = Mana;
            usedSpell++;
            if (usedSpell >= spellName.Count) usedSpell = 0;
            Mana = spellUse[usedSpell];
            ManaBar.fillAmount = Mana / 100f;
            ActifSpell.sprite = spellName[usedSpell];
        }
        if (Input.GetKeyDown("x") && !PauseMenu.GameIsPaused && !Shop.GameInShop)
        {
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

            if (usedSpell == 0)
            {
                Debug.Log("Melee Slash");
                Instantiate(Slash, gameObject.transform.position + (vMove / 2), Quaternion.AngleAxis(angle, Vector3.forward), transform);
            }
            else
            {
                if (Mana < 10) Debug.Log("not enough mana");
                else { 
                    Instantiate(spellObject[usedSpell], gameObject.transform.position + (vMove / 2), Quaternion.AngleAxis(angle, Vector3.forward));
                    Mana = Mana - 10;
                    ManaBar.fillAmount = Mana / 100f;
                }
            }
        }
    }

    void addSpell(ClassSort sort)
    {
        spellName.Add(sort.get_sprite());
        spellUse.Add(sort.get_mana());
        spellObject.Add(sort.get_gameobject());
    }

    void RestoreMana()
    {
        Mana = MaxMana;
        ManaBar.fillAmount = 1f;
        for (int i = 0;i<spellUse.Count;i++)
        {

            spellUse[i] = MaxMana;
        }
    }


}