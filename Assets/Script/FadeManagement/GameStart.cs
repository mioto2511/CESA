using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// フェードアウトから始まるシーンはこのスクリプトを持たせてフェードインするようにしないと画面が急に明るくなる
// プレイヤーが絶対居ると思うのでそれに貼るのがいいと思う

public class GameStart : MonoBehaviour
{
    private void Awake()
    {
        SaveManager.Load();
    }

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
