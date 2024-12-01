using UnityEngine;
using Unity.VisualScripting;
public class BallMove : MonoBehaviour
{
        public float speed,up;//玩家移动速度
        private bool a;//a用来检测player或者已捕捉是否接触了地面，防止连跳
        private Rigidbody playerRigidbody;//需要用到对象的Rigidbody刚体组件实现移动功能
        public GameObject gameObject2;
        private GameObject[] theAttacheds;
        int b;
    void Start()
        {
            a = false;            //获取到该对象Inspector面板中的Rigidbody组件
            playerRigidbody = this.GetComponent<Rigidbody>();
            gameObject2 = GameObject.FindWithTag("Score");
            b = 2;

    }
        //物理规定的每一帧间隔调用一次，不会因为不同电脑的性能造成相同时间位移不同，
        //可以在ProjectSettings-Time中设置
    void FixedUpdate()
        {
        if (b != 1)
        {
            a = false;
            //Debug.Log(b);
        }
        //获取用户输入，可以在菜单栏的Edit-ProjectSettings-InputManager中查看设置修改
           theAttacheds  = GameObject.FindGameObjectsWithTag("已捕捉");
           //Debug.Log(theAttacheds);
           IfOnTheGround();
            speed = 0.3f * gameObject2.GetComponent<Score>().score + 10f;
            float moveHorizontal = Input.GetAxis("Horizontal"); //获取水平输入即A/D/left键/right键输入值  //Input调用输入事件，GetAxis获取方向轴变化，（”Horizontal“）为轴的名称
            float moveVertical = Input.GetAxis("Vertical"); //获取垂直输入即W/S/up键/down键输入值//定义Player移动的方向向量并赋值
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
            //调用对象身上Rigidbody组件中的AddForce方法，向按键方向施加一个力使得对象移动
            playerRigidbody.AddForce(movement * speed);
            playerRigidbody.AddForce(upment * speed);

    }
    void OnCollisionEnter(Collision collision)     //a用来检测player或者已捕捉是否接触了地面，防止连跳
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
        foreach (GameObject theAttached in theAttacheds)//如果已捕捉物体中有一个以上物体a为true，即与地面碰撞，则player的a也为true，允许跳跃
        {
            if (theAttached.GetComponent<Attached>().a)
            {
                a = true;
            }
        }
 
    }
}