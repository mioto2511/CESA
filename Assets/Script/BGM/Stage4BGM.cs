using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class Stage4BGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGMManager.Instance.Play(BGMPath.BGM_001, isLoop: true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
