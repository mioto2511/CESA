using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
	//レイの開始地点
	[SerializeField]
	private Transform ray_position;

	//レイを飛ばす距離
	[SerializeField]
	private float ray_range = 0.8f;

	//落ち始めた場所
	//private float fallen_position;

	//落ちた地点を設定したかどうか
	private bool isFall;

	//落下してから地面に落ちるまでの距離
	//private float fallen_distance;

	//どのぐらいの高さからダメージを与えるか
	[SerializeField]
	//private float damage_distance = 10f;

	private int count = 0;

	Collider2D collider;

	GameObject player;

	// Start is called before the first frame update
	void Start()
    {
		//fallen_distance = 0f;
		//fallen_position = transform.position.y;
		isFall = false;

		player = this.transform.parent.gameObject; //オブジェクトを探す
		collider = this.GetComponent<Collider2D>();
		collider.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
		//レイの可視化
		Debug.DrawLine(ray_position.position, ray_position.position + Vector3.down * ray_range, Color.blue);

		//　落ちている状態
		if (isFall)
		{
			//バウンドした場合
			//fallen_position = Mathf.Max(fallen_position, transform.position.y);

			//　地面にレイが届いていたら
			if (Physics2D.Linecast(ray_position.position, ray_position.position + Vector3.down * ray_range, LayerMask.GetMask("Wall")))
			{
				//　落下距離を計算
				//fallen_distance = fallen_position - transform.position.y;

				//　落下によるダメージが発生する距離を超える場合ダメージを与える
				//if (fallen_distance >= damage_distance)
				//{
				//	Destroy(this.gameObject);
				//}

				if(count >= 3)
                {
					Destroy(player);
				}

				isFall = false;
				collider.enabled = false;
				count = 0;
			}
		}
		else
		{
			//　地面にレイが届いていなければ落下地点を設定
			if (!Physics2D.Linecast(ray_position.position, ray_position.position + Vector3.down * ray_range, LayerMask.GetMask("Wall")))
			{
				//　最初の落下地点を設定
				//fallen_position = transform.position.y;
				//fallen_distance = 0;
				isFall = true;
				collider.enabled = true;
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