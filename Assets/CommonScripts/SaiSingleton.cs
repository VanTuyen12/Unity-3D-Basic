
using UnityEngine;

public abstract class SaiSingleton<T> : SaiMonoBehaviour where T : SaiMonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null) Debug.LogError("Singleton instance has not been created yet!");
            return _instance;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (_instance == null)
        {
            _instance = this as T;
            if(transform.parent == null) DontDestroyOnLoad(gameObject);//Giu nguyen object nay cho scene k bi xoa
            return;
        }

        if (_instance != this) Debug.LogError("Another instance of SingletonExample already exists!");
    }
}
