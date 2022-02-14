using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPostion : MonoBehaviour
{
    //カーソルの位置用
    private enum POSITION
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

    //カーソルの位置用
    public struct POSITION_DATA
    {
        public float x;
        public float y;

        public POSITION_DATA(float p1, float p2)
        {
            this.x = p1;
            this.y = p2;
        }
    };

    //構造体初期化
    private POSITION_DATA[] position_data = {
        new POSITION_DATA(0,0),
        new POSITION_DATA(0,0),
        new POSITION_DATA(0,0),
        new POSITION_DATA(0,0),
        new POSITION_DATA(0,0),
        new POSITION_DATA(0,0),
        new POSITION_DATA(0,0),
        new POSITION_DATA(0,0),
    };

    private Transform myTransform;
    private Vector3 pos;

    //SelectCollisionの変数を使う
    SelectCollision select_collision;

    // Start is called before the first frame update
    void Start()
    {
        // transformを取得
        myTransform = this.transform;

        //vector3に変換
        pos = myTransform.position;

        pos.y += 1.0f;

        for (int i = 0; i < 8; i++)
        {
            if (i == (int)POSITION.NORTH)
            {
                position_data[(int)POSITION.NORTH].x = pos.x;
                position_data[(int)POSITION.NORTH].y = pos.y;
            }
            else if (i == (int)POSITION.EAST)
            {
                position_data[(int)POSITION.EAST].x = pos.x + 1.0f;
                position_data[(int)POSITION.EAST].y = pos.y - 1.0f;
            }
            else if (i == (int)POSITION.WEST)
            {
                position_data[(int)POSITION.WEST].x = pos.x - 1.0f;
                position_data[(int)POSITION.WEST].y = pos.y - 1.0f;
            }
            else if (i == (int)POSITION.SOUTH)
            {
                position_data[(int)POSITION.SOUTH].x = pos.x;
                position_data[(int)POSITION.SOUTH].y = pos.y - 2.0f;
            }
            else if (i == (int)POSITION.NORTHEAST)
            {
                position_data[(int)POSITION.NORTHEAST].x = pos.x + 0.7f;
                position_data[(int)POSITION.NORTHEAST].y = pos.y - 0.3f;
            }
            else if (i == (int)POSITION.NORTHWEST)
            {
                position_data[(int)POSITION.NORTHWEST].x = pos.x - 0.7f;
                position_data[(int)POSITION.NORTHWEST].y = pos.y - 0.3f;
            }

            else if (i == (int)POSITION.SOUTHEAST)
            {
                position_data[(int)POSITION.SOUTHEAST].x = pos.x + 0.7f;
                position_data[(int)POSITION.SOUTHEAST].y = pos.y - 1.7f;
            }
            else if (i == (int)POSITION.SOUTHWEST)
            {
                position_data[(int)POSITION.SOUTHWEST].x = pos.x - 0.7f;
                position_data[(int)POSITION.SOUTHWEST].y = pos.y - 1.7f;
            }
        }

        pos.x = position_data[(int)POSITION.NORTH].x;
        pos.y = position_data[(int)POSITION.NORTH].y;

        myTransform.position = pos;  // 座標を設定
    }

    // Update is called once per frame
    void Update()
    {
        select_collision = GetComponent<SelectCollision>();

        float lsh = Input.GetAxis("L_Stick_H");//横軸
        float lsv = Input.GetAxis("L_Stick_V");//縦軸

        //ステックが倒れている
        if ((lsv >= 0.5f) || (lsv <= -0.5f) || (lsh >= 0.5f) || (lsh <= -0.5f))
        {
            //ステックの角度産出
            float radian = Mathf.Atan2(lsv, lsh) * Mathf.Rad2Deg;

            if (radian < 0)
            {
                radian += 360;
            }

            //座標代入
            if (radian == 0)
            {
                pos.x = position_data[(int)POSITION.EAST].x;
                pos.y = position_data[(int)POSITION.EAST].y;
            }
            else if (radian == 180)
            {
                pos.x = position_data[(int)POSITION.WEST].x;
                pos.y = position_data[(int)POSITION.WEST].y;
            }
            else if (radian == 270)
            {
                pos.x = position_data[(int)POSITION.SOUTH].x;
                pos.y = position_data[(int)POSITION.SOUTH].y;
            }
            else if (radian == 90)
            {
                pos.x = position_data[(int)POSITION.NORTH].x;
                pos.y = position_data[(int)POSITION.NORTH].y;
            }
            else if ((radian >= 22) && (radian <= 68))
            {
                pos.x = position_data[(int)POSITION.NORTHEAST].x;
                pos.y = position_data[(int)POSITION.NORTHEAST].y;
            }
            else if ((radian >= 112) && (radian <= 158))
            {
                pos.x = position_data[(int)POSITION.NORTHWEST].x;
                pos.y = position_data[(int)POSITION.NORTHWEST].y;
            }
            else if ((radian >= 292) && (radian <= 338))
            {
                pos.x = position_data[(int)POSITION.SOUTHEAST].x;
                pos.y = position_data[(int)POSITION.SOUTHEAST].y;
            }
            else if ((radian >= 202) && (radian <= 248))
            {
                pos.x = position_data[(int)POSITION.SOUTHWEST].x;
                pos.y = position_data[(int)POSITION.SOUTHWEST].y;
            }
        }

        myTransform.position = pos;  // 座標を設定
    }
}
