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

        if (check)//ֻ����ײ֮��checkΪtrue�Ż���player����
        {
            if (force != 0)
            {
                position = player.transform.position - gameObject.transform.position;//��÷����ϵ�������ʹ������player����
                //Debug.Log(position);
                gameObject.GetComponent<Rigidbody>().AddForce(position * force);
                player.GetComponent<Rigidbody>().AddForce(-position * force);//���ƽ��������÷����ϵ�������ʹplayer��object��������
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
            collision.gameObject.tag = "�Ѳ�׽";
        }else if(!check && collision.gameObject.CompareTag("�Ѳ�׽"))
        {
            check = true;
            ͨ�÷���.ChangeScore(score);
            collision.gameObject.tag = "�Ѳ�׽";
        }
        if (collision.gameObject.CompareTag("Ground"))//�Ӵ����棬����player��Ծ
        {
            a = true;
        }
    }
    void OnCollisionExit(Collision collision)//�뿪���棬������player��Ծ
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            a = false;
        }
    }
}
