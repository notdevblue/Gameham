using System;

/// <summary>
/// Mono 상속을 받지 않는 클래스를 위한 Singleton
/// </summary>
abstract public class Singleton<T> where T : class
{
    static private T _instance;
    static public T Instance {
        get {
            if(_instance == null) {
                _instance = Activator.CreateInstance<T>();
                GC.KeepAlive(_instance);
            }

            return _instance;
        }
    }
}