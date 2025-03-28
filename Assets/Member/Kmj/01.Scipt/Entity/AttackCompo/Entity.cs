using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    protected Dictionary<Type, IEntityComponet> _componets;

    public Action<float, Vector2 > OnDamage;

    public Action OnDead;

    public bool IsDead { get; private set; } = false;

    protected virtual void Awake()
    {
        _componets = new Dictionary<Type, IEntityComponet>();
        AddComponets();
        InitializeComponts();
    }

    private void AddComponets()
    {
        GetComponentsInChildren<IEntityComponet>().ToList().
            ForEach(comp => _componets.Add(comp.GetType(), comp));
    }

    private void InitializeComponts()
    {
        _componets.Values.ToList().ForEach(comp => comp.Initialize(this));
    }

    public T GetCompo<T>() where T : IEntityComponet
        => (T)_componets.GetValueOrDefault(typeof(T));
}
