using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI; // Required when Using UI elements.

public class Conveyer_Management : MonoBehaviour
{
    //�x���g�R���x�A�̉ғ���
    //public bool IsOn = false;
    //�x���g�R���x�A�̖ڕW���x
    public float target_driveSpeed = 3.0f;
    //�x���g�R���x�A�̌��݂̑��x
    private float _current_speed = 0;

    //public bool right_rotate;
    //public bool left_rotate;

    MainPowrGear main_powr_gear;

    // Start is called before the first frame update
    void Start()
    {
        //�����Őe���擾
        GameObject maingear = this.transform.parent.gameObject;
        //�e�I�u�W�F�N�g�̃X�N���v�g����Q�Ƃ������ϐ�����
        main_powr_gear = maingear.GetComponent<MainPowrGear>();
    }

    void FixedUpdate()
    {


        _current_speed = main_powr_gear.IsOn ? target_driveSpeed : 0;
        SurfaceEffector2D rb = GetComponent<SurfaceEffector2D>();

        //�E��]�ŉE�ɓ���
        if(main_powr_gear.right_rotate == true)
        {
            rb.speed = _current_speed;
        }
        //����]�ō��ɓ���
        else if (main_powr_gear.left_rotate == true)
        {
            rb.speed = -_current_speed;
        }

    }
}
