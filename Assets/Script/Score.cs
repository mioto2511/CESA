using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject star;
    public GameObject score_back;
    public int score;
    private int count = 0;

    bool flg = true;

    // Start is called before the first frame update
    void Start()
    {
        score_back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateRoom.instance.room_hit == true)
        {
            count++;
        }

        if (GameObject.Find("Room").transform.childCount >= 3)
        {
            if (count <= score)
            {
                star.SetActive(true);
                score_back.SetActive(true);

                Debug.Log("a");
            }
        }
    }
}
