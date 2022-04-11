using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    public static RotateRoom instance;
    public int rotate_cnt = 0;

    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    [SerializeField, Tooltip("ターゲットオブジェクト")]
    private GameObject target_object;

    [SerializeField, Tooltip("回転軸")]
    private Vector3 RotateAxis = Vector3.forward;

    [SerializeField, Tooltip("速度係数")]
    private float SpeedFactor = 0.1f;

    //回すか
    public bool rotate_flg = false;

    //何周りか
    public bool right_rotate = false;
    public bool left_rotate = false;

    //部屋同士が当たったか
    public bool room_hit = false;

    private int child_cnt = 0;

    //自身のtf
    Transform my_transform;
    Vector3 my_rotate;

    //AutoPlayerMoveの変数を使う
    AutoPlayerMove auto_player_move;

    //MoveAxisOfRotate
    MoveAxisOfRotate move_axis;

    public float deadzone = 0.2f;
    float start_radian = 0;
    float old_radian = 0;
    bool flg = true;
    public bool connect_flg = false;

    private Vector3 initial_pos;
    //private bool initial_flg = true;

    private GameObject player;
    private GameObject cursor;

    public bool collider_flg = true;

    void Start()
    {
        GameObject obj1 = GameObject.Find("AxisOfRotation"); //オブジェクトを探す
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();　//付いているスクリプトを取得

        player = GameObject.Find("Player"); //オブジェクトを探す
        auto_player_move = player.GetComponent<AutoPlayerMove>();　//付いているスクリプトを取得

        cursor = GameObject.Find("SelectCursor"); //オブジェクトを探す
    }

    void Update()
    {
        // transformを取得Fixed
        my_transform = this.transform;

        ////回転方向の変更
        //if (Input.GetKeyDown("joystick button 5"))//右
        //{
        //    right_rotate = true;
        //    left_rotate = false;
        //    Debug.Log("R");
        //}
        //else if (Input.GetKeyDown("joystick button 4"))//左
        //{
        //    left_rotate = true;
        //    right_rotate = false;
        //    Debug.Log("L");
        //}

        //部屋が当たった
        if (room_hit == true)
        {

            child_cnt++;

            rotate_flg = false;

            if (move_axis.axis_poses.Count >= 2)
            {
                if (initial_pos == this.transform.position)
                {
                    room_hit = false;
                    rotate_flg = true;
                    move_axis.chang_axis = true;
                }
                else if (child_cnt >= this.transform.childCount)
                {
                    room_hit = false;

                    room_hit = false;
                    child_cnt = 0;

                    //回転方向の初期化
                    left_rotate = false;
                    right_rotate = false;

                    Invoke("DelayMethod", 0.1f);

                    //プレイヤーを起動
                    auto_player_move.move_flg = true;

                    //カーソル復活           
                    cursor.SetActive(true);

                    move_axis.delete_list = true;

                    Vector3 player_pos = player.transform.position;
                    cursor.transform.position = player_pos;

                    start_radian = 0;
                    old_radian = 0;
                    flg = true;

                    //歯車のコライダーON
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
                    foreach (GameObject num in objects)
                    {
                        var colliderTest = num.GetComponent<Collider2D>();
                        colliderTest.enabled = true;
                    }
                    objects = GameObject.FindGameObjectsWithTag("RGear");
                    foreach (GameObject num in objects)
                    {
                        var colliderTest = num.GetComponent<Collider2D>();
                        colliderTest.enabled = true;
                    }

                    //カーソルのタグ変更
                    //GameObject obj = GameObject.Find("SelectCursor"); //オブジェクトを探す
                    //obj.tag = "Cursor";

                }
            }
            else
            {
                if (child_cnt >= this.transform.childCount)
                {
                    room_hit = false;

                    room_hit = false;
                    child_cnt = 0;

                    //回転方向の初期化
                    left_rotate = false;
                    right_rotate = false;

                    Invoke("DelayMethod", 0.5f);

                    //プレイヤーを起動
                    auto_player_move.move_flg = true;

                    //カーソル復活           
                    cursor.SetActive(true);

                    move_axis.delete_list = true;

                    Vector3 player_pos = player.transform.position;
                    cursor.transform.position = player_pos;

                    start_radian = 0;
                    old_radian = 0;
                    flg = true;

                    //歯車のコライダーON
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("LGear");
                    foreach (GameObject num in objects)
                    {
                        var colliderTest = num.GetComponent<Collider2D>();
                        colliderTest.enabled = true;
                    }
                    objects = GameObject.FindGameObjectsWithTag("RGear");
                    foreach (GameObject num in objects)
                    {
                        var colliderTest = num.GetComponent<Collider2D>();
                        colliderTest.enabled = true;
                    }

                    //カーソルのタグ変更
                    //GameObject obj = GameObject.Find("SelectCursor"); //オブジェクトを探す
                    //obj.tag = "Cursor";

                }

            }

            
        }
        if (rotate_flg == true)
        {

            float lsh = Input.GetAxis("L_Stick_H");//横軸
            float lsv = Input.GetAxis("L_Stick_V");//縦軸
                                                   //ステックの角度産出
            float radian = Mathf.Atan2(lsv, lsh) * Mathf.Rad2Deg;
            if (radian < 0)
            {
                radian += 360;
            }

            if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
            {
                if (flg)
                {
                    flg = false;
                    start_radian = radian;
                    //goal_radian = start_radian+
                    initial_pos = this.transform.position;
                    Debug.Log(initial_pos);
                }


                //else if (initial_pos == this.transform.position && room_hit == true)
                //{
                //}


                //初期位置かつ一度動いた
                //if (initial_pos == this.transform.position && initial_flg == false)
                //{
                //    Debug.Log("a");
                //    move_axis.chang_axis = true;
                //}

                //if (initial_pos != this.transform.position)
                //{
                //    initial_flg = false;
                //}

                if (left_rotate == false && right_rotate == false)
                {
                    float now_radian = start_radian - radian;

                    if (old_radian >= 0 &&now_radian<-200)
                    {
                        now_radian += 360;
                    }
                    else if (old_radian <= 0 && now_radian > 200)
                    {
                        now_radian -= 360;
                    }

                    if (now_radian >= 90)
                    {
                        right_rotate = true;
                    }
                    else if (now_radian <= -90)
                    {
                        //move_axis.chang_axis = true;
                        left_rotate = true;
                    }
                    Debug.Log(now_radian);
                    //保存
                    old_radian = now_radian;
                }
            }
        }
    }

    void FixedUpdate()
    {
        

        //if (connect_flg)
        //{
        //    connect_flg = false;

        //    rotate_flg = false;

            
        //}

        // 指定オブジェクトを中心に回転する
        if (rotate_flg == true)
        {
            if (right_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / -SpeedFactor) * Time.deltaTime
                );
            }
            else if (left_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / SpeedFactor) * Time.deltaTime
                );
            }

            //float lsh = Input.GetAxis("L_Stick_H");//横軸
            //float lsv = Input.GetAxis("L_Stick_V");//縦軸
            ////ステックの角度産出
            //float radian = Mathf.Atan2(lsv, lsh) * Mathf.Rad2Deg;
            //if (radian < 0)
            //{
            //    radian += 360;
            //}

            //if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
            //{
            //    if (flg)
            //    {
            //        flg = false;
            //        start_radian = radian;
            //        //goal_radian = start_radian+
            //        initial_pos = this.transform.position;
            //    }

                
            //    //else if (initial_pos == this.transform.position && room_hit == true)
            //    //{
            //    //}
                

            //    //初期位置かつ一度動いた
            //    if (initial_pos == this.transform.position && initial_flg == false)
            //    {
            //        Debug.Log("a");
            //        move_axis.chang_axis = true;
            //    }

            //    if (initial_pos != this.transform.position)
            //    {
            //        initial_flg = false;
            //    }

            //    if (left_rotate == false && right_rotate == false)
            //    {
            //        if (start_radian > radian)
            //        {
            //            right_rotate = true;
            //        }
            //        else if (start_radian < radian)
            //        {
            //            //move_axis.chang_axis = true;
            //            left_rotate = true;
            //        }
            //    }

                //if (old_radian > radian)
                //{
                //    this.transform.RotateAround(
                //    target_object.transform.position,
                //    RotateAxis,
                //    360.0f / (1.0f / -SpeedFactor) * Time.deltaTime
                //    );

                //    old_radian = radian;
                //}
                //else if (old_radian < radian)
                //{
                //    this.transform.RotateAround(
                //    target_object.transform.position,
                //    RotateAxis,
                //    360.0f / (1.0f / SpeedFactor) * Time.deltaTime
                //    );

                //    old_radian = radian;
                //}
            //}


            //now_radian = radian;

            //float speed = old_radian - now_radian;

            //speed = -speed;

            //if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
            //{
            //    this.transform.RotateAround(
            //            target_object.transform.position,
            //            RotateAxis,
            //            speed
            //            );
            //}

            //if(lsh == 0 && lsv == 0)
            //{
            //    now_radian = 0;
            //}

            //old_radian = radian;

            
        }       
    }

    private void DelayMethod()
    {
        collider_flg = true;
    }
}
