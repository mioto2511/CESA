using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap_date : MonoBehaviour
{
    public bool dath_flg = false;

    public GameObject flame_camera;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(dath_flg == true)
        {
            Destroy(this.gameObject);

            Destroy(flame_camera.gameObject);

        }
    }
}
