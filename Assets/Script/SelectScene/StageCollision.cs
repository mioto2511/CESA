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

    [Header("�Đ����铮��")] public GameObject mp4;

    [Header("���[���h�ԍ�")] public int world_num;

    [Header("�X�e�[�W�ԍ�")] public int stage_num;

    private bool hit = false;

    private Shutter shutter;
    private ChangeScene change_scene;

    private int now_stage_num;

    // Start is called before the first frame update
    void Start()
    {
        GameObject T = GameObject.Find("ShutterTrigger"); // �I�u�W�F�N�g��T��
        change_scene = T.GetComponent<ChangeScene>();
        shutter = T.GetComponent<Shutter>();

        //���݂�stage_num���Ăяo��
        now_stage_num = PlayerPrefs.GetInt("WORLD"+world_num, 1);

        if (now_stage_num >= stage_num)
        {
            Collider2D my_collider;
            my_collider = GetComponent<Collider2D>();
            my_collider.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                shutter.shutter_flg = true;

                change_scene.NextScene(scene);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hit = true;
        mp4.SetActive(true);
        //Invoke("DelayMethod", 0.3f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        hit = false;

        mp4.SetActive(false);
    }

    //�x������
    private void DelayMethod()
    {
        mp4.SetActive(true);
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
