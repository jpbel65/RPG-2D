using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDoorAnd : MonoBehaviour
{
    bool but1 = false;
    bool but2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (but1 && but2) gameObject.SetActive(false);
    }

    void ActionBut(string name)
    {
        Debug.Log(name);
        if (name == "buttonA") but1 = true;
        if (name == "buttonB") but2 = true;
    }
}
