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
    [Header("���϶�� �����ִ� �͵� ���߿� ��������")]
    public ClientBase _clientBase;

    [Header("��ư�� ����� ������ ��")]
    [SerializeField] Button levelUpSelectBtn;
    [SerializeField] Button autoLevelUpBtn;

    private void Awake()
    {
        levelUpSelectBtn.onClick.AddListener(() => // � �������� ȹ���� �� �ߵ��� �׽�Ʈ ����
        {
            // ���⼭ ������ ȹ���� ������ ������ �����־ ������ �� 
            SocketCore.Instance.Send(new DataVO("levelUpSelected", ""));
        });

        // ������ �ٷ� ������ �Ǵ� ��ư - �ӽÿ� ���߿� �������
        autoLevelUpBtn.onClick.AddListener(() =>
        {
            PlayerLevel.Instance.AddXp(5, _clientBase);
        });
    }
}
