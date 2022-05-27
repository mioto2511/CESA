using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�R���|�[�l���g�̎g�p

public class PauseScript : MonoBehaviour
{
	private Button b1;
	private Button b2;
	private Button b3;

	private bool isPause;

	// Start is called before the first frame update
	void Start()
	{
		// �{�^���R���|�[�l���g�̎擾
		b1 = GameObject.Find("/Canvas/Pause/Button1").GetComponent<Button>();
		b2 = GameObject.Find("/Canvas/Pause/Button2").GetComponent<Button>();
		b3 = GameObject.Find("/Canvas/Pause/Button3").GetComponent<Button>();

		// �ŏ��ɑI����Ԃɂ������{�^���̐ݒ�
		b2.Select();

		isPause = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (PauseActive.instance.pause_flg)
		{
			if (isPause)
			{
				b2.Select();
				isPause = false;
			}
		}
		else
		{
			isPause = true;
		}
	}
}
