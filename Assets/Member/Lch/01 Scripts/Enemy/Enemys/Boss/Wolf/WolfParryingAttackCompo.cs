using UnityEngine;

public class WolfParryingAttackCompo : Attack
{

    private WolfParryingBullet _bullet;
    private Collider _parryingCollider;
    private Transform _target;
    [SerializeField] private LayerMask _whatIsBlockObj;
    public int ParryingCount { get; private set; } = 1;

    private void Awake()
    {
        _parryingCollider = GetComponent<Collider>();
        _parryingCollider.enabled = false;
    }

    public override void EnemyAttack(Transform target, Entity entity)
    {
        FireBullet(target,_bullet, entity);
    }

    private void FireBullet(Transform target, WolfParryingBullet bullet, Entity entity)
    {
        _bullet.Fire(target.position,entity);
    }

    public void SetBullet(WolfParryingBullet bullet)
    {
        _bullet = bullet;
    }

    public void ParryingCollider(Transform target)
    {
        _target = target;
        _parryingCollider.enabled = true;
    }

    public void ParryingEnd()
    {
        _target = null;
        _parryingCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.transform.gameObject.layer) & _whatIsBlockObj) != 0)
        {
            Rigidbody rb = other.attachedRigidbody;

            other.TryGetComponent(out Bullet bullet);


            if (rb != null && bullet._isReflect)
            {
                Vector3 currentVelocity = rb.linearVelocity;

                Vector3 bounceDirection = -currentVelocity.normalized;
                float forceMagnitude = currentVelocity.magnitude;

                rb.AddForce(bounceDirection * forceMagnitude * 2f, ForceMode.VelocityChange);
                ParryingCount++;
            }
        }
    }
}
