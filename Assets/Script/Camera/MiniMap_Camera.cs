using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_Camera : MonoBehaviour
{
    private Camera cam;
    
    float cma_hw = 1.0f;
    float cam_x = 0.0f;
    float cam_y = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        
        cam.rect = new Rect(0, 0, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        cam.rect = new Rect(cam_x, cam_y, cma_hw, cma_hw);
        if (cam_x < 0.75f)
        {
            cam_x += 0.001f;
        }
        if (cam_y < 0.75f)
        {
            cam_y += 0.001f;
        }
    }
}
