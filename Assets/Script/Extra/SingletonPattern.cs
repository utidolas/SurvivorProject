using UnityEngine;

public class SingletonPattern<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    // Ensure that there is only one instance of the singleton 
    protected virtual void Awake()
    {
        Instance = this as T;
    }
}
