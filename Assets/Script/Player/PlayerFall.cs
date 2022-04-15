using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
	//���C�̊J�n�n�_
	[SerializeField]
	private Transform ray_position;

	//���C���΂�����
	[SerializeField]
	private float ray_range = 0.8f;

	//�����n�߂��ꏊ
	private float fallen_position;

	//�������n�_��ݒ肵�����ǂ���
	private bool isFall;

	//�������Ă���n�ʂɗ�����܂ł̋���
	private float fallen_distance;

	//�ǂ̂��炢�̍�������_���[�W��^���邩
	[SerializeField]
	private float damage_distance = 10f;

	// Start is called before the first frame update
	void Start()
    {
		fallen_distance = 0f;
		fallen_position = transform.position.y;
		isFall = false;
	}

    // Update is called once per frame
    void Update()
    {
		//���C�̉���
		Debug.DrawLine(ray_position.position, ray_position.position + Vector3.down * ray_range, Color.blue);

		//�@�����Ă�����
		if (isFall)
		{
			//�o�E���h�����ꍇ
			fallen_position = Mathf.Max(fallen_position, transform.position.y);

			//�@�n�ʂɃ��C���͂��Ă�����
			if (Physics2D.Linecast(ray_position.position, ray_position.position + Vector3.down * ray_range, LayerMask.GetMask("Wall")))
			{
				//�@�����������v�Z
				fallen_distance = fallen_position - transform.position.y;

				//�@�����ɂ��_���[�W���������鋗���𒴂���ꍇ�_���[�W��^����
				if (fallen_distance >= damage_distance)
				{
					Destroy(this.gameObject);
				}

				isFall = false;
			}
		}
		else
		{
			//�@�n�ʂɃ��C���͂��Ă��Ȃ���Η����n�_��ݒ�
			if (!Physics2D.Linecast(ray_position.position, ray_position.position + Vector3.down * ray_range, LayerMask.GetMask("Wall")))
			{
				//�@�ŏ��̗����n�_��ݒ�
				fallen_position = transform.position.y;
				fallen_distance = 0;
				isFall = true;
			}
		}
	}
}
//�������R�ڂŎ�