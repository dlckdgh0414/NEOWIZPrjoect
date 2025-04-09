using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour, IDamgable, IEntityComponet
{
    [SerializeField] private StatSO hpStat;
    public float maxHealth;

    private float currentHealth;
    public event Action<Vector2> OnKnockback;

    private Entity _entity;
    private EntityStat _statCompo;


    private void OnDestroy()
    {
        _statCompo.GetStat(hpStat).OnValueChange -= HandleHpChange;
        _entity.OnDamage -= ApplyDamage;
    }

    private void Awake()
    {
        AfterInit();
        currentHealth = 10;
    }

    private void Update()
    {
        Debug.Log(currentHealth);
    }


    public void Initialize(Entity entity)
    {
        _entity = entity;
        _statCompo = entity.GetCompo<EntityStat>();
    }

    public void AfterInit()
    {
        _statCompo.GetStat(hpStat).OnValueChange += HandleHpChange;
        currentHealth = maxHealth = _statCompo.GetStat(hpStat).Value;
        _entity.OnDamage += ApplyDamage;
    }

    private void HandleHpChange(StatSO stat, float current, float previous)
    {
        maxHealth = current;
        currentHealth = Mathf.Clamp(currentHealth + current - previous, 1f, maxHealth);
    }


    public void ApplyDamage(float damage, bool isStop, Entity delear)
    {
        if (_entity.IsDead) return;

        currentHealth = Mathf.Clamp(currentHealth -= damage, 0, maxHealth);
    }
}
