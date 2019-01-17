using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeMiniBar : MonoBehaviour
{
    public Image Life;
    public GameObject Bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire(GameObject origine)
    {
        Bar.SetActive(true);
        Life.fillAmount -= 0.1f;
    }
}
