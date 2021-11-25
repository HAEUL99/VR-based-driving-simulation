using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausescreen : MonoBehaviour
{
    //SDKInputManager�� ��ü�� mirrorInvisible�� �Բ� �־����
    // public GameObject playercar;
    private SDKInputManager IM;
    private bool alreadyPressed = false;
    public GameObject canvas;
    public GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {

        IM = GetComponent<SDKInputManager>();
        //canvas = GetComponent<Canvas>();
        canvas.SetActive(false);
        //canvas.enabled = false;
        //canvas.planeDistance = 1000;


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"��ǲ��1 {IM.SInput}");
        if (IM.SInput == true)
        {
            //print($"��ǲ��{IM.TInput}");
            IsPressedTbutton();
        }
    }

    public void IsPressedTbutton()
    {
        if (alreadyPressed == false)
        {
            Time.timeScale = 0;
            //pausePanel.SetActive(true);
            print("������");
            canvas.SetActive(true);
            pauseUI.SetActive(false);


        }
        else
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
            pauseUI.SetActive(true);
        }
        alreadyPressed = !alreadyPressed;

    }
}
