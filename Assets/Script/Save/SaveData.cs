using System;
[Serializable]
public class SaveData
{
    //���[���h�X�R�A
    public int WORLD_SCORE = 0;

    //�X�e�[�W���Ƃ̐�
    public int[] WORLD1_STAGE = { 0, 0, 0, 0, 0 };
    public int[] WORLD2_STAGE = { 0, 0, 0, 0, 0 };
    public int[] WORLD3_STAGE = { 0, 0, 0, 0, 0 };
    public int[] WORLD4_STAGE = { 0, 0, 0, 0, 0 };

    //�X�e�[�W�̉��
    public int[] WORLD = { 1,1,1,1};

    //�O��̃X�e�[�W
    public int OLD_STAGE = 0;
}
