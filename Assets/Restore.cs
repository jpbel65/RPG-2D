﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Talk()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.SendMessage("RestoreHealth");
        player.SendMessage("RestoreMana");
    }
}
