using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    [Header("�t���[���C������܂ł̎���")] public float in_time = 0.01f;

    [Header("���n�܂ł̎���")] public float stand_time = 0.005f;

    [Header("���[���h�J��")] public bool clear = false;

    [Header("�V�[���r���h�̔ԍ�")] public int World_No = 0;

    [Header("���[���h�̔ԍ�")] public int world_num;

    [Header("���[���h����X�R�A")] public int conditions_score;

    [Header("���[���h�ő�X�R�A")] public int max_score;

    //���݂̃��[���h�̃X�R�A
    private int world_score;

    //�q
    private GameObject chain;

    private Vector3 pos;
    private Vector3 scale;

    private NumDisplay num_display;

    void Start()
    {
        //���݂�world_num���Ăяo��
        world_score = PlayerPrefs.GetInt("WORLD" + world_num + "_SCORE", 0);

        //�q���擾
        chain = this.transform.GetChild(0).gameObject;

        GameObject n = this.transform.GetChild(1).gameObject;
        num_display = n.GetComponent<NumDisplay>();

        //���݂̃��[���h�ԍ����������Ă�������
        if (world_score >= conditions_score)
        {
            clear = true;
            num_display.GenerateNum(world_score, 0.2f, 0);
        }
        else
        {
            int remaining = conditions_score - world_score;
            num_display.GenerateNum(remaining, 0.2f, 1);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();

        //�e�L�X�g�\��
        //text.text = world_score + "/" + max_score;
        
    }

    //private void FixedUpdate()
    //{
    //    pos = this.transform.position;
    //    scale = this.transform.localScale;

    //    if (pos.z <= 0)
    //    {
    //        pos.z += in_time;
    //        //pos.y -= 0.01f;

    //        this.transform.position = pos;
    //        //this.transform.localScale = scale;
    //    }

    //    if (scale.x > 0.3f)
    //    {
    //        this.transform.localScale -= new Vector3(stand_time, stand_time, 0);
    //    }
    //}

    private void ColorChange()
    {
        if (clear == true)
        {
            GetComponent<Renderer>().material.color = Color.white;
            //��OFF
            chain.SetActive(false);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color32(99, 99, 99,255);
        }
    }
}
