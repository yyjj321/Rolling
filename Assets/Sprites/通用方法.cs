using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 通用方法 : MonoBehaviour
{
    public static void ChangeScore(GameObject score)
    {
        score.GetComponent<Score>().score++;
    } 
    /*public static void 地面检测(bool a)
    {
        void OnCollisionEnter(Collision collision)     //a用来检测player或者已捕捉是否接触了地面，防止连跳
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                a = true;
            }
        }
        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                a = false;
            }
        }
    }*/
}
