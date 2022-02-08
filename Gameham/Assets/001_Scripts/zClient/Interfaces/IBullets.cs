using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Bullets
{
    public interface IBullets
    {
        public void Test(); // Test 무기가 발사할 때 호출 될거임
        // 이후 무기 추가 될시 추가 작성하면 댐
    }
}