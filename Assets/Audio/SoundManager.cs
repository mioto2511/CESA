using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {  // BGM�̍Đ�
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }


    public void PlaySE(SESoundData.SE se)
    { // SE�̍Đ��i�P�x�����j
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }

}

[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    { // BGM�̃��x���ݒ�
        Title,
        Stage01,
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    { // BGM�̃��x���ݒ�
       GearRotate,
       RoomConnect,
       PoseMenu,
       Select,
       Pick,
       AdhesionFloor,
       Trampoline,
       Chain,
       ScreenTransition,
       GameClear,
       GameOver,
       Result2,
       Result3,
       CharacterMove,
       CharacterFall,
       PieceGet,
       Sunny,
       Rain,
       Storm,
       Snow,
       Thunder,
       Cloudy,
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

