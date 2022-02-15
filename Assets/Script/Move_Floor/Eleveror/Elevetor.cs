using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevetor : MonoBehaviour
{
    private enum MoveDir
    {
        Up,
        Stop,
    }

    [SerializeField]
    private MoveDir _moveDir;

     
    //�ړ��̑���
    [SerializeField]
    private float _moveSpeed = 0.0f;
    //�ړ���
    [SerializeField]
    private float _moveRange = 1;

    

    private Rigidbody2D Rb { get; set; }

    private float t { get; set; } = 0.0f;

    //�����ʒu
    private Vector2 InitPos { get; set; }
    //�ړ��O�̈ʒu
    private Vector2 BeforePos { get; set; }
    //�ړ���̈ʒu
    private Vector2 AfterPos { get; set; }

    
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        
        InitPos = transform.position;
        BeforePos = transform.position;

        if (_moveDir == MoveDir.Stop)
        {
            //script.IsOn = true;
        }

        AfterPos = transform.position + new Vector3(_moveRange, _moveRange);
    }

    private void FixedUpdate()
    {
        
        //Rb.MovePosition(new Vector2(InitPos.x, Mathf.Lerp(BeforePos.y, AfterPos.y, t)));
        Rb.MovePosition(new Vector2(InitPos.x, Mathf.SmoothStep(BeforePos.y, AfterPos.y, t)));

        t += _moveSpeed * Time.fixedDeltaTime;

        ChangeMoveInfo();
    }

    private void ChangeMoveInfo()
    {
        if (t > 1.0f)
        {
            //var temp = BeforePos;
            //BeforePos = AfterPos;
            //AfterPos = temp;


            //t = 0.0f;

            Add_force script = GetComponent<Add_force>();
            script.IsOn = true;

        }
    }
}
