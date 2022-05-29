using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSelect : MonoBehaviour
{
    [Header("ÉèÅ[ÉãÉhî‘çÜ")] public int world_num;

    private int now_stage;

    private bool start_flg = true;

    private SelectRotate select_rotate;

    // Start is called before the first frame update
    void Start()
    {
        //now_stage = PlayerPrefs.GetInt("OLDSTAGE", 1);
        now_stage = SaveManager.save.OLD_STAGE;

        select_rotate = this.GetComponent<SelectRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start_flg)
        {
            switch (now_stage) {
                case 2:
                    this.transform.Rotate(new Vector3(0, 0, 45));
                    select_rotate.count = 2;
                    break;
                case 3:
                    this.transform.Rotate(new Vector3(0, 0, 90));
                    select_rotate.count = 3;
                    break;
                case 4:
                    this.transform.Rotate(new Vector3(0, 0, 135));
                    select_rotate.count = 4;
                    break;
                case 5:
                    this.transform.Rotate(new Vector3(0, 0, 180));
                    select_rotate.count = 5;
                    break;
            }

            start_flg = false;
        }
    }
}
