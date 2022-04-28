using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingScript : MonoBehaviour
{
    //�񓯊�����Ŏg�p����AsyncOperation
    private AsyncOperation async;

    //�V�[�����[�h���ɕ\������UI���
    [SerializeField]
    private GameObject load_ui;

    //�ǂݍ��ݗ���\������X���C�_�[
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private string scene_name;

    public void NextScene()
    {
        //���[�h���ON
        load_ui.SetActive(true);

        //�R���[�`�����J�n
        StartCoroutine("LoadData");
    }

    IEnumerator LoadData()
    {
        //�V�[���̓ǂݍ��݂�����
        async = SceneManager.LoadSceneAsync(scene_name);

        //�ǂݍ��݂��I���܂Ői���󋵂��X���C�_�[�̒l�ɔ��f������
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }
}
