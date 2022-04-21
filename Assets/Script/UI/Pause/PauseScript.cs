using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class PauseScript : MonoBehaviour
{
	private Button b1;
	private Button b2;
	private Button b3;

	// Start is called before the first frame update
	void Start()
	{
		// ボタンコンポーネントの取得
		b1 = GameObject.Find("/Canvas/Pause/Button1").GetComponent<Button>();
		b2 = GameObject.Find("/Canvas/Pause/Button2").GetComponent<Button>();
		b3 = GameObject.Find("/Canvas/Pause/Button3").GetComponent<Button>();

		// 最初に選択状態にしたいボタンの設定
		b1.Select();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
