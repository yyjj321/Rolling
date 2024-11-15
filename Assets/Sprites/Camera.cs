using UnityEngine;
using Chapter01;

namespace Chapter01
{
    public class Camera : MonoBehaviour
    {
        public GameObject player;//摄像机需要跟随的对象
        private Vector3 offset;//摄像机与对象的位移差值
        void Start()
        {
            //通过GameObject类中的FindGameObjectWithTag（）
            //方法可以找到场景中带Player标签的第一个对象
            player = GameObject.FindGameObjectWithTag("Player");
            //计算摄像机与Player玩家初始位置的位移插值
            //通过获得其transform组件的position属性值空间中的位置（x,y,z)进行求差
            offset = this.transform.position - player.transform.position;
        }
        //LateUpdate将会在Update（）方法之后自动调用
        void LateUpdate()
        {
            //获取Player最新的位置坐标加上初始坐标差后跟新相机transform组件的position位置
            this.transform.position = player.transform.position + offset;
        }
    }
}
