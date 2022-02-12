using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPostion : MonoBehaviour
{
    //カーソルの位置用
    enum POSITION
    {
        NORTH,
        NORTHEAST,
        EAST,
        SOUTHEAST,
        SOUTH,
        SOUTHWEST,
        WEST,
        NORTHWEST,
    }

    POSITION position = POSITION.NORTH;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        //vector3に変換
        Vector3 pos = myTransform.position;

        switch (position) {
            case POSITION.NORTH:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    pos.x -= 1;
                    position = POSITION.NORTHWEST;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    pos.x += 1;
                    position = POSITION.NORTHEAST;
                }
                break;

            case POSITION.NORTHEAST:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    pos.x -= 1;
                    position = POSITION.NORTH;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    pos.y -= 1;
                    position = POSITION.EAST;
                }
                break;

            case POSITION.EAST:
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    pos.y += 1;
                    position = POSITION.NORTHEAST;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    pos.y -= 1;
                    position = POSITION.SOUTHEAST;
                }
                break;

            case POSITION.SOUTHEAST:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    pos.x -= 1;
                    position = POSITION.SOUTH;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    pos.y += 1;
                    position = POSITION.EAST;
                }
                break;

            case POSITION.SOUTH:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    pos.x -= 1;
                    position = POSITION.SOUTHWEST;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    pos.x += 1;
                    position = POSITION.SOUTHEAST;
                }
                break;

            case POSITION.SOUTHWEST:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    pos.x += 1;
                    position = POSITION.SOUTH;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    pos.y += 1;
                    position = POSITION.WEST;
                }
                break;

            case POSITION.WEST:
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    pos.y += 1;
                    position = POSITION.NORTHWEST;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    pos.y -= 1;
                    position = POSITION.SOUTHWEST;
                }
                break;

            case POSITION.NORTHWEST:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    pos.x += 1;
                    position = POSITION.NORTH;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    pos.y -= 1;
                    position = POSITION.WEST;
                }
                break;
        }

        Debug.Log(position);


        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    pos.y += 1;
        //}
        //else if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    pos.y -= 1;
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    pos.x -= 1;
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    pos.x += 1;
        //}

        myTransform.position = pos;  // 座標を設定
    }
}
