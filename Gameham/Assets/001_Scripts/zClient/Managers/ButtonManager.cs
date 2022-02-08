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
        levelUpSelectBtn.onClick.AddListener(() => // � �������� ȹ���� �� �ߵ��� �׽�Ʈ ����
        {
            // ���⼭ ������ ȹ���� ������ ������ �����־ ������ �� 
            SocketCore.Instance.Send(new DataVO("levelUpSelected", ""));
        });
    }
}
