using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class RotateRoom : MonoBehaviour
{
    //AutoPlayerMoveの変数を使う
    private AutoPlayerMove auto_player_move;
    //MoveAxisOfRotateの変数を使う
    private MoveAxisOfRotate move_axis;
    //RotateStartの変数を使う
    private RotateStart rotate_start;
    //ChainGearを使う
    private ChainGear chain_gear;
    //Accelerationの変数を使う
    private Acceleration acceleration;
    //VibrationScript
    private VibrationScript vibration_script;

    private GoalActive goal_active;

    private HitStop hit_stop;

    public int dtype;

    public static RotateRoom instance;
    public int rotate_cnt = 0;

    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    [Header("ターゲットオブジェクト")] public GameObject target_object;

    [Header("速度係数")] public float SpeedFactor = 0.1f;

    [Header("デットゾーン")] public float deadzone = 0.8f;

    [Header("加速")] public float add_speed = 0.0025f;

    //回転軸
    private Vector3 RotateAxis = Vector3.forward;

    //回すか
    public bool rotate_flg = false;

    //何周りか
    public bool right_rotate = false;
    public bool left_rotate = false;

    //部屋同士が当たったか
    public bool room_hit = false;

    //子のBOXのカウント
    private int child_cnt = 0;

    //自身のtf
    private Transform my_transform;

    //ステックの開始地点
    private float start_radian = 0;

    //ステックの前回角度
    private float old_radian = 0;

    //初期位置フラグ
    private bool initial_flg = true;

    //初期位置
    private Vector3 initial_pos;

    //オブジェクト
    private GameObject player;

    //支点のコライダーフラグ
    public bool collider_flg = true;

    // se
    private int secout;

    //加速分
    private float add = 0;

    public bool start_flg = true;

    // playerのパーティクル
    private Material player_prt;

    void Start()
    {
        rotate_start = this.GetComponent<RotateStart>();//付いているスクリプトを取得
        vibration_script = this.GetComponent<VibrationScript>();

        GameObject obj2 = GameObject.Find("Main Camera");
        hit_stop = obj2.GetComponent <HitStop>();

        GameObject obj3 = GameObject.Find("Goal/DriveGear");
        goal_active = obj3.GetComponent<GoalActive>();

        GameObject obj1 = GameObject.Find("AxisOfRotation"); //オブジェクトを探す
        move_axis = obj1.GetComponent<MoveAxisOfRotate>();　//付いているスクリプトを取得

        GameObject chain = GameObject.Find("DriveGear"); // オブジェクトを探す
        chain_gear = chain.GetComponent<ChainGear>();

        player = GameObject.Find("Player"); //オブジェクトを探す
        auto_player_move = player.GetComponent<AutoPlayerMove>();　//付いているスクリプトを取得
        acceleration = player.GetComponent<Acceleration>();//付いているスクリプトを取得

        // playerについているパーティクル
         // 部屋を回すAbuttonを押したときのパーティクルのマテリアル
        GameObject prt = GameObject.Find("ParticleActive");
        player_prt = prt.GetComponent<Renderer>().material;

        dtype = 2;

        secout=0;
    }

    void Update()
    {
        // transformを取得
        my_transform = this.transform;

        //部屋が当たった
        if (room_hit == true)
        {
            if (start_flg)
            {
                start_flg = false;
                room_hit = false;
            }
            else
            {
                child_cnt++;

                rotate_flg = false;

                //boxの数とカウントが同じか以上なら
                if (child_cnt >= this.transform.childCount)
                {
                    room_hit = false;

                    child_cnt = 0;

                    add = 0;

                    //回転方向の初期化
                    left_rotate = false;
                    right_rotate = false;

                    //遅らせて処理するもの
                    Invoke("DelayMethod", 1.5f);

                    hit_stop.hitstop_flg = true;

                    //プレイヤーを起動
                    auto_player_move.move_flg = true;

                    //配列削除
                    move_axis.Delete();

                    //加速可能にする
                    acceleration.button_flg = true;

                    //振動
                    vibration_script.Vibration(0.8f, 0.8f,0.1f);

                    //回転初期位置の初期化
                    start_radian = 0;
                    old_radian = 0;
                    initial_flg = true;

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
                }
            }

            
        }

        //コントローラーの処理
        StickMove();
    }

    void FixedUpdate()
    {
        //float a= 2;

        //Debug.Log(old_radian);
        // 指定オブジェクトを中心に回転する
        if (rotate_flg == true)
        {
            if (right_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / -(SpeedFactor + add)) * Time.deltaTime
                );

                //this.transform.RotateAround(
                //target_object.transform.position,
                //RotateAxis,
                //360.0f / (1.0f / -SpeedFactor) * Time.deltaTime
                //);
            }
            else if (left_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / (SpeedFactor + add)) * Time.deltaTime
                );
                //this.transform.RotateAround(
                //target_object.transform.position,
                //RotateAxis,
                //360.0f / (1.0f / SpeedFactor) * Time.deltaTime
                //);
            }
        }       
    }

    //コントローラーの処理
    private void StickMove()
    {
        if (rotate_flg == true)
        {
            float lsh = Input.GetAxis("L_Stick_H");//横軸
            float lsv = Input.GetAxis("L_Stick_V");//縦軸

            float now_radian = 0;

            //ステックの角度産出
            float radian = Mathf.Atan2(lsv, lsh) * Mathf.Rad2Deg;
            if (radian < 0)
            {
                radian += 360;
            }

            //スティック入力がはいったら
            if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
            {
                //初期位置の時
                if (initial_flg)
                {
                    initial_flg = false;

                    //スティックの開始角度
                    start_radian = radian;

                    //回転前の初期位置
                    initial_pos = this.transform.position;
                }
                else
                {
                    now_radian = start_radian - radian;


                    //0～360で飛ぶのを改善
                    if (old_radian >= 0 && now_radian < -200)
                    {
                        now_radian += 360;
                    }
                    else if (old_radian <= 0 && now_radian > 200)
                    {
                        now_radian -= 360;
                    }

                    if (now_radian >= 90)
                    {
                        add += add_speed;
                    }
                    if (now_radian <= -90)
                    {
                        add += add_speed;
                    }

                    //Debug.Log(SpeedFactor + add);
                }

                if (left_rotate == false && right_rotate == false)
                {
                    //90度回転したら回転開始
                    if (dtype == 2)
                    {
                        if (now_radian >= 90)
                        {
                            right_rotate = true;

                            //軸決め
                            move_axis.SetAxis(0);

                            // Particleを消滅
                            player_prt.SetFloat("_alpha", 0);
                        }
                        else if (now_radian <= -90)
                        {
                            left_rotate = true;

                            //軸決め
                            move_axis.SetAxis(1);

                            // Particleを消滅
                            player_prt.SetFloat("_alpha", 0);
                        }
                    }
                    else if(dtype <= 1)
                    {
                        if (dtype == 1)
                        {
                            if (now_radian >= -80 && now_radian <= -1)
                            {
                                now_radian = 0;
                            }
                            if (now_radian >= 90)
                            {
                                right_rotate = true;

                                //軸決め
                                move_axis.SetAxis(0);
                            }
                        }
                        if (dtype == 0)
                        {
                            if (now_radian <= 80 && now_radian >= 1)
                            {
                                now_radian = 0;
                            }
                            else if (now_radian <= -90)
                            {
                                left_rotate = true;

                                //軸決め
                                move_axis.SetAxis(1);
                            }
                        }
                    }

                        //保存
                        old_radian = now_radian;
                }
            }
            else if (lsh == 0 && lsv == 0)
            {
                //回転初期位置の初期化
                start_radian = 0;
                old_radian = 0;
                initial_flg = true;
            }
        }
    }

    //遅延処理
    private void DelayMethod()
    {
        //支点のコライダーON
        collider_flg = true;

        if (!goal_active.goal_active)
        {
            //ボタンをふたたび押せる
            rotate_start.botton_flg = true;
        }
        
    }

    private void StickMove2()
    {
        if (rotate_flg)
        {
            float lsh = Input.GetAxis("L_Stick_H");//横軸
            float lsv = Input.GetAxis("L_Stick_V");//縦軸

            //ステックの角度産出
            float radian = Mathf.Atan2(lsv, lsh) * Mathf.Rad2Deg;
            if (radian < 0)
            {
                radian += 360;
            }

            //if (start_radian > 10 && radian > 300)
            //{
            //    radian = -radian;
            //    radian = radian + 360;
            //}

            //スティック入力がはいったら
            if ((lsh > deadzone) || (lsh < -deadzone) || (lsv > deadzone) || (lsv < -deadzone))
            {
                //初期位置の時
                if (initial_flg)
                {
                    initial_flg = false;

                    //スティックの開始角度
                    start_radian = radian;

                    //回転前の初期位置
                    initial_pos = this.transform.position;
                }

                if (start_radian >= radian)
                {
                    //軸決め
                    move_axis.SetAxis(0);
                    right_rotate = true;
                    old_radian = start_radian - radian;
                    start_radian = radian;
                }
                else if (start_radian <= radian)
                {
                    //軸決め
                    move_axis.SetAxis(1);
                    left_rotate = true;

                    old_radian = start_radian - radian;
                    start_radian = radian;
                }
            }
            else if (lsh == 0 && lsv == 0)
            {
                //回転初期位置の初期化
                start_radian = 0;
                old_radian = 0;
                initial_flg = true;
            }
        }
    }

    //private void RotateSE()
    //{
    //    if ((left_rotate == true || right_rotate == true) && secout == 0) 
    //    {
    //        SEManager.Instance.Play(SEPath.SE_001);
    //        //Debug.Log(secout);
    //        secout = 1;
    //        Debug.Log(secout);
    //    }
    //    else if(left_rotate == false || right_rotate == false)
    //    {
    //        //SEManager.Instance.Stop(SEPath.SE_001);
    //        Debug.Log("Stop");
    //        secout = 0;
    //    }
    //}
}
