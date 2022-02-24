using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FulcrumDistance : MonoBehaviour
{
    public float distance;

    public GameObject[] near_obj; //�I�u�W�F�N�g
    

    // Start is called before the first frame update
    void Start()
    {
        near_obj = new GameObject[4];

        near_obj = serchTag(gameObject, "FulcrumGear");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�w�肳�ꂽ�^�O�̒��ōł��߂����̂��擾
    GameObject[] serchTag(GameObject this_obj, string tag_name)
    {
        float tmpDis = 0;           //�����p�ꎞ�ϐ�
        GameObject[] target_obj; //�I�u�W�F�N�g
        target_obj = new GameObject[4];
        int cnt = 0;    //�z��̃J���g�p

        //�^�O�w�肳�ꂽ�I�u�W�F�N�g��z��Ŏ擾����
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tag_name))
        {
            //���g�Ǝ擾�����I�u�W�F�N�g�̋������擾
            tmpDis = Vector3.Distance(obs.transform.position, this_obj.transform.position);

            //�I�u�W�F�N�g�̋������߂����A����0�ł���΃I�u�W�F�N�g�����擾
            //�ꎞ�ϐ��ɋ������i�[
            if (tmpDis <= distance)
            {
                target_obj[cnt] = obs;
                cnt++;
            }
        }

        //�ł��߂������I�u�W�F�N�g��Ԃ�
        return target_obj;
    }
}
