using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Server.VO
{
    [Serializable]
    public class MonsterVO
    {
        //randomPlayerId -> ó�� ��׷ΰ� �����Ǵ� �÷��̾��� ID
        //curTime -> ���� ����� �ð�
        //spawnMonsterIds -> �����Ǵ� ���͵��� ID
        //randomPos -> ���Ͱ� �����Ǵ� ��ġ -- ��׷� �� �÷��̾��� ���� ��ǥ�� �̵�

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