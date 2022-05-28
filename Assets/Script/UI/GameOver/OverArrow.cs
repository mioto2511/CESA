using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverArrow : MonoBehaviour
{
    public RectTransform tf;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightArrow()
    {
        tf.anchoredPosition = new Vector3(-684f, -140, 0);
    }

    public void LeftArrow()
    {
        tf.anchoredPosition = new Vector3(184f,-140,0);
    }
}
