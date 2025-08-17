using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolComponents<T> where T : Component
{
    private T _prefab;
    private Transform _parent;
    public List<T> _objects;

    public PoolComponents(T prefab, Transform parent = null, int prewarmObjects = 5)
    {
        _prefab = prefab;
        _parent = parent;
        _objects = new List<T>();

        for (int i = 0; i < prewarmObjects; i++)
        {
            var obj = GameObject.Instantiate(_prefab, parent);
            obj.gameObject.SetActive(false);
            _objects.Add(obj);
        }
    }

    public T Get()
    {
        var obj = _objects.FirstOrDefault(x => !x.gameObject.activeSelf);

        if (obj == null) obj = Create();

        obj.gameObject.SetActive(true);
        return obj;
    }

    public List<T> GetAll()
    {
        return _objects;
    }

    public void Realese(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    private T Create()
    {
        var obj = GameObject.Instantiate(_prefab, _parent);
        _objects.Add(obj);
        return obj;
    }
}
