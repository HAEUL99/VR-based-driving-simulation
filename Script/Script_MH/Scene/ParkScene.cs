using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParkScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Park_Day; // Data ���� ������ ��
    }

    private void Update()
    {
        // ���� Ÿ�̸Ӱ� �����Ͽ��ų�, �ǰݽ� ���� ������ 
        // Managers.Scene.LoadScene(Define.Scene.Game,,,) ���� ���� ȭ������ 

        if (Managers.State.Get_State() == Play_State.End)
        {
            Debug.Log("Game is The End");
            SceneManager.LoadScene(0);
        }
    }

    public override void Clear()
    {
        Debug.Log("GameScene Clear");
    }
}