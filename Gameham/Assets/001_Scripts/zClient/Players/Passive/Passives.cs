using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Passive
{
    public enum PassiveType
    {
        BulletCount,
        ShotCoolTime,
        BulletSpeed,
        LifeTime,
        Damage,
        moveSpeed,
        // 이후 추가될수도?
    }

    public class Passive
    {
        public int[] passiveValue;
        public int maxLevel;
        public int curLevel;

        public Passive(int maxLevel, int curLevel, int[] passiveValue)
        {
            this.maxLevel = maxLevel;
            this.curLevel = curLevel;
            this.passiveValue = passiveValue;
        }
    }

}

namespace Player.Passive.Passives
{
    public class Passives : MonoSingleton<Passives>
    {
        Dictionary<PassiveType, Passive> passiveDict = new Dictionary<PassiveType, Passive>();



        private void Awake()
        {
            passiveDict.Add(PassiveType.BulletCount, new Passive(2, 0, new int[2] { 1, 2 }));
            passiveDict.Add(PassiveType.ShotCoolTime, new Passive(6, 0, new int[6] { 8, 16, 24, 32, 40, 48 }));
            passiveDict.Add(PassiveType.BulletSpeed, new Passive(6, 0, new int[6] { 5, 10, 15, 20, 25, 30 }));
            passiveDict.Add(PassiveType.LifeTime, new Passive(6, 0, new int[6] { 10, 20, 30, 40, 50, 60 }));
            passiveDict.Add(PassiveType.Damage, new Passive(6, 0, new int[6] { 10, 20, 30, 40, 50, 60 }));
            passiveDict.Add(PassiveType.moveSpeed, new Passive(6, 0, new int[6] { 10, 20, 30, 40, 50, 60 }));
        }

        public void LevelUp(PassiveType type)
        {
            passiveDict[type].curLevel++;
        }

        public int GetValue(PassiveType type)
        {
            if (passiveDict[type].curLevel == 0) return 0;

            return passiveDict[type].passiveValue[passiveDict[type].curLevel - 1];
        }

        public bool isMaxLevel(PassiveType type)
        {
            return passiveDict[type].maxLevel == passiveDict[type].curLevel;
        }
    }
}