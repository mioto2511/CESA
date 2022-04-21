using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject star;
    public GameObject score_back;
    public int score;
    private int count = 0;

    private GameObject room;

    //private bool flg = false;

    //GoalFlg�̕ϐ����g�p
    private GoalFlg goal_flg;

    // Start is called before the first frame update
    void Start()
    {
        //���U���g�w�i������
        score_back.SetActive(false);

        GameObject goal = GameObject.Find("GoalTrigger"); //�I�u�W�F�N�g��T��
        goal_flg = goal.GetComponent<GoalFlg>();�@//�t���Ă���X�N���v�g���擾

        room = GameObject.Find("Room"); //�I�u�W�F�N�g��T��
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateRoom.instance.room_hit == true)
        {
            count++;
        }

        

        if (room.transform.childCount >= 3)
        {
            if (goal_flg.goal_flg == true)
            {
                if (count <= score)
                {
                    star.SetActive(true);
                    score_back.SetActive(true);

                    //Debug.Log("a");
                }
            }
        }
    }
}
