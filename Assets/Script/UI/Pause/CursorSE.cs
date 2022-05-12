using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorSE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this != EventSystem.current.currentSelectedGameObject)
        {
            //this = EventSystem.current.currentSelectedGameObject;

        }
    }
}
