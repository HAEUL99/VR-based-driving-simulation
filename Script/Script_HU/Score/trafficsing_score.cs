using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficsing_score : MonoBehaviour
{
    //�巡�׵���������
    public GameObject trafficsign;
    //�巡�׵���������
    public GameObject playercar;
    //�巡�׵���������
    public GameObject Box;
    private BoxCollider boxcolliders;
    //public int totalscore = 100;
    private bool onetimededuction = false;

    // Start is called before the first frame update
    void Start()
    {
        boxcolliders = Box.GetComponent<BoxCollider>();
        playercar = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && deduction_for_traffic())
        {
            if (!onetimededuction)
            {
 
                
                Managers.Score.ScoreDeduct(Define.ScoreDeduct.TrafficsignViolation);
                onetimededuction = !onetimededuction;
            }
            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playercar)
        {
            if (onetimededuction)
            {
                onetimededuction = !onetimededuction;
            }

        }
    }
    

    // �׳� �������̸� true�� ��ȯ�ϴ� �Լ�
    private bool deduction_for_traffic() 
    {
        
        if (trafficsign.transform.Find("PREFAB_trafficLight").transform.GetChild(4).gameObject.activeSelf == true)
        {
            Debug.Log("Red!!!");
            return true;
            
        }
        else 
        {
            return false;
        }
        
    }
    
}
