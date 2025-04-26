using UnityEngine;

public class SoulBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody _rbCompo;
    [SerializeField] private float damge;
    private Vector3 _mover = Vector3.zero;
    private Entity _entity;
    
    public void SetDir(Transform target,Entity entity)
    {
        _entity = entity;
        _mover = target.position - transform.position;
    }

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rbCompo.linearVelocity = _mover * bulletSpeed;
    }

    public void ReflectDir(Vector3 hitNormal)
    {
        Vector3 reflectedVelocity = Vector3.Reflect(_rbCompo.linearVelocity, hitNormal);
        _rbCompo.linearVelocity = reflectedVelocity * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            IDamgable damgable = player.GetComponentInChildren<IDamgable>();
            CameraManager.Instance.ShakeCamera(1, 0.15f);
            damgable.ApplyDamage(damge, false, 0, _entity);
            Destroy(gameObject);
        }
    }
}
