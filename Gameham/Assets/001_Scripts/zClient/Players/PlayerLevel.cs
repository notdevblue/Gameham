using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.VO;
using Server.Client.Core;

namespace Player.Level
{
    public class PlayerLevel : Singleton<PlayerLevel>, ISingletonObject
    {
        public int level = 1;
        public int LevelUpXp = 5;
        public int curXp = 0;
        
        public void AddXp(int xp, ClientBase me)
        {
            curXp += xp;

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
            string payload = JsonUtility.ToJson(new LevelVO(me.ID, level));
            SocketCore.Instance.Send(new DataVO("level", payload));
        }
    }
}