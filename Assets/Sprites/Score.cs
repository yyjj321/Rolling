using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;//TMP�ڴ������ռ�֮��

public class Score : MonoBehaviour
{
    public int score=0;
    public GameObject gameObject1;
    private string a;
    //public TextMeshProUGUI tmpTest;
    // Start is called before the first frame update
    void Start()
    {
        gameObject1 = GameObject.FindWithTag("Score");
        gameObject1.gameObject.GetComponent<TMP_Text>().text = score.ToString("D3");//����������ʹ����TextMeshProUGUI������ʾNullReferenceException: Object reference not set to an instance of an object
    }                                                                               //�������ΪTMP_Text��������

    // Update is called once per frame
    void Update()
    {
        gameObject1.gameObject.GetComponent<TMP_Text>().text= score.ToString("D3");//BYD���TMP����gameObject���棬���Բ�����gameObject.gameObject.TextMeshProUGUI.Text
        //Debug.Log(score);
    }
}
