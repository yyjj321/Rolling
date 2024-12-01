using UnityEngine;
using System.Collections;
public class Attached : MonoBehaviour
{
    public GameObject player;
    public Vector3 position;
    public float force;
    private bool check;
    public GameObject score;
    public bool a;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        check = false;
        a = false;
    }
    void FixedUpdate()
    {

        if (check)//只有碰撞之后check为true才会向player吸附
        {
            if (force != 0)
            {
                position = player.transform.position - gameObject.transform.position;//获得方向上的力，并使物体向player吸附
                //Debug.Log(position);
                gameObject.GetComponent<Rigidbody>().AddForce(position * force);
                player.GetComponent<Rigidbody>().AddForce(-position * force);//输出平衡力，获得方向上的力，并使player向object抵消引力
                //Debug.Log("aaa");
            }

        }

    }


    void OnCollisionEnter(Collision collision)//检测是否是player碰撞
    {
        if (!check && collision.gameObject.CompareTag("Player"))
        {
            check = true;
            通用方法.ChangeScore(score);
            //Debug.Log("bbb");
        }
        else if(!check && collision.gameObject.CompareTag("Object"))
        {
            check = true;
            通用方法.ChangeScore(score);
            collision.gameObject.tag = "已捕捉";
        }else if(!check && collision.gameObject.CompareTag("已捕捉"))
        {
            check = true;
            通用方法.ChangeScore(score);
            collision.gameObject.tag = "已捕捉";
        }
        if (collision.gameObject.CompareTag("Ground"))//接触地面，允许player跳跃
        {
            a = true;
        }
    }
    void OnCollisionExit(Collision collision)//离开地面，不允许player跳跃
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            a = false;
        }
    }
}
