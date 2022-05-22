using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    NumDisplay numDisplay;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject n = GameObject.Find("Num");
        //numDisplay = this.GetComponent<NumDisplay>();

        //numDisplay.GenerateUINum(10,0.5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
