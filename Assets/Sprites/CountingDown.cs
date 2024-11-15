using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CountingDown : MonoBehaviour
{
    [SerializeField] float timer=0f;
    private GameObject gameObject;
    private int a ;
    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.FindWithTag("Timer");
    }

    // Update is called once per frame
    void FixedUpdate()
{
        timer += Time.deltaTime;
        a = (int)(timer);
        gameObject.gameObject.GetComponent<TMP_Text>().text = (60-a).ToString();
        if (a == 60)
        {
            this.enabled = false;
        }
    }
}