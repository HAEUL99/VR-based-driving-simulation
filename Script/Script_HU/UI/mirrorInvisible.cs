using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorInvisible : MonoBehaviour
{
    //SDKInputManager�� ��ü�� mirrorInvisible�� �Բ� �־����
   // public GameObject playercar;
    private SDKInputManager IM;
    private bool Tinput;
    private bool alreadyPressed = false;
    private Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
 
        IM = GetComponent<SDKInputManager>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        //canvas.planeDistance = 1000;


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"��ǲ�� {IM.TInput}");
        if (IM.TInput == true) 
        {
            //print($"��ǲ��{IM.TInput}");
            IsPressedTbutton();
        }
    }

    public void IsPressedTbutton() 
    {
        if(alreadyPressed == false) 
        {
            canvas.enabled = true;
            Debug.Log($"�̷� ���̰�");
          
        }
        else 
        {
            canvas.enabled = false;
            //gameObject.SetActive(true);
            Debug.Log($"�̷� �Ⱥ��̰�");
        }
        alreadyPressed = !alreadyPressed;

    }
}
