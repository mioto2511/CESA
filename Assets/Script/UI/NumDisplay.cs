using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject[] num_w_obj;

    [SerializeField]
    private GameObject[] num_r_obj;

    [SerializeField]
    private GameObject[] uinum_w_obj;

    [SerializeField]
    private GameObject[] uinum_r_obj;

    public List<GameObject> save = new List<GameObject>();

    public void GenerateNum(int num,float size,int color)
    {
        var parent = this.transform;
        Vector3 parent_pos = this.transform.position;

        if(num < 10)
        {
            //”’
            if(color == 0)
            {
                GameObject obj = Instantiate(num_w_obj[num], new Vector3(parent_pos.x, parent_pos.y, parent_pos.z), Quaternion.identity,parent);
                obj.transform.localScale = new Vector3(size, size, 1);
                save.Add(obj);
            }
            else//Ô
            {
                GameObject obj = Instantiate(num_r_obj[num], new Vector3(parent_pos.x, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj.transform.localScale = new Vector3(size, size, 1);
                save.Add(obj);
            }
            
        }
        else
        {
            int ten = num / 10;
            int one = num - ten*10;

            if(color == 0)
            {
                GameObject obj = Instantiate(num_w_obj[ten], new Vector3(parent_pos.x-0.4f, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj.transform.localScale = new Vector3(size * 0.7f, size * 0.7f, 1);
                save.Add(obj);

                GameObject obj2 = Instantiate(num_w_obj[one], new Vector3(parent_pos.x +0.4f, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj2.transform.localScale = new Vector3(size * 0.7f, size * 0.7f, 1);
                save.Add(obj2);
            }
            else
            {
                GameObject obj = Instantiate(num_r_obj[ten], new Vector3(parent_pos.x - 0.4f, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj.transform.localScale = new Vector3(size*0.7f, size * 0.7f, 1);
                save.Add(obj);

                GameObject obj2 = Instantiate(num_r_obj[one], new Vector3(parent_pos.x + 0.4f, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj2.transform.localScale = new Vector3(size * 0.7f, size * 0.7f, 1);
                save.Add(obj2);
            }         
        }
    }

    public void GenerateUINum(int num, float size,int color)
    {
        var parent = this.transform;
        Vector3 parent_pos = this.transform.position;

        if (num < 10)
        {
            if(color == 0)
            {
                GameObject obj = Instantiate(uinum_w_obj[num], new Vector3(parent_pos.x, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj.transform.localScale = new Vector3(size, size, 1);
                save.Add(obj);
            }
            else
            {
                GameObject obj = Instantiate(uinum_r_obj[num], new Vector3(parent_pos.x, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj.transform.localScale = new Vector3(size, size, 1);
                save.Add(obj);
            }
            
        }
        else
        {
            int ten = num / 10;
            int one = num - ten*10;

            if(color == 0)
            {
                GameObject obj = Instantiate(uinum_w_obj[ten], new Vector3(parent_pos.x-0.4f, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj.transform.localScale = new Vector3(size, size, 1);
                save.Add(obj);

                GameObject obj2 = Instantiate(uinum_w_obj[one], new Vector3(parent_pos.x + 0.4f, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj2.transform.localScale = new Vector3(size, size, 1);
                save.Add(obj2);
            }
            else
            {
                GameObject obj = Instantiate(uinum_r_obj[ten], new Vector3(parent_pos.x, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj.transform.localScale = new Vector3(size, size, 1);
                save.Add(obj);

                GameObject obj2 = Instantiate(uinum_r_obj[one], new Vector3(parent_pos.x, parent_pos.y, parent_pos.z), Quaternion.identity, parent);
                obj2.transform.localScale = new Vector3(size, size, 1);
                save.Add(obj2);
            }  
        }
    }

    public void DestroyNum()
    {
        for (int i = 0; i < save.Count; i++)
        {
            Destroy(save[i].gameObject); 
        }

        save.Clear();
    }
}
