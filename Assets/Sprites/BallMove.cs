using UnityEngine;
using Unity.VisualScripting;
    public class BallMove : MonoBehaviour
    {
        public float speed,up;//玩家移动速度
        private bool a;//需要用到对象的Rigidbody刚体组件实现移动功能
        private Rigidbody playerRigidbody;
    void Start()
        {
            a = false;            //获取到该对象Inspector面板中的Rigidbody组件
            playerRigidbody = this.GetComponent<Rigidbody>();
        }
        //物理规定的每一帧间隔调用一次，不会因为不同电脑的性能造成相同时间位移不同，
        //可以在ProjectSettings-Time中设置
        void FixedUpdate()
        {
            //获取用户输入，可以在菜单栏的Edit-ProjectSettings-InputManager中查看设置修改
            //Input调用输入事件，GetAxis获取方向轴变化，（”Horizontal“）为轴的名称
            float moveHorizontal = Input.GetAxis("Horizontal"); //获取水平输入即A/D/left键/right键输入值
            float moveVertical = Input.GetAxis("Vertical"); //获取垂直输入即W/S/up键/down键输入值//定义Player移动的方向向量并赋值
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
            //调用对象身上Rigidbody组件中的AddForce方法，向按键方向施加一个力使得对象移动
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