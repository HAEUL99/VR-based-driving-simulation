using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button_Pause : UI_Popup
{
    public GameObject panel;
    enum Buttons
    {
        StartButton,
        ExitButton,

    }

    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons)); //enum �̸��� Buttons�̰� Button�� ������Ʈ�� ���� ��ü�� ã�� ��
        
        //GetButton((int)Buttons.LoginButton).gameObject.BindEvent(OnButtonClicked);
        BindEvent(GetButton((int)Buttons.StartButton).gameObject, OnStartButtonClicked);
        BindEvent(GetButton((int)Buttons.ExitButton).gameObject, OnExitButtonClicked);
        panel.SetActive(false);
    }

    public void OnStartButtonClicked(PointerEventData data)
    {
        panel.SetActive(false);
        //���� �簳 ��� �߰�
    }

    public void OnExitButtonClicked(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Menu);
    }
}
