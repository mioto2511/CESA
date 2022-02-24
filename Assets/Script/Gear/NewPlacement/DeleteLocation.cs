using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLocation : MonoBehaviour
{
    public bool delete_flg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delete_flg == true)
        {
            //foreach (Transform child in gameObject.transform)
            //{
            //    Destroy(child.gameObject);
            //}
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Select");
            foreach (GameObject del in objects)
            {
                Destroy(del);
            }
        }
    }
}
