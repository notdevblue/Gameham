using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player.Level
{
    public class PlayerLevel : Singleton<PlayerLevel>, ISingletonObject
    {
        public int level = 1;
        public int LevelUpXp = 4;
        public int curXp = 0;

        public void LevelUp()
        {
            level++;
            curXp -= LevelUpXp;
            LevelUpXp = level;

            // ������ �۾� ���⼭ �ϱ�!
        }
    }
}