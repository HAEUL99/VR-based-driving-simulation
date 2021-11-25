using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button_Game : UI_Popup
{
    public GameObject panel;
    enum Buttons
    {
        PauseButton,

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
        BindEvent(GetButton((int)Buttons.PauseButton).gameObject, OnPauseButtonClicked);

    }

    public void OnPauseButtonClicked(PointerEventData data)
    {
        panel.SetActive(true);
        //���� �Ͻ����� ��� �߰�
    }
}
