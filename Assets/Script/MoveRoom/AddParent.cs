using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParent : MonoBehaviour
{
    //RoomCollition�̕ϐ����g��
    private RoomCollition room_collition;
    //BoxVariable�̕ϐ����g��
    private BoxVariable box_variable;
    //Score�̕ϐ����g��
    private Score score;

    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject; //�I�u�W�F�N�g��T��

        GameObject obj = transform.parent.gameObject;//�I�u�W�F�N�g��T��
        box_variable = obj.GetComponent<BoxVariable>();//�t���Ă���X�N���v�g���擾

        GameObject score_obj = GameObject.Find("Room");
        score = score_obj.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score.score);
        if (box_variable.become_child == true)
        {
            //�e
            GameObject parent = this.transform.parent.gameObject;

            parent.tag = "ActiveBox";

            //Debug.Log("become"+parent);

            //�e�̐e��Room�ɂ���
            parent.transform.parent = GameObject.Find("Room").transform;

            //�X�N���v�g��ǉ�
            gameObject.AddComponent<RoomCollition>();

            //�ǑS�ĂɃX�N���v�g��ǉ����邽�߂̃J�E���g
            box_variable.child_cnt++;

            //4�̖ڂ̕ǂ̎��t���O��܂�
            if (box_variable.child_cnt >= 3)
            {
                //�X�R�A���Z
                score.score++;
                //Debug.Log(score.score);

                box_variable.become_child = false;
            }

            //���̃X�N���v�g���폜
            Destroy(this);
        }
    }
}
