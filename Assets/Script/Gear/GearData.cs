using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearData : MonoBehaviour
{
    public List<GameObject> GearList = new List<GameObject>();// Gear���X�g

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] ActiveGear; //����p�̃Q�[���I�u�W�F�N�g�z���p��

        //Active��Ԃ̃I�u�W�F�N�g��T���Ă���
        ActiveGear = GameObject.FindGameObjectsWithTag("Gear");

        //���X�g�ɒǉ�
        for (int i = 0; i < ActiveGear.Length; i++)
        {
            GearList.Add(ActiveGear[i]);
        }

        for (int i = 0; i < GearList.Count; i++)
        {
            //Debug.Log(GearList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
