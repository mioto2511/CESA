using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopFrame : MonoBehaviour
{
    public bool loop_flg = true;

    public GameObject e_image;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!loop_flg)
        {
            e_image.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
