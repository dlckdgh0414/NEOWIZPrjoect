using UnityEngine;

public class SoulBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    public Rigidbody _rbCompo { get; set; }
    [SerializeField] private float damge;
    private Vector3 _mover = Vector3.zero;
    public Entity _entity { get; set; }
    [SerializeField] private LayerMask _whatIsSheld;
    [SerializeField] private LayerMask _whatIsEnemy;
    public bool _isReflect { get; set; } = false;

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



    private void OnTriggerEnter(Collider other)
    {
        if((1 << other.transform.gameObject.layer & _whatIsEnemy) != 0 && _isReflect)
        {
            IDamgable damgable = other.GetComponentInChildren<IDamgable>();
            CameraManager.Instance.ShakeCamera(1, 0.15f);
            damgable.ApplyDamage(damge, false, 0, _entity);
            Destroy(gameObject);
        }
        else if (other.gameObject.TryGetComponent(out Player player))
        {
            CameraManager.Instance.ShakeCamera(1, 0.15f);
            player.ApplyDamage(damge, false, 0, _entity);
            Destroy(gameObject);
        }
    }
}
