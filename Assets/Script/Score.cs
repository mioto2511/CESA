using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // UI
    public Text text;
    public GameObject text_obj;
    public GameObject mid_obj;
    public GameObject max_obj;

    [Header("���݂̃X�R�A")] public int score;

    [Header("��2�̃X�R�A")] public int mid_score;

    [Header("��3�̃X�R�A")] public int max_score;

    [Header("���[���h�̔ԍ�")] public int world_num;
    [Header("�X�e�[�W�̔ԍ�")] public int stage_num;

    private int stage_score;

    private int star;

    public bool score_flg;

    private int world_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //���݂�stage_num���Ăяo��
        world_score = PlayerPrefs.GetInt("WORLD" + world_num + "_SCORE", 0);

        stage_score = PlayerPrefs.GetInt("WORLD"+world_num+"_STAGE"+stage_num, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //�e�L�X�g�\��
        text.text = score + "/" + max_score;

        if (score_flg)
        {
            score_flg = false;

            text_obj.SetActive(false);

            star = 3;

            if (score < max_score)
            {
                max_obj.SetActive(false);
                star -= 1;
            }
            if (score < mid_score)
            {
                mid_obj.SetActive(false);
                star -= 1;
            }
            

            //�X�R�A�X�V
            if(star > stage_score)
            {
                world_score += (star - stage_score);

                stage_score = star;
            }

            PlayerPrefs.SetInt("WORLD" + world_num + "_STAGE" + stage_num, stage_score);
            PlayerPrefs.SetInt("WORLD" + world_num + "_SCORE", world_score);
            PlayerPrefs.Save();
        }
    }
}
