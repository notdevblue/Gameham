using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 유니티가 mainThread이외에는 리소스 건들지 말라해서 만든 큐를 관리하기 위한 클래스
/// Enqueue하면 알아서 실행시켜줌니다
/// </summary>
public class ThreadQueue
{
    private Queue<Action> threadQueue = new Queue<Action>();

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="monoBehaviour">실행시킬려고 하는 위치의 monoBehaviour</param>
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
