using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class Score : MonoBehaviour
{
    // UI
    private Text text;
    private GameObject text_obj;
    private GameObject mid_obj;
    private GameObject max_obj;

    [Header("���݂̃X�R�A")] public int score;

    [Header("��2�̃X�R�A")] public int mid_score;

    [Header("��3�̃X�R�A")] public int max_score;

    [Header("���[���h�̔ԍ�")] public int world_num;

    [Header("�X�e�[�W�̔ԍ�")] public int stage_num;

    private int stage_score;

    public int star;

    public bool score_flg;

    private int world_score = 0;

    public static Score instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //���݂�world_score���Ăяo��
        world_score = PlayerPrefs.GetInt("WORLD" + world_num + "_SCORE", 0);

        //���݂�stage_score���Ăяo��
        stage_score = PlayerPrefs.GetInt("WORLD"+world_num+"_STAGE"+stage_num, 0);

        text_obj = GameObject.Find("CountUI");
        text = text_obj.gameObject.GetComponent<Text>();
        mid_obj = GameObject.Find("mid");
        max_obj = GameObject.Find("max");
    }

    // Update is called once per frame
    void Update()
    {
        //�X�R�A���Z�p
        int now_socre = 0;

        // �^�O�������I�u�W�F�N�g��S�Ď擾����
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ActiveBox");

        //ActiveBox�̐������X�R�A�ɔ��f
        foreach (GameObject gameObj in gameObjects)
        {
            now_socre++;
        }

        //���݂̃X�R�A����
        score = now_socre;

        //�e�L�X�g�\��
        text.text = score + "/" + max_score;

        //�N���A���̃X�R�A�\��
        if (score_flg)
        {
            score_flg = false;

            //����̃X�R�A�\��OFF
            text_obj.SetActive(false);

            //�͂��߂͐�3
            star = 3;

            //�����ɒB���Ă��Ȃ��Ɛ������炷
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

            if (star >= 3)
            {
                Debug.Log("3");
                SEManager.Instance.Play(SEPath.SE_013);
            }
            else if (star <= 2)
            {
                Debug.Log("2");
                SEManager.Instance.Play(SEPath.SE_012);
            }

            //�X�R�A�X�V
            if (star > stage_score)
            {
                world_score += (star - stage_score);

                stage_score = star;
            }

            //�Z�[�u
            PlayerPrefs.SetInt("WORLD" + world_num + "_STAGE" + stage_num, stage_score);
            PlayerPrefs.SetInt("WORLD" + world_num + "_SCORE", world_score);
            PlayerPrefs.Save();
        }
    }
}
