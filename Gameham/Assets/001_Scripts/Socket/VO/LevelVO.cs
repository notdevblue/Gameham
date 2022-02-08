using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Server.VO
{
    [Serializable]
    public class LevelVO
    {
        public int id;
        public int level;

        public LevelVO(int id, int level)
        {
            this.id = id;
            this.level = level;
        }
    }
}