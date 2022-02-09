using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ����Ƽ�� mainThread�̿ܿ��� ���ҽ� �ǵ��� �����ؼ� ���� ť�� �����ϱ� ���� Ŭ����
/// Enqueue�ϸ� �˾Ƽ� ��������ܴϴ�
/// </summary>
public class ThreadQueue
{
    private Queue<Action> threadQueue = new Queue<Action>();

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="monoBehaviour">�����ų���� �ϴ� ��ġ�� monoBehaviour</param>
    public ThreadQueue(MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(CheckQueue());
    }

    public void Enqueue(Action action)
    {
        threadQueue.Enqueue(action);
    }

    IEnumerator CheckQueue()
    {
        while(true)
        {
            if(threadQueue.Count != 0)
            {
                threadQueue.Dequeue().Invoke();
            }
            yield return null;
        }
    }
}
