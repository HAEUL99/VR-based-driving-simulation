using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    private int Score = 100;
    private int[] DeductCount = new int [(int)Define.ScoreDeduct.MaxCount];
    private int Threshold = 60;
    private Define.ScoreOut scoreout; // �ǰ� ���� ����

    public void ScoreDeduct(Define.ScoreDeduct type, Define.Scene scene = Define.Scene.Game)
    {
        Debug.Log($"{type} �߻�");

        switch (type)
        {
            case Define.ScoreDeduct.BuildingCollision:
                Score -= 5;
                DeductCount[(int)Define.ScoreDeduct.BuildingCollision]++;
                break;

            case Define.ScoreDeduct.AnimalCollision:
                Score -= 7;
                DeductCount[(int)Define.ScoreDeduct.AnimalCollision]++;
                break;

            case Define.ScoreDeduct.CarCollision:
                DeductCount[(int)Define.ScoreDeduct.CarCollision]++;
                if (scene == Define.Scene.Park_Level_1_Day || scene == Define.Scene.Park_Level_1_Night
                    || scene == Define.Scene.Park_Level_2_Day || scene == Define.Scene.Park_Level_2_Night
                    || scene == Define.Scene.Park_Level_3_Day || scene == Define.Scene.Park_Level_3_Night)
                    Score -= 5;
                // �ǰ�
                else
                {
                    //Score = -1;
                    ScoreOut(Define.ScoreOut.Collision);//Score = 0;
                }
                    break;

            case Define.ScoreDeduct.ClifCollision:
                //Score = -1;
                ScoreOut(Define.ScoreOut.Collision); // Score = 0;
                DeductCount[(int)Define.ScoreDeduct.ClifCollision]++;
                // Player state End�� �ٲٱ� 
                break;

            case Define.ScoreDeduct.Speeding:
                Score -= 5;
                DeductCount[(int)Define.ScoreDeduct.Speeding]++;
                break;

            case Define.ScoreDeduct.StartMiss:
                Score -= 10;
                DeductCount[(int)Define.ScoreDeduct.StartMiss]++;
                break;

            case Define.ScoreDeduct.SuddenStop:
                Score -= 10;
                DeductCount[(int)Define.ScoreDeduct.SuddenStop]++;
                break;

            // �ǰ�
            case Define.ScoreDeduct.PedestrainsCollision:
                //Score = -1;
                DeductCount[(int)Define.ScoreDeduct.PedestrainsCollision]++;
                ScoreOut(Define.ScoreOut.Collision);
                break;

            case Define.ScoreDeduct.TrafficsignViolation:
                Score -= 7;
                DeductCount[(int)Define.ScoreDeduct.TrafficsignViolation]++;
                break;


        }

        // ���� ǥ �Ʒ� �Ͻ�, �ǰ�
        if(Score < Threshold)
        {
            // �� Scene ���� �ٸ��� �ؾ��ϱ� ������ 
            ScoreOut(Define.ScoreOut.Threshold);
        }
    }
    // �ǰ� or Game Over
    public void ScoreOut(Define.ScoreOut type)
    {
        // Game Over 
        scoreout = type;
        Managers.State.Set_State(Play_State.GameOver); // Play State�� Gameover�� �ٲ� 
        Debug.Log($"{type} GameOver");
    }

    public int GetScore()
    {
        return Score;
    }

    public Define.ScoreOut GetScoreOut()
    {
        return scoreout;
    }
    public int[] GetDeductInfo()
    {
        return DeductCount;
    }
}
