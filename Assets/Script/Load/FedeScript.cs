using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FedeScript : MonoBehaviour
{
	//�t�F�[�h�C���b��
	[SerializeField]
	private float fadein_time;
	//�w�iImage
	private Image image;

	void Start()
	{
		image = transform.Find("FedeUI").GetComponent<Image>();
		//�R���[�`���Ŏg�p����҂����Ԃ��v��
		fadein_time = 1f * fadein_time / 10f;
		StartCoroutine("FadeIn");
	}

	IEnumerator FadeIn()
	{
		//Color�̃A���t�@��0.1�������Ă���
		for (var i = 1f; i >= 0; i -= 0.1f)
		{
			image.color = new Color(0f, 0f, 0f, i);
			//�w��b���҂�
			yield return new WaitForSeconds(fadein_time);
		}
	}
}
