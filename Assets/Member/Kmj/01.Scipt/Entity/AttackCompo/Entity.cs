using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
public abstract class Entity : MonoBehaviour
{

    public delegate void OnDamageHandler(float damage, Vector2 direction, Entity dealer);
    public event OnDamageHandler OnDamage;

    public UnityEvent OnHit;
    public UnityEvent OnDead;

    public bool IsDead { get; set; }
    public int DeadBodyLayer { get; private set; }

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

    protected virtual void AfterInitialize()
    {
        _componets.Values.OfType<IAfterInit>().ToList().ForEach(compo => compo.AfterInit());
        OnHit.AddListener(HandleHit);
        OnDead.AddListener(HandleDead);
    }

    protected virtual void OnDestroy()
    {
        OnHit.RemoveListener(HandleHit);
        OnDead.RemoveListener(HandleDead);
    }

    private void InitializeComponts()
    {
        _componets.Values.ToList().ForEach(comp => comp.Initialize(this));
    }

    public T GetCompo<T>() where T : IEntityComponet
        => (T)_componets.GetValueOrDefault(typeof(T));

    protected abstract void HandleHit();
    protected abstract void HandleDead();
}
