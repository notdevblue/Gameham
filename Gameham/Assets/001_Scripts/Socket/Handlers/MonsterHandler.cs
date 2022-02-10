using Server.Core;
using Server.VO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����
// �÷��̾ ���ִ� �뿡�� ������ �����ϸ� ���� ������ ���� �����Ѵ�
// �÷��̾� ���� ����ؼ� ������ ���� ü���� ������Ų�� -> ������ ���� �ø��� �ͺ��� ü�� �ø��� ���� ���ƺ���
// �׸��� �ð��� ���� �����ִ� ������ ������ ���� �޶����� ��

namespace Server.Handler
{
    public class MonsterHandler : MonoBehaviour
    {
        [SerializeField] private Transform monsterParent;

        [SerializeField] private GameObject beetlePrefab;

        private void Awake()
        {
            // ���⿡�� ��� ���͵��� Ǯ���� ���ٰ���
            PoolManager.CreatePool<Beetle>(beetlePrefab, monsterParent, 50);


            // ������ ���� �� ���� ����Ǵ� �ڵ�
            BufferHandler.Instance.Add("Monster", data =>
            {
                MonsterVO vo = JsonUtility.FromJson<MonsterVO>(data);

                // ���� �����Ϳ� �Ȱ��� ������ �ϸ� ��

                Beetle b = PoolManager.GetItem<Beetle>(beetlePrefab);

                // ���;��̵�� ��ġ�ϴ� ���͸� ��ȯ�ϰ� ��׷ε� �÷��̾��� ������ǥ + ���� ��ǥ�� �̵��ѵ�
                // �� ���Ĵ� ��׷� �ɸ� �÷��̾ ����ؼ� ���󰣴�.
                // ������ ������ �÷��̾��� ������ ���� �� ������ ���Ŀ� �ۼ�
            });
        }
    }

}
