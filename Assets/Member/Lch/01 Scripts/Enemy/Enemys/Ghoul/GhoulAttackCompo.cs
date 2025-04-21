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
            if(other.gameObject.TryGetComponent(out IDamgable damgable))
            {
                Debug.Log("°ø°ÝÇÒ°í¾ä");
                damgable.ApplyDamage(damge, false, 0, _entity);
            }
        }
    }
}
