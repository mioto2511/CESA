using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class PlayerFall : MonoBehaviour
{
	//GoalTrigger
	private GoalTrigger goal_trigger;

	//レイの開始地点
	[SerializeField]
	private Transform ray_position;

	//レイを飛ばす距離
	private float ray_range = 0.8f;

	//落ちた地点を設定したかどうか
	private bool fall_flg;

	//部屋カウント
	private int count = 0;

	//自身のコライダー
	private Collider2D my_collider;

	private GameObject player;

	//死亡フラグ
	public bool death_flg = false;

	// Start is called before the first frame update
	void Start()
    {
		fall_flg = false;

		player = this.transform.parent.gameObject; //オブジェクトを探す

		GameObject obj1 = GameObject.Find("GoalTrigger"); //オブジェクトを探す
		goal_trigger = obj1.GetComponent<GoalTrigger>();//付いているスクリプトを取得

		//コライダーOFF
		my_collider = this.GetComponent<Collider2D>();
		my_collider.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(count);
		//レイの可視化
		Debug.DrawLine(ray_position.position, ray_position.position + Vector3.down * ray_range, Color.blue);

		//　落ちている状態
		if (fall_flg)
		{
			//　地面にレイが届いていたら
			if (Physics2D.Linecast(ray_position.position, ray_position.position + Vector3.down * ray_range, LayerMask.GetMask("Wall")))
			{
				//ゴールに接触できる
				goal_trigger.ColliderSwitch(true);

				//部屋３個分落下したら
				if (count >= 3)
                {
					death_flg = true;
					//Destroy(player);
					Debug.Log("shi");
					BGMManager.Instance.Stop(BGMPath.BGM_001);
					SEManager.Instance.Play(SEPath.SE_010);
					goal_trigger.ColliderSwitch(false);
				}

				fall_flg = false;

				//コライダーOFF
				my_collider.enabled = false;

				//カウント初期化
				count = 0;
			}
		}
		else
		{
			//　地面にレイが届いていなければ落下地点を設定
			if (!Physics2D.Linecast(ray_position.position, ray_position.position + Vector3.down * ray_range, LayerMask.GetMask("Wall")))
			{
				fall_flg = true;

				//コライダーON
				my_collider.enabled = true;

				goal_trigger.ColliderSwitch(false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Box"))
		{
			count++;
		}

		if (other.gameObject.CompareTag("ActiveBox"))
		{
			count++;
		}
	}
}