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
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.TryGetComponent(out IDamgable damgable))
            {
                damgable.ApplyDamage(damage, false, 0, _entity);
            }
        }
    }
}
