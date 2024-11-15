using UnityEngine;
using Unity.VisualScripting;
    public class BallMove : MonoBehaviour
    {
        public float speed,up;//����ƶ��ٶ�
        private bool a;//��Ҫ�õ������Rigidbody�������ʵ���ƶ�����
        private Rigidbody playerRigidbody;
    void Start()
        {
            a = false;            //��ȡ���ö���Inspector����е�Rigidbody���
            playerRigidbody = this.GetComponent<Rigidbody>();
        }
        //����涨��ÿһ֡�������һ�Σ�������Ϊ��ͬ���Ե����������ͬʱ��λ�Ʋ�ͬ��
        //������ProjectSettings-Time������
        void FixedUpdate()
        {
            //��ȡ�û����룬�����ڲ˵�����Edit-ProjectSettings-InputManager�в鿴�����޸�
            //Input���������¼���GetAxis��ȡ������仯������Horizontal����Ϊ�������
            float moveHorizontal = Input.GetAxis("Horizontal"); //��ȡˮƽ���뼴A/D/left��/right������ֵ
            float moveVertical = Input.GetAxis("Vertical"); //��ȡ��ֱ���뼴W/S/up��/down������ֵ//����Player�ƶ��ķ�����������ֵ
            if (Input.GetKey(KeyCode.Space) && a==true)
            {
                up = 20f;
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
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                a = true;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                a = false;
            }
        }
    }