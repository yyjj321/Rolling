using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;//TMP在此命名空间之中

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
        gameObject1.gameObject.GetComponent<TMP_Text>().text = score.ToString("D3");//这里我首先使用了TextMeshProUGUI，但显示NullReferenceException: Object reference not set to an instance of an object
    }                                                                               //后面更改为TMP_Text运行正常

    // Update is called once per frame
    void Update()
    {
        gameObject1.gameObject.GetComponent<TMP_Text>().text= score.ToString("D3");//BYD这个TMP不在gameObject里面，所以不能用gameObject.gameObject.TextMeshProUGUI.Text
        //Debug.Log(score);
    }
}
