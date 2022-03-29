using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲームシーンはフェードインから始まるのでオブジェクトにこのスクリプトを持たせないといけない
// プレイヤーが絶対居ると思うのでそれに貼るのがいいと思う

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Fade_Manager.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
