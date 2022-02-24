using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallationLocation : MonoBehaviour
{
    public GameObject cube;
    public GameObject cylinder;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 Apos = cube.transform.position;
        Vector3 Bpos = cylinder.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (cube.transform.position + cylinder.transform.position) / 2;
    }
}
