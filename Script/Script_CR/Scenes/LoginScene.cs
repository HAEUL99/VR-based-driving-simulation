using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Login;
    }

    private void Update()
    {
        
    }
    public override void Clear()
    {
        Debug.Log("LoginScene Clear");
    }
}
