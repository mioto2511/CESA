using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSelect : MonoBehaviour
{
    [Header("ÉèÅ[ÉãÉhî‘çÜ")] public int world_num;

    private int now_stage;

    private bool start_flg = true;

    // Start is called before the first frame update
    void Start()
    {
        now_stage = PlayerPrefs.GetInt("OLDSTAGE", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (start_flg)
        {
            switch (now_stage) {
                case 2:
                    this.transform.Rotate(new Vector3(0, 0, 45));
                    break;
                case 3:
                    this.transform.Rotate(new Vector3(0, 0, 90));
                    break;
                case 4:
                    this.transform.Rotate(new Vector3(0, 0, 135));
                    break;
                case 5:
                    this.transform.Rotate(new Vector3(0, 0, 180));
                    break;
            }

            start_flg = false;
        }
    }
}
