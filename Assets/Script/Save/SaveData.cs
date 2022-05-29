using System;
[Serializable]
public class SaveData
{
    //ワールドスコア
    public int WORLD_SCORE = 0;

    //ステージごとの星
    public int[] WORLD1_STAGE = { 0, 0, 0, 0, 0 };
    public int[] WORLD2_STAGE = { 0, 0, 0, 0, 0 };
    public int[] WORLD3_STAGE = { 0, 0, 0, 0, 0 };
    public int[] WORLD4_STAGE = { 0, 0, 0, 0, 0 };

    //ステージの解放
    public int[] WORLD = { 1,1,1,1};

    //前回のステージ
    public int OLD_STAGE = 0;
}
