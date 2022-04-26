using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGear : MonoBehaviour
{
    RotateStart rotateStart;
    RotateRoom rotateRoom;
    private GameObject room;
    private GameObject parent;

    public enum derectionType
    {
        LeftOnly,
        RightOnly
    };

    public derectionType derection;

    public int dtype;
    
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
        parent = transform.parent.gameObject;
        if (derection == derectionType.LeftOnly)
        {
            if (rotateStart.botton_flg == false && parent.name == "Room")
            {
                dtype = 0;
            }
        }
        if (derection == derectionType.RightOnly)
        {
            if (rotateStart.botton_flg == false && parent.name == "Room")
            {
                dtype = 1;
            }
        }
    }
}
