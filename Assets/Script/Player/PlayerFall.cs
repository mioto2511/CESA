using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
	//���C�̊J�n�n�_
	[SerializeField]
	private Transform ray_position;

	//���C���΂�����
	private float ray_range = 0.8f;

	//�������n�_��ݒ肵�����ǂ���
	private bool fall_flg;

	//�����J�E���g
	private int count = 0;

	//���g�̃R���C�_�[
	private Collider2D my_collider;

	GameObject player;

	// Start is called before the first frame update
	void Start()
    {
		fall_flg = false;

		player = this.transform.parent.gameObject; //�I�u�W�F�N�g��T��

		//�R���C�_�[OFF
		my_collider = this.GetComponent<Collider2D>();
		my_collider.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
		//���C�̉���
		Debug.DrawLine(ray_position.position, ray_position.position + Vector3.down * ray_range, Color.blue);

		//�@�����Ă�����
		if (fall_flg)
		{
			//�@�n�ʂɃ��C���͂��Ă�����
			if (Physics2D.Linecast(ray_position.position, ray_position.position + Vector3.down * ray_range, LayerMask.GetMask("Wall")))
			{
				//�����R������������
				if(count >= 3)
                {
					Destroy(player);
					Debug.Log("shi");
				}

				fall_flg = false;

				//�R���C�_�[OFF
				my_collider.enabled = false;

				//�J�E���g������
				count = 0;
			}
		}
		else
		{
			//�@�n�ʂɃ��C���͂��Ă��Ȃ���Η����n�_��ݒ�
			if (!Physics2D.Linecast(ray_position.position, ray_position.position + Vector3.down * ray_range, LayerMask.GetMask("Wall")))
			{
				fall_flg = true;

				//�R���C�_�[ON
				my_collider.enabled = true;
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