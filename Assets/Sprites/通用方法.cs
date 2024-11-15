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

}
