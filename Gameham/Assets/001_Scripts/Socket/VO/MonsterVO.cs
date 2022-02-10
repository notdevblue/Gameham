using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Server.VO
{
    [Serializable]
    public class MonsterVO
    {
        //randomPlayerId -> 처음 어그로가 지정되는 플레이어의 ID
        //curTime -> 지금 진행된 시간
        //spawnMonsterIds -> 스폰되는 몬스터들의 ID
        //randomPos -> 몬스터가 스폰되는 위치 -- 어그로 된 플레이어의 로컬 좌표로 이동

        public int randomPlayerId;
        public int curTime;
        public int[] spawnMonsterIds;
        public Vector2 randomPos;

        public MonsterVO(int randomPlayerId, int curTime, int[] spawnMonsterIds, Vector2 randomPos)
        {
            this.randomPlayerId = randomPlayerId;
            this.curTime = curTime;
            this.spawnMonsterIds = spawnMonsterIds;
            this.randomPos = randomPos;
        }
    }

}