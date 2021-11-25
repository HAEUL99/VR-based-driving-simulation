using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UI_Button_Menu : UI_Popup
{
    enum Buttons
    {
        GameButton,
        MyPageButton,
        LogOutButton,
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
        BindEvent(GetButton((int)Buttons.GameButton).gameObject, OnGameButtonClicked);
        BindEvent(GetButton((int)Buttons.MyPageButton).gameObject, OnMyPageButtonClicked);
        BindEvent(GetButton((int)Buttons.LogOutButton).gameObject, OnLogOutButtonClicked);

    }

    public void OnGameButtonClicked(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.SelectMap);
    }
    public void OnMyPageButtonClicked(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.MyPage);
    }
    public void OnLogOutButtonClicked(PointerEventData data)
    {
        //�α��� ���� ���ŵǴ� ��� �߰�
        Managers.Scene.LoadScene(Define.Scene.Login);
    }
}
