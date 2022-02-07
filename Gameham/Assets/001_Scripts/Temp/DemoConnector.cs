using Server.Core;
using UnityEngine;

public class DemoConnector : MonoBehaviour {
    private void Awake() {
        SocketCore.Instance.Connect();
    }
}