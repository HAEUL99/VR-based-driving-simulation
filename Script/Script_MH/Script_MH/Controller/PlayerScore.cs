using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class PlayerScore : MonoBehaviour
{
    private int Collicount = 0;
    Define.Scene MyScene;

    // ���� �� ������
    private SDKInputManager IM;
    private float lastbrakeInput;
    public SpeedCalculate speedCalculate;
    private bool onetimededuction_forover = false;
    private bool onetimededuction_forsudd = false;

    // Parking Flag
    private bool[] ParkFlag = new bool[4];
    private bool isParkSuccess = false;


    //�ð�
    private string time;
    private string pasttime_forover;
    private string pasttime_forsudd;

    private void Awake()
    {
        for (int i = 0; i < ParkFlag.Length; i++)
        {
            ParkFlag[i] = false;
        }
    }

    // �������� �浹 ���� - Collision�� ��������, ����
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"Collision Event {collision.gameObject.tag}");

        switch (collision.gameObject.tag)
        {
            case "Building":
                Collicount++;
                Debug.Log($"Collicount {Collicount}");
                Managers.Score.ScoreDeduct(Define.ScoreDeduct.BuildingCollision);
                break;
            case "Animals":
                Managers.Score.ScoreDeduct(Define.ScoreDeduct.AnimalCollision);
                break;

            case "Car":
                Managers.Score.ScoreDeduct(Define.ScoreDeduct.CarCollision, MyScene);
                break;

            case "Cliff":
                Managers.Score.ScoreDeduct(Define.ScoreDeduct.ClifCollision);
                break;

            case "Pedestrains":
                Managers.Score.ScoreDeduct(Define.ScoreDeduct.PedestrainsCollision);
                break;

            case "End":
                Managers.Score.ScoreOut(Define.ScoreOut.Clear);
                break;
        }

        //Debug.Log($"Score {Managers.Score.GetScore()}");
    }

    // �������� �浹�� �Ͼ�� ������ Trigger �߻�: ���� Timeout �� ���� ����� �ֳ� Ȯ��
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger Event {other.gameObject.tag}");

        switch (other.gameObject.tag)
        {
            case "Line":
                break;

            case "":

                break;
        }
    }

    // ���ݸ� Collider�� ���͵� Stay��� ����
    // 4���� Collider�� ���� ����?
    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Park1":
                ParkFlag[0] = true;
                break;
            case "Park2":
                ParkFlag[1] = true;
                break;
            case "Park3":
                ParkFlag[2] = true;
                break;
            case "Park4":
                ParkFlag[3] = true;
                break;
            // ���� ���� ���, ������ ���� ����
            case "Line":
                isParkSuccess = false;
                break;
        }

        // If all flag is True => Parking is Success
        isParkSuccess = ParkFlag[0] && ParkFlag[1] && ParkFlag[2] && ParkFlag[3];
        //Debug.Log($"isParkSuccess {isParkSuccess}");

        if (isParkSuccess)
            Managers.Score.ScoreOut(Define.ScoreOut.Clear);

    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Park1":
                ParkFlag[0] = false;
                break;
            case "Park2":
                ParkFlag[1] = false;
                break;
            case "Park3":
                ParkFlag[2] = false;
                break;
            case "Park4":
                ParkFlag[3] = false;
                break;
        }
    }
    void Start()
    {
        // Scene script ��������
        Component[] components = GameObject.Find("@Scene").GetComponents(typeof(Component));

        foreach (Component component in components)
        {
            Debug.Log($"component: {component}");
            PropertyInfo prop = component.GetType().GetProperty("SceneType");

            if (prop != null)
                MyScene = (Define.Scene)prop.GetValue(component, null);
            else Debug.LogError("There is no @Scene");

        }

        // assignment
        IM = GameObject.FindGameObjectWithTag("Player").GetComponent<SDKInputManager>();
        speedCalculate = GameObject.Find("Speed").GetComponent<SpeedCalculate>();
    }
    void Update()
    {
        time = System.DateTime.Now.ToString();
        if (Managers.State.Get_State() == Play_State.Playing)
        {
            deduction_for_speeding();
            suddenstop();
        }



    }

    // ���� ä��
    private void deduction_for_speeding()
    {
        Debug.Log($"speed {onetimededuction_forover}");
        if ((speedCalculate.speed >= 60) && (pasttime_forover != time || pasttime_forover == null))
        {
            if (!onetimededuction_forover)
            {
                Managers.Score.ScoreDeduct(Define.ScoreDeduct.Speeding);
                Debug.Log($"speed{speedCalculate.speed} ��ȣ���ݰ���");
                onetimededuction_forover = !onetimededuction_forover;
                pasttime_forover = time;
            }

        }
        else if (speedCalculate.speed < 60)
        {
            if (onetimededuction_forover)
            {
                onetimededuction_forover = !onetimededuction_forover;
            }

        }

    }

    public void suddenstop()
    {
        // �극��ũ �ȹ����� -1 ~ ������ 1
        float degree_brake = ((IM.brake - lastbrakeInput) / Time.deltaTime);
        lastbrakeInput = IM.brake;
        if ((degree_brake >= 15) && (pasttime_forsudd != time || pasttime_forsudd == null))
        {
            if (!onetimededuction_forsudd)
            {
                //scoretest_hj.stagePoint -= 5;
                Managers.Score.ScoreDeduct(Define.ScoreDeduct.SuddenStop);
                print("�극��ũ��������");
                onetimededuction_forsudd = !onetimededuction_forsudd;
                pasttime_forsudd = time;
            }
        }
        else if (degree_brake < 15)
        {
            if (onetimededuction_forsudd)
            {
                onetimededuction_forsudd = !onetimededuction_forsudd;
            }
        }
    }



}