using Server.Core;
using Server.VO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터
// 플레이어가 모여있는 룸에서 게임을 시작하면 몬스터 생성도 같이 시작한다
// 플레이어 수에 비례해서 몬스터의 수나 체력을 증가시킨다 -> 몬스터의 수를 늘리는 것보다 체력 늘리는 것이 좋아보임
// 그리고 시간에 따라서 보내주는 몬스터의 종류나 수가 달라져야 함

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

            // 여기에서 모든 몬스터들의 풀링을 해줄거임
            PoolManager.CreatePool<Beetle>(beetlePrefab, monsterParent, 50);

            monsterIdSpawn.Add(1, () => PoolManager.GetItem<Beetle>(beetlePrefab));

            // 게임이 시작 된 이후 실행되는 코드
            BufferHandler.Instance.Add("Monster", data =>
            {
                _threadQueue.Enqueue(() =>
                {
                    MonsterVO vo = JsonUtility.FromJson<MonsterVO>(data);

                    // 받은 데이터와 똑같이 생성만 하면 됨

                    for(int i = 0; i < vo.spawnMonsterIds.Length; i++)
                    {
                        Monster m = monsterIdSpawn[vo.spawnMonsterIds[i]]();
                        // 여기서 몬스터의 위치랑 어그로 지정하기
                    }

                    // 몬스터아이디와 일치하는 몬스터를 소환하고 어그로된 플레이어의 로컬좌표 + 랜덤 좌표로 이동한뒤
                    // 그 이후는 어그로 걸린 플레이어를 계속해서 따라간다.
                    // 하지만 지금은 플레이어의 정보를 얻을 수 없으니 이후에 작성
                });
            });
        }
    }

}
