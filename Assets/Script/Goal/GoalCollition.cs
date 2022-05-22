using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollition : MonoBehaviour
{
    //子
    private GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;//オブジェクトを探す

        //プレイヤーとの判定OFF
        child.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Rigidbodyを取得
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //停止
            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            //遅らせて処理するもの
            Invoke("DelayMethod", 0.5f);
        } 
    }

    //遅延処理
    private void DelayMethod()
    {
        //プレイヤーとの判定ON
        child.gameObject.SetActive(true);
    }
}
