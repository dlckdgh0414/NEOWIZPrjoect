using UnityEngine;

public class WolfScratchAttackCompo : Attack
{
    private Collider _attackcollider;
    [SerializeField] private float damage;
    private Entity _entity;
    private void Awake()
    {
        _attackcollider = GetComponent<Collider>();
        _attackcollider.enabled = false;
    }
    public override void EnemyAttack(Transform target, Entity entity)
    {
        _entity = entity;
        _attackcollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            IDamgable damgable = player.GetComponentInChildren<IDamgable>();
            damgable.ApplyDamage(damage, false, 0, _entity);
        }
    }
}
