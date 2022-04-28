using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FedeScript : MonoBehaviour
{
	//フェードイン秒数
	[SerializeField]
	private float fadein_time;
	//背景Image
	private Image image;

	void Start()
	{
		image = transform.Find("FedeUI").GetComponent<Image>();
		//コルーチンで使用する待ち時間を計測
		fadein_time = 1f * fadein_time / 10f;
		StartCoroutine("FadeIn");
	}

	IEnumerator FadeIn()
	{
		//Colorのアルファを0.1ずつ下げていく
		for (var i = 1f; i >= 0; i -= 0.1f)
		{
			image.color = new Color(0f, 0f, 0f, i);
			//指定秒数待つ
			yield return new WaitForSeconds(fadein_time);
		}
	}
}
