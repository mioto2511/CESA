using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shutter : MonoBehaviour
{
    private Vector3 pos;
    bool Change_Start = false;

    public bool shutter_flg = false;

    public enum Direction { 
        LEFT,
        RIGHT,
    }

    [Header("”à‚ÌˆÊ’u")] public Direction direction;

    [Header("”à‚Ì‘¬‚³")] public float speed = 0.01f;

    //public RectTransform rect;

    // Update is called once per frame
    void Update()
    {
        //rect = GetComponent<RectTransform>();
        //pos = rect.localPosition;
        Transform mytransform = this.transform;
        pos = mytransform.position;

        if (shutter_flg)
        {
            shutter_flg = false;

            Change_Start = true;

            if(direction == Direction.LEFT)
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Pick);
            }
        }        
    }

    void FixedUpdate()
    {
        if (Change_Start == true)
        {
            ///Debug.Log(pos.x);
            switch (direction)
            {
                case Direction.LEFT:
                    if ((pos.x <= -4.8f))//4.8
                    {
                        //Debug.Log("A");
                        //Debug.Log("L");
                        pos.x += speed;
                        transform.position = new Vector2(pos.x, pos.y);
                        //rect.localPosition += new Vector3(pos.x, pos.y, 0);
                    }
                    break;

                case Direction.RIGHT:
                    if ((pos.x >= 4.8f))
                    {
                        //Debug.Log("R");
                        pos.x -= speed;
                        transform.position = new Vector2(pos.x, pos.y);
                        //rect.localPosition += new Vector3(pos.x, pos.y, 0);
                    }
                    break;
            }
        }
    }
}
