using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Stage01);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
