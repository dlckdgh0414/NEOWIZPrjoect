using UnityEngine;

public class WolfBitingAttackCompo : Attack
{
    [SerializeField] private float damage;
    private Collider _attackCollider;
    private Entity _entity;

    private void Awake()
    {
        _attackCollider = GetComponent<Collider>();   
    }

    private void Start()
    {
        _attackCollider.enabled = false;
    }

    public override void EnemyAttack(Transform target, Entity entity)
    {
        _attackCollider.enabled = true;
        _entity = entity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
             IDamgable damgable = player.GetComponentInChildren<IDamgable>();
             damgable.ApplyDamage(damage, false, 0, _entity);
        }
    }
}
