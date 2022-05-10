using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    [Header("���[���h�J��")] public bool clear = false;
    [Header("�V�[���r���h�̔ԍ�")] public int World_No = 0;

    [Header("���[���h�̔ԍ�")] public int world_num;

    [Header("���[���h����X�R�A")] public int conditions_score;

    public Text text;

    private int world_score;

    void Start()
    {
        //���݂�world_num���Ăяo��
        world_score = PlayerPrefs.GetInt("WORLD" + world_num + "_SCORE", 0);

        //���݂̃��[���h�ԍ����������Ă�������
        if (world_score >= conditions_score)
        {
            clear = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();

        //�e�L�X�g�\��
        text.text = world_score + "/" + conditions_score;
    }

    private void ColorChange()
    {
        if (clear == true)
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
