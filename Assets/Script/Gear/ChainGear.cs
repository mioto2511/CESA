using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGear : MonoBehaviour
{
    RotateStart rotateStart;
    RotateRoom rotateRoom;
    private GameObject room;
    private GameObject parent;

    public enum DerectionType
    {
        LeftOnly,
        RightOnly,
        Neutral
    };

    public DerectionType derection;
    
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
        parent = transform.root.gameObject;
        
        if(parent.name == "Room")
        {
            if (derection == DerectionType.LeftOnly)
            {
                Debug.Log("R");
                rotateRoom.dtype = 0;
            }
            else if (derection == DerectionType.LeftOnly)
            {
                Debug.Log("L");
                rotateRoom.dtype = 1;
            }
        }

        if(rotateRoom.room_hit && parent.name == "Room")
        {
            derection = DerectionType.Neutral;
            rotateRoom.dtype = 2;
        }
    }
}
