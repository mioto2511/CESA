using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStart : MonoBehaviour
{
    private ZoomCamera zoom_camera;

    private void Awake()
    {
        zoom_camera = this.gameObject.GetComponent<ZoomCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        zoom_camera.zoom_flg = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
