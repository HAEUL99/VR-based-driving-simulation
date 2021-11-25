using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        Login,
        SignUp,
        Menu,
        Game,
        MyPage,
        SelectMap,
        SelectDif,
        Mountain_Level_1_Day,
        Mountain_Level_1_Night,
        Mountain_Level_2_Day,
        Mountain_Level_2_Night,
        Mountain_Level_3_Day,
        Mountain_Level_3_Night,
        Normal_Level_1_Day,
        Normal_Level_1_Night,
        Normal_Level_2_Day,
        Normal_Level_2_Night,
        Normal_Level_3_Day,
        Normal_Level_3_Night,
        School_Level_1_Day,
        School_Level_1_Night,
        School_Level_2_Day,
        School_Level_2_Night,
        School_Level_3_Day,
        School_Level_3_Night,
        Park_Level_1_Day,
        Park_Level_1_Night,
        Park_Level_2_Day,
        Park_Level_2_Night,
        Park_Level_3_Day,
        Park_Level_3_Night,

    }
    public enum UIEvent
    {
        Click,

    }

    public enum ScoreDeduct
    {
        StartMiss, // ���
        AnimalCollision,
        CarCollision,
        ClifCollision,
        Speeding,
        SuddenStop,
        LineCollision,
        BuildingCollision,
        PedestrainsCollision,
        TrafficsignViolation,
        MaxCount,


    }

    public enum ScoreOut
    {
        TimerOut,
        Threshold,
        Collision,
        Clear,
    }

    public enum Sound
    {
        UI,
        Ready,
        PlayStart,
        Idle,
        SwitchGear,
        Background,
        LowEngine,
        HighEngine,
        MaxCount, // sound ������ ����
    }

    public Dictionary<string, int> Deduction_List = new Dictionary<string, int>()
    {
        {"Don't Signal", 5 }, //�������õ� X
        {"Stop Short", 10}, //������
        {"Abnormal Speed", 5 }, //���� �ӵ� X
        {"Collide with Human or Car", -1}, //��� �Ǵ� ������ �浹
        {"Traffic Violation", 7}, //��ȣ ����
        {"Collide with Animal", 7}, //������ �浹
        {"Collide with Car in Mounatin", -1}, //�ݴ��� ���� ������ �浹
        {"Collide with Cliff", -1 }, //������ �浹
        
    };

}
