using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Server.Core;
using Server.VO;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button levelUpSelectBtn;

    private void Awake()
    {
        levelUpSelectBtn.onClick.AddListener(() => // 어떤 아이템을 획득할 때 발동함 테스트 용임
        {
            // 여기서 보낼때 획득한 아이템 같은걸 보내주어도 괜찮을 듯 
            SocketCore.Instance.Send(new DataVO("levelUpSelected", ""));
        });
    }
}
