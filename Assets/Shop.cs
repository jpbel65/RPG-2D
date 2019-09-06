using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script pour quiter le menu du shop
public class Shop : MonoBehaviour
{
    public static bool GameInShop = false;

    public GameObject ShopMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("backspace") && Shop.GameInShop)
        {
            ShopMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameInShop = false;
        }
    }

    void Talk()
    {
        ShopMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameInShop = true;
    }

}
