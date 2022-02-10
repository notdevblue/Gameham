using Server.Core;
using Server.VO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSender : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SocketCore.Instance.Send(new DataVO("testSpawner", ""));
        }
    }
}
