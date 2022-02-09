using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Server.Core;
using Server.VO;
using Server.Client.Core;

namespace Player.Level
{
    /// <summary>
    /// ���� �ڽ��� ������ ���� �����͵��� ��Ƴ��� ��
    /// </summary>
    public class PlayerLevel : Singleton<PlayerLevel>, ISingletonObject
    {
        public int level = 1;
        public int LevelUpXp = 5;
        public int curXp = 0;
        
        public void AddXp(int xp, ClientBase me)
        {
            curXp += xp;
            Debug.Log("���� ����ġ : " + curXp);
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

            // ������ �۾� ���⼭ �ϱ�!
            string payload = JsonUtility.ToJson(new LevelUpVO(me.ID, level));
            SocketCore.Instance.Send(new DataVO("levelUp", payload));
        }
    }
}