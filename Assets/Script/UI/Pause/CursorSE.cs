using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using KanKikuchi.AudioManager;

public class CursorSE : MonoBehaviour
{
    private Button button;
    private GameObject th;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (th != EventSystem.current.currentSelectedGameObject)
        {
            th = EventSystem.current.currentSelectedGameObject;
            SEManager.Instance.Play(SEPath.SE_004);
        }
        OnClickButton();
    }

    public void OnClickButton()
    {
        if (PauseActive.instance.pause_flg)
        {
            if(Input.GetKeyDown("joystick button 0"))
            {
                SEManager.Instance.Play(SEPath.SE_005);
            }
        }
    }
}
