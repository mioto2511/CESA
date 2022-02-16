using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPowrGear : MonoBehaviour
{
    public bool right_rotate;
    public bool left_rotate;

    public bool IsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //âÒì]ÇÃå¸Ç´ämîF
        Vector3 rotate = transform.localEulerAngles;

        if (Input.GetKey("joystick button 0"))
        {
            left_rotate = true;
            right_rotate = false;
            IsOn = true;
        }
        else if (Input.GetKey("joystick button 1"))
        {
            right_rotate = true;
            left_rotate = false;
            IsOn = true;
        }

        //ç∂âÒì]
        if (left_rotate == true)
        {
            transform.Rotate(new Vector3(0, 0, 2));
        }
        else if (right_rotate == true)
        {
            transform.Rotate(new Vector3(0, 0, -2));
        }
        
    }
}
