using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static private T _instance = null;
    static public T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] objs = FindObjectsOfType<T>();
                if (objs.Length > 0)
                {
                    _instance = objs[0];
                    if (objs.Length > 1)
                    {
                        //Error
                    }
                }
                else
                {
                    //Fatal
                }

            }

            return _instance;
        }
    }
}
