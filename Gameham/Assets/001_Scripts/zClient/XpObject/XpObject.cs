using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Level;
using Server.Client.Core;

public class XpObject : MonoBehaviour
{
    public int giveXp = 1;

    public void GetXp(ClientBase me)
    {
        PlayerLevel.Instance.AddXp(giveXp, me);
    }
}
