using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGear : MonoBehaviour
{
    RotateStart rotateStart;
    RotateRoom rotateRoom;
    private GameObject room;

    public enum derectionType
    {
        LeftOnly,
        RightOnly
    };

    public derectionType derection;
    
    // Start is called before the first frame update
    void Start()
    {
        room = GameObject.Find("Room");
        rotateRoom = room.GetComponent<RotateRoom>();
        rotateStart = GetComponent<RotateStart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (derection == derectionType.LeftOnly)
        {
            if (rotateStart.botton_flg == false)
            {
                
            }
        }
        if (derection == derectionType.RightOnly)
        {
            if (rotateStart.botton_flg == false)
            {

            }
        }
    }
}
