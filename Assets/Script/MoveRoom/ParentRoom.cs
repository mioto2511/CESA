using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRoom : MonoBehaviour
{
    private GameObject[] ChildObject;

    public bool room_hit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ƒ{ƒ^ƒ“‚ð‰Ÿ‚·‚Æ‰ñ“]
        if (Input.GetKeyDown("joystick button 0"))//‰E‰º
        {
            transform.parent = GameObject.Find("RotateRoom").transform;
        }

        if(room_hit == true)
        {
            this.gameObject.transform.parent = null;
            room_hit = false;
        }

    }

    private void GetAllChildObject()
    {
        ChildObject = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            ChildObject[i] = this.transform.GetChild(i).gameObject;
        }
    }
}
