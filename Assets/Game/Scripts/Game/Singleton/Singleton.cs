using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool _isInitialized = false;

    public static T Instance
    {
        get
        {
            if (_instance == null && !_isInitialized)
            {
                _instance = FindFirstObjectByType<T>();
                _isInitialized = true;

                if (_instance == null)
                {
                    Debug.LogError($"[Singleton] Ёкземпл€р {typeof(T)} не найден в сцене.");
                }
            }

            return _instance;
        }
    }

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (_instance != this)
        {
            Debug.LogWarning($"[Singleton] ¬торой экземпл€р {typeof(T)} найден и будет уничтожен.");
            Destroy(gameObject);
        }
    }
}
