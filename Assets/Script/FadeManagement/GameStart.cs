using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �t�F�[�h�A�E�g����n�܂�V�[���͂��̃X�N���v�g���������ăt�F�[�h�C������悤�ɂ��Ȃ��Ɖ�ʂ��}�ɖ��邭�Ȃ�
// �v���C���[����΋���Ǝv���̂ł���ɓ\��̂������Ǝv��

public class GameStart : MonoBehaviour
{
    private void Awake()
    {
        SaveManager.Load();
    }

    // Start is called before the first frame update
    void Start()
    {

        

        Fade_Manager.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
