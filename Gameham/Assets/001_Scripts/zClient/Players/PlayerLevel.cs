using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.VO;
using Server.Client.Core;

namespace Player.Level
{
    /// <summary>
    /// 지금 자신의 레벨에 대한 데이터들을 모아놓은 것
    /// </summary>
    public class PlayerLevel : Singleton<PlayerLevel>, ISingletonObject
    {
        public int level = 1;
        public int LevelUpXp = 5;
        public int curXp = 0;
        
        public void AddXp(int xp, ClientBase me)
        {
            curXp += xp;
            Debug.Log("지금 경험치 : " + curXp);
            if(curXp >= LevelUpXp)
            {
                LevelUp(me);
            }
        }

        public void LevelUp(ClientBase me)
        {
            level++;
            curXp -= LevelUpXp;
            LevelUpXp += level;

            // 레벨업 작업 여기서 하기!
            string payload = JsonUtility.ToJson(new LevelUpVO(me.ID, level));
            SocketCore.Instance.Send(new DataVO("levelUp", payload));
        }
    }
}