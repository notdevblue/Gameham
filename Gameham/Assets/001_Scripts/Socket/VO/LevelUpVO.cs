using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Server.VO
{
    [Serializable]
    public class LevelUpVO
    {
        public int id;
        public int level;

        public LevelUpVO(int id, int level)
        {
            this.id = id;
            this.level = level;
        }
    }
}