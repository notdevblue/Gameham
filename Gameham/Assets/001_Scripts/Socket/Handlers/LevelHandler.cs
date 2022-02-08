using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.Client.Core;
using Server.VO;

namespace Server.Handler
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private ClientBase clientBase;
        private void Awake()
        {
            BufferHandler.Instance.Add("level", data =>
            {
            // ���� ����
                GameManager.Instance.Pause();

                LevelVO vo = JsonUtility.FromJson<LevelVO>(data);

                // �������Ǹ� �������� ����ڰ� ���� �� ������ ��޷�����
                if (clientBase.ID.CompareTo(vo.id) == 0)
                {
                    // ���⸦ ������ ���� ����ڶ�� ���̱⿡
                    // ���� �� �� �ִ� �� ���ñ⸦ ��������
                }
            });
        }
    }
}