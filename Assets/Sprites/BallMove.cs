using UnityEngine;
using Unity.VisualScripting;
public class BallMove : MonoBehaviour
{
        public float speed,up;//����ƶ��ٶ�
        private bool a;//a�������player�����Ѳ�׽�Ƿ�Ӵ��˵��棬��ֹ����
        private Rigidbody playerRigidbody;//��Ҫ�õ������Rigidbody�������ʵ���ƶ�����
        public GameObject gameObject2;
        private GameObject[] theAttacheds;
        int b;
    void Start()
        {
            a = false;            //��ȡ���ö���Inspector����е�Rigidbody���
            playerRigidbody = this.GetComponent<Rigidbody>();
            gameObject2 = GameObject.FindWithTag("Score");
            b = 2;

    }
        //����涨��ÿһ֡�������һ�Σ�������Ϊ��ͬ���Ե����������ͬʱ��λ�Ʋ�ͬ��
        //������ProjectSettings-Time������
    void FixedUpdate()
        {
        if (b != 1)
        {
            a = false;
            //Debug.Log(b);
        }
        //��ȡ�û����룬�����ڲ˵�����Edit-ProjectSettings-InputManager�в鿴�����޸�
           theAttacheds  = GameObject.FindGameObjectsWithTag("�Ѳ�׽");
           //Debug.Log(theAttacheds);
           IfOnTheGround();
            speed = 0.3f * gameObject2.GetComponent<Score>().score + 10f;
            float moveHorizontal = Input.GetAxis("Horizontal"); //��ȡˮƽ���뼴A/D/left��/right������ֵ  //Input���������¼���GetAxis��ȡ������仯������Horizontal����Ϊ�������
            float moveVertical = Input.GetAxis("Vertical"); //��ȡ��ֱ���뼴W/S/up��/down������ֵ//����Player�ƶ��ķ�����������ֵ
            if (Input.GetKey(KeyCode.Space) && a==true)
            {
                up = 10f;
            }
            else
            {
                up = 0f;
            }
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 upment = new Vector3(0,up, 0);
            //���ö�������Rigidbody����е�AddForce�������򰴼�����ʩ��һ����ʹ�ö����ƶ�
            playerRigidbody.AddForce(movement * speed);
            playerRigidbody.AddForce(upment * speed);

    }
    void OnCollisionEnter(Collision collision)     //a�������player�����Ѳ�׽�Ƿ�Ӵ��˵��棬��ֹ����
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            a = true;
            b = 1;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            a = false;
            b = 2;
        }
    }
    void IfOnTheGround()
    {
        foreach (GameObject theAttached in theAttacheds)//����Ѳ�׽��������һ����������aΪtrue�����������ײ����player��aҲΪtrue��������Ծ
        {
            if (theAttached.GetComponent<Attached>().a)
            {
                a = true;
            }
        }
 
    }
}