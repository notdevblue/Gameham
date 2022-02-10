using Server.Core;
using Server.VO;
using System;
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

        private ThreadQueue _threadQueue;

        private Dictionary<int, Func<Monster>> monsterIdSpawn = new Dictionary<int, Func<Monster>>();

        private void Awake()
        {
            _threadQueue = new ThreadQueue(this);

            // ���⿡�� ��� ���͵��� Ǯ���� ���ٰ���
            PoolManager.CreatePool<Beetle>(beetlePrefab, monsterParent, 50);

            monsterIdSpawn.Add(1, () => PoolManager.GetItem<Beetle>(beetlePrefab));

            // ������ ���� �� ���� ����Ǵ� �ڵ�
            BufferHandler.Instance.Add("Monster", data =>
            {
                _threadQueue.Enqueue(() =>
                {
                    MonsterVO vo = JsonUtility.FromJson<MonsterVO>(data);

                    // ���� �����Ϳ� �Ȱ��� ������ �ϸ� ��

                    for(int i = 0; i < vo.spawnMonsterIds.Length; i++)
                    {
                        Monster m = monsterIdSpawn[vo.spawnMonsterIds[i]]();
                        // ���⼭ ������ ��ġ�� ��׷� �����ϱ�
                    }

                    // ���;��̵�� ��ġ�ϴ� ���͸� ��ȯ�ϰ� ��׷ε� �÷��̾��� ������ǥ + ���� ��ǥ�� �̵��ѵ�
                    // �� ���Ĵ� ��׷� �ɸ� �÷��̾ ����ؼ� ���󰣴�.
                    // ������ ������ �÷��̾��� ������ ���� �� ������ ���Ŀ� �ۼ�
                });
            });
        }
    }

}
