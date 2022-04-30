using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageCollision : MonoBehaviour
{
    //�񓯊�����Ŏg�p����AsyncOperation
    private AsyncOperation async;

    [Header("���̃V�[��")] public int scene;

    private bool hit = false;

    private Shutter shutterL;
    private Shutter shutterR;
    private ChangeScene change_scene;

    // Start is called before the first frame update
    void Start()
    {
        GameObject L = GameObject.Find("ShutterL"); // �I�u�W�F�N�g��T��
        shutterL = L.GetComponent<Shutter>();

        GameObject R = GameObject.Find("ShutterR"); // �I�u�W�F�N�g��T��
        shutterR = R.GetComponent<Shutter>();

        GameObject T = GameObject.Find("ShutterTrigger"); // �I�u�W�F�N�g��T��
        change_scene = T.GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                shutterL.shutter_flg = true;
                shutterR.shutter_flg = true;

                change_scene.NextScene(scene);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        hit = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        hit = false;
    }


    //�V�[�����[�h���ɕ\������UI���
    //[SerializeField]
    //private GameObject load_ui;

    //�ǂݍ��ݗ���\������X���C�_�[
    //[SerializeField]
    //private Slider slider;

    //[SerializeField]
    //private string scene_name;
    //public void NextScene()
    //{
    //    //���[�h���ON
    //    load_ui.SetActive(true);

    //    //�R���[�`�����J�n
    //    StartCoroutine("LoadData");
    //}

    //IEnumerator LoadData()
    //{
    //    //�V�[���̓ǂݍ��݂�����
    //    async = SceneManager.LoadSceneAsync(scene_name);

    //    //�ǂݍ��݂��I���܂Ői���󋵂��X���C�_�[�̒l�ɔ��f������
    //    while (!async.isDone)
    //    {
    //        var progressVal = Mathf.Clamp01(async.progress / 0.9f);
    //        slider.value = progressVal;
    //        yield return null;
    //    }
    //}

}
