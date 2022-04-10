using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField, Tooltip("ターゲットオブジェクト")]
    private GameObject target_object;

    [SerializeField, Tooltip("回転軸")]
    private Vector3 RotateAxis = Vector3.forward;

    [SerializeField, Tooltip("速度係数")]
    private float SpeedFactor = 0.1f;

    public bool right_rotate = false;
    public bool left_rotate = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            right_rotate = true;
        }
    }

    void FixedUpdate()
    {
        if (right_rotate == true)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("hit");
            right_rotate = false;
            left_rotate = false;
        }
            
    }
}
