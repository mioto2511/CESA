using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Localpos : MonoBehaviour
{
    GameObject room;
    RotateRoom rotateRoom;
    public bool Wall_stop = false;
    bool rotate_fix = false;
    Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        room = GameObject.Find("Room");
    }

    // Update is called once per frame
    void Update()
    {
        rotateRoom = room.GetComponent<RotateRoom>();
        if (Wall_stop == false)
        {
            if (rotateRoom.rotate_flg == true)
            {
                if (this.transform.parent == null)
                {
                    this.transform.parent = room.transform;
                    pos = this.transform.localPosition;
                    rotate_fix = true;
                    //Debug.Log(pos);
                }
                else if (this.transform.parent == room.transform)
                {
                    if (rotateRoom.rotate_flg == true)
                    {
                        this.transform.localPosition = pos;
                        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

                    }

                }
            }
            if ((rotateRoom.rotate_flg == false) && (rotate_fix == true))
            {
                this.transform.parent = null;
                rotate_fix = false;

            }
        }



    }
}
