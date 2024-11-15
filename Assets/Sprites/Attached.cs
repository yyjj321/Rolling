using UnityEngine;
using System.Collections;
public class Attached : MonoBehaviour
{
    public GameObject player;
    public Vector3 position;
    public float force;
    private bool check;
    public GameObject score;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        check = false;
    }
    void FixedUpdate()
    {

        if (check)
        {
            if (force != 0)
            {
                position = player.transform.position - gameObject.transform.position;//��÷����ϵ�������ʹ������player����
                Debug.Log(position);
                gameObject.GetComponent<Rigidbody>().AddForce(position * force);
                //Debug.Log("aaa");
            }
        }

    }


    void OnCollisionEnter(Collision collision)//����Ƿ���player��ײ
    {
        if (!check && collision.gameObject.CompareTag("Player"))
        {
            check = true;
            ͨ�÷���.ChangeScore(score);
            //Debug.Log("bbb");
        }
        else if(!check && collision.gameObject.CompareTag("Object"))
        {
            check = true;
            ͨ�÷���.ChangeScore(score);
        }
    }


}
