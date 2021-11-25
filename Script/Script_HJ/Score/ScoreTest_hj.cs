using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTest_hj : MonoBehaviour
{
    public int stagePoint = 100;
    public PlayerTest_hj playcar;

    //�ѹ��浹�� �ѹ� ���� ����
    private bool onetimededuction = false;

    //�ð�
    private string time;
    private string pasttime;

    //����
    public SpeedCalculate speedCalculate;

    //������
    //�巡�׵���������
    private SDKInputManager IM;
    private float lastbrakeInput;


    // Collider ������Ʈ�� is Trigger�� false�� ���·� �浹�� �������� ��
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision");
        
        if (other.gameObject.CompareTag("Animals") && (pasttime != time || pasttime == null))
        {
            //Debug.Log("���� �浹");
            if (!onetimededuction )
            {
                //scoretest_hj.stagePoint -= 5;
                stagePoint -= 7;

                onetimededuction = !onetimededuction;
                pasttime = time;
            }

            //Debug.Log("Score: " + stagePoint);
            //UIPoint.text = "Score: " + Managers.Score.GetScore();

            if (stagePoint <= 60)
            {
                //Debug.Log("�ǰ�");
                playcar.OnDie();

                //UIPoint.text = "Score: " + stagePoint.ToString();
                //FinishMent.text = "�ǰ��Դϴ�. �ٽ� �õ��غ�����.";
                //DeductReason.text = "���� �̴��Դϴ�.";
                //TotalPoints.text = stagePoint.ToString();
                //scorePanel.SetActive(true);
            }
        }
        else if (other.gameObject.CompareTag("Car"))
        {
            //Debug.Log("���� �浹");
            stagePoint = 0;
            if (stagePoint <= 0)
            {
                playcar.OnDie();

                //UIPoint.text = "Score: 0";
                //scorePanel.SetActive(true);
                //FinishMent.text = "�ǰ��Դϴ�. �ٽ� �õ��غ�����.";
                //DeductReason.text = "�ݴ���� ���� ������ �浹��.";
                //DeductPoints.text = "Fail";
                //TotalPoints.text = stagePoint.ToString();
            }
        }
        else if (other.gameObject.CompareTag("Cliff"))
        {
            stagePoint = 0;
            if (stagePoint <= 0)
            {
                //Debug.Log("���� �浹");
                playcar.OnDie();

                //UIPoint.text = "Score: 0";
                //FinishMent.text = "�ǰ��Դϴ�. �ٽ� �õ��غ�����.";
                //DeductReason.text = "������ �浹��.";
                //DeductPoints.text = "Fail";
                //TotalPoints.text = stagePoint.ToString();
                //scorePanel.SetActive(true);
            }
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            playcar.OnDie();
            //TotalPoints.text = stagePoint.ToString();
            Debug.Log("Finish");
            //scorePanel.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.CompareTag("Animals"))
        {
            onetimededuction = !onetimededuction;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        IM = playcar.GetComponent<SDKInputManager>();
        //pausePanel.SetActive(false);
        //scorePanel.SetActive(false);

        //UIPoint.text = "Score: " + stagePoint.ToString();
    }

    private void Update()
    {
        time = System.DateTime.Now.ToString();
        deduction_for_speeding();
        suddenstop();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        //pausePanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        //pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // ���� ä��
    private void deduction_for_speeding()
    {
        if (speedCalculate.speed >= 20)
        {
            if (!onetimededuction)
            {
                //scoretest_hj.stagePoint -= 5;
                stagePoint -= 5;
                Debug.Log($"�ڵ��� ���ǵ� {speedCalculate.speed} ��ȣ���ݰ���");
                onetimededuction = !onetimededuction;
            }

        }
        else if (speedCalculate.speed < 20)
        {
            if (onetimededuction)
            {
                onetimededuction = !onetimededuction;
            }
        }
    }

    public void suddenstop()
    {
        // �극��ũ �ȹ����� -1 ~ ������ 1
        float degree_brake = ((IM.brake - lastbrakeInput) / Time.deltaTime);
        lastbrakeInput = IM.brake;
        if (degree_brake >= 15)
        {
            if (!onetimededuction)
            {
                //scoretest_hj.stagePoint -= 5;
                stagePoint -= 10;
                print("�극��ũ��������");
                onetimededuction = !onetimededuction;
            }

        }
        else if (degree_brake < 15)
        {
            if (onetimededuction)
            {
                onetimededuction = !onetimededuction;
            }
        }
    }
}
