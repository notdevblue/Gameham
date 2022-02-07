using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Level;

public class XpObject : MonoBehaviour
{
    public int giveXp = 1;

    public void GetXp()
    {
        PlayerLevel.Instance.curXp += giveXp;
        
        if(PlayerLevel.Instance.curXp >= PlayerLevel.Instance.LevelUpXp)
        {
            // ·¹º§¾÷
            PlayerLevel.Instance.LevelUp();
        }
    }
}
