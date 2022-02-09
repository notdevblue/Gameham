using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Server.Core;
using Server.VO;
using Player.Level;
using Server.Client.Core;

public class ButtonManager : MonoBehaviour
{
    [Header("편하라고 쓰고있는 것들 나중에 지워야함")]
    public ClientBase _clientBase;

    [Header("버튼들 여기다 넣으면 됨")]
    [SerializeField] Button levelUpSelectBtn;
    [SerializeField] Button autoLevelUpBtn;

    private void Awake()
    {
        levelUpSelectBtn.onClick.AddListener(() => // 어떤 아이템을 획득할 때 발동함 테스트 용임
        {
            // 여기서 보낼때 획득한 아이템 같은걸 보내주어도 괜찮을 듯 
            SocketCore.Instance.Send(new DataVO("levelUpSelected", ""));
        });

        // 누르면 바로 레벨업 되는 버튼 - 임시용 나중에 지울거임
        autoLevelUpBtn.onClick.AddListener(() =>
        {
            PlayerLevel.Instance.AddXp(5, _clientBase);
        });
    }
}
