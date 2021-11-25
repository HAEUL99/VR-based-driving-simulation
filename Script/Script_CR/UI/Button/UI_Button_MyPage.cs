using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button_MyPage : UI_Popup
{
    public GameObject DetailScore;
    enum Buttons
    {
        DetailButton1,
        DetailButton2,
        DetailButton3,
        DetailButton4,
        ExitButton,

    }

    enum Texts
    {
        NickNameText,
        IDText,
        //scrollview�� text �߰�
    }
    
    enum ScrollViews
    {
        DetailScore,
        //�� ��ư�� ���� ��ũ�� �� �߰�??
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
        BindEvent(GetButton((int)Buttons.DetailButton1).gameObject, OnDetailButtonClicked);
        BindEvent(GetButton((int)Buttons.DetailButton2).gameObject, OnDetailButtonClicked);
        BindEvent(GetButton((int)Buttons.DetailButton3).gameObject, OnDetailButtonClicked);
        BindEvent(GetButton((int)Buttons.DetailButton4).gameObject, OnDetailButtonClicked);
        BindEvent(GetButton((int)Buttons.ExitButton).gameObject, OnExitButtonClicked);

        DetailScore.SetActive(false);

    }
    public void OnDetailButtonClicked(PointerEventData data)
    {
        DetailScore.SetActive(true);
    }
    public void OnExitButtonClicked(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Menu);
    }
}
