using UnityEngine;

public class GhoulAttackCompo : Attack
{
    [SerializeField] private float damge;
    [SerializeField] private Entity _entity;
    [SerializeField] private BoxCollider attackTrigger;

    private void Awake()
    {
        attackTrigger.enabled = false;
    }
    public override void EnemyAttack(Transform target, Entity entity)
    {
        attackTrigger.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            IDamgable damgable = player.GetComponentInChildren<IDamgable>();
            CameraManager.Instance.ShakeCamera(1, 0.15f);
            damgable.ApplyDamage(damge,false,0,_entity);
            attackTrigger.enabled = false;
        }
    }
}
