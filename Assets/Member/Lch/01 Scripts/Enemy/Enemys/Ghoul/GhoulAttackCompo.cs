using UnityEngine;

public class GhoulAttackCompo : Attack
{
    private Collider _attackCollider;
    [SerializeField] private float damge;
    [SerializeField] private Entity _entity;
    private void Awake()
    {
        _attackCollider = GetComponent<Collider>();
        _attackCollider.enabled = false;
    }
    public override void EnemyAttack(Transform target, Entity entity)
    {
        _attackCollider.enabled=true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("°ø°ÝÇÒ°í¾ä");
            if(other.TryGetComponent(out IDamgable damgable))
            {
                damgable.ApplyDamage(damge, false, 0, _entity);
            }
        }
    }
}
