using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField, Tooltip("�^�[�Q�b�g�I�u�W�F�N�g")]
    private GameObject target_object;

    [SerializeField, Tooltip("��]��")]
    private Vector3 RotateAxis = Vector3.forward;

    [SerializeField, Tooltip("���x�W��")]
    private float SpeedFactor = 0.1f;

    //�񂷂�
    public bool rotate_flg = false;

    //�����肩
    private bool right_rotate = false;
    private bool left_rotate = false;

    Transform my_transform;
    Vector3 my_rotate;

    void Update()
    {
        // transform���擾
        my_transform = this.transform;

        //��]�����̕ύX
        if (Input.GetKeyDown("joystick button 5"))//�E
        {
            right_rotate = true;
            left_rotate = false;
            Debug.Log("R");
        }
        else if (Input.GetKeyDown("joystick button 4"))//��
        {
            left_rotate = true;
            right_rotate = false;
            Debug.Log("L");
        }

        //�{�^���������Ɖ�]
        //if (Input.GetKeyDown("joystick button 0"))//�E��
        //{
        //    rotate_flg = true;
        //}

        // �w��I�u�W�F�N�g�𒆐S�ɉ�]����
        if (rotate_flg == true)//�E��
        {
            if(right_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / -SpeedFactor) * Time.deltaTime
                );
            }
            else if (left_rotate == true)
            {
                this.transform.RotateAround(
                target_object.transform.position,
                RotateAxis,
                360.0f / (1.0f / SpeedFactor) * Time.deltaTime
                );
            }
        }       
    }
}
