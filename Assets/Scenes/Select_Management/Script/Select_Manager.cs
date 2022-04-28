using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Manager : MonoBehaviour
{
    [Header("�V�[���r���h�̔ԍ�")] public int stage_No = 0;
    [Header("�X�e�[�W�N���A")] public bool ClearFlg = false;
    [Header("�V�����X�e�[�W")] public bool NewStageFlg = false;

    // �v���C���[�̈ʒu�̃|�C���g�̃V�[���ԍ���Character_Move�ɑ���
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Character_Move>())
        {
            other.gameObject.GetComponent<Character_Move>().Scene(stage_No);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ClearFlg == true)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            NewStageFlg = false;
        }

        if (NewStageFlg == true)
        {
            GetComponent<Renderer>().material.color = Color.red;
            ClearFlg = false;
        }
    }
}