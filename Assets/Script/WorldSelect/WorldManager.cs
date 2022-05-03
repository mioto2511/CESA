using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [Header("���[���h�J��")] public bool clear = false;
    [Header("�V�[���r���h�̔ԍ�")] public int World_No = 0;

    [Header("���[���h�̔ԍ�")] public int world_num;

    void Start()
    {
        //���݂�world_num���Ăяo��
        int now_world_num = PlayerPrefs.GetInt("WORLD", 1);

        //���݂̃��[���h�ԍ����������Ă�������
        if (now_world_num >= world_num)
        {
            clear = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
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
