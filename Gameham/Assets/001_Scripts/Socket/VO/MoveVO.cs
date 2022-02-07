using System;
using UnityEngine;

namespace Server.VO
{
    [Serializable]
    public class MoveVO
    {
        public int id;
        public Vector2 pos;

        public MoveVO(int id, Vector2 pos)
        {
            this.id = id;
            this.pos = pos;
        }
    }
}