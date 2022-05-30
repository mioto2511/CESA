using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseCursor : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    GameObject selectObject;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 270);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseActive.instance.pause_flg)
        {
            try
            {
                selectObject = eventSystem.currentSelectedGameObject.gameObject;
            }
            catch
            {

            }
        }

        if (selectObject.name == "Button1")
        {
            //Debug.Log("button1");
            if (gameObject.transform.localEulerAngles.z != 25)
            {
                if ((gameObject.transform.localEulerAngles.z >= 270 && gameObject.transform.localEulerAngles.z <= 360) ||
                    (gameObject.transform.localEulerAngles.z >= -90 && gameObject.transform.localEulerAngles.z <= 24))
                {
                    transform.Rotate(new Vector3(0, 0, 5));
                }
                else if (gameObject.transform.localEulerAngles.z <= 155 && gameObject.transform.localEulerAngles.z >= 26)
                {
                    transform.Rotate(new Vector3(0, 0, -5));
                }
            }
        }
        else if (selectObject.name == "Button2")
        {
            //Debug.Log("button2");
            if (gameObject.transform.localEulerAngles.z != 270)
            {
                if (gameObject.transform.localEulerAngles.z <= 270 && gameObject.transform.localEulerAngles.z >= 155)
                {
                    transform.Rotate(new Vector3(0, 0, 5));
                }
                else if ((gameObject.transform.localEulerAngles.z >= 270 && gameObject.transform.localEulerAngles.z <= 360) ||
                    (gameObject.transform.localEulerAngles.z >= 0 && gameObject.transform.localEulerAngles.z <= 25))
                {
                    transform.Rotate(new Vector3(0, 0, -5));
                }
            }
        }
        else if (selectObject.name == "Button3")
        {
            //Debug.Log("button3");
            if (gameObject.transform.localEulerAngles.z != 155)
            {
                if (gameObject.transform.localEulerAngles.z <= 155)
                {
                    transform.Rotate(new Vector3(0, 0, 5));
                }
                else if (gameObject.transform.localEulerAngles.z >= 155)
                {
                    transform.Rotate(new Vector3(0, 0, -5));
                }
            }
        }

        ErrorRotation();
    }

    private void ErrorRotation()
    {
        if (selectObject.name == "Button1")
        {
            if (gameObject.transform.localEulerAngles.z <= 31 && gameObject.transform.localEulerAngles.z >= 19)
            {
                transform.rotation = Quaternion.Euler(0, 0, 25);
            }
        }
        if (selectObject.name == "Button2")
        {
            if (gameObject.transform.localEulerAngles.z <= 276 && gameObject.transform.localEulerAngles.z >= 264)
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
        }
        if (selectObject.name == "Button3")
        {
            if (gameObject.transform.localEulerAngles.z <= 161 && gameObject.transform.localEulerAngles.z >= 149)
            {
                transform.rotation = Quaternion.Euler(0, 0, 155);
            }
        }
    }
}

