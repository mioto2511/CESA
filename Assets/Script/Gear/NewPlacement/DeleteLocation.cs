using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLocation : MonoBehaviour
{
    //public bool delete_flg;
    BoxVariable box_variable;
    //GenerateInstallation
    GenerateInstallation generate_installation;

    // Start is called before the first frame update
    void Start()
    {
        generate_installation = GetComponent<GenerateInstallation>();
        GameObject obj = transform.parent.gameObject;
        box_variable = obj.GetComponent<BoxVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(box_variable.delete_flg == true)
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


            box_variable.delete_flg = false;

            generate_installation.location_flg = true;
        }
    }
}
