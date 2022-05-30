using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRotate : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, -0.45f));
    }
}
