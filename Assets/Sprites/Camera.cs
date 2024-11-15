using UnityEngine;
using Chapter01;

namespace Chapter01
{
    public class Camera : MonoBehaviour
    {
        public GameObject player;//�������Ҫ����Ķ���
        private Vector3 offset;//�����������λ�Ʋ�ֵ
        void Start()
        {
            //ͨ��GameObject���е�FindGameObjectWithTag����
            //���������ҵ������д�Player��ǩ�ĵ�һ������
            player = GameObject.FindGameObjectWithTag("Player");
            //�����������Player��ҳ�ʼλ�õ�λ�Ʋ�ֵ
            //ͨ�������transform�����position����ֵ�ռ��е�λ�ã�x,y,z)�������
            offset = this.transform.position - player.transform.position;
        }
        //LateUpdate������Update��������֮���Զ�����
        void LateUpdate()
        {
            //��ȡPlayer���µ�λ��������ϳ�ʼ������������transform�����positionλ��
            this.transform.position = player.transform.position + offset;
        }
    }
}
