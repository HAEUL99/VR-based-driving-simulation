using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overspeed : MonoBehaviour
{
    public SpeedCalculate speedCalculate;
    private bool onetimededuction = false;

    //public ScoreTest_hj scoretest_hj;
    public int totalscore = 100;



    void Start()
    {
        
    }   


    void Update()
    {
       deduction_for_speeding();
    }
    
    private void deduction_for_speeding()
    {
        if (speedCalculate.speed >= 20)
        {
            if (!onetimededuction) 
            {
                //scoretest_hj.stagePoint -= 5;
                totalscore -= 5;
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
    
}
