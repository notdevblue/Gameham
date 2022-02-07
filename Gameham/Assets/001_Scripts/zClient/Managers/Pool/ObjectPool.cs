using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : IPool where T : MonoBehaviour
{
    //private Queue<T> m_queue; // ���� ���� Queue �ڷᱸ���� ����ϱ⵵ �� 
    private List<T> m_list = new List<T>();     // ������ ��κ��� ��Ȳ���� List�� ����ϴ� ���� ���ϱ⿡ List ���
    private GameObject prefab;
    private Transform parent;

    public ObjectPool(GameObject prefab, Transform parent, int count = 5) // ������
    {
        this.prefab = prefab;
        this.parent = parent;

        for (int i = 0; i < count; i++) // count��ŭ object�� ����� ��Ȱ��ȭ ��Ų �� m_list�� �־��ش�
        {
            GameObject obj = GameObject.Instantiate(prefab, parent);
            T t = obj.GetComponent<T>();
            obj.SetActive(false);
            m_list.Add(t);
        }
    }

    public T GetOrCreate()
    {
        T t = m_list.Find(i => !i.gameObject.activeSelf); // Ȱ��ȭ ���� ���� ������Ʈ�� find

        if (t == null) // ���� find �ؼ� ã���� ���� ��� ���� �����
        {
            GameObject temp = GameObject.Instantiate(prefab, parent);
            temp.gameObject.SetActive(true);
            t = temp.GetComponent<T>();
            m_list.Add(t);
        }
        else
        {
            t.gameObject.SetActive(true);
        }

        return t;
    }
}
