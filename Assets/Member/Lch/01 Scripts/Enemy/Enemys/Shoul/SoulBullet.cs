using UnityEngine;

public class SoulBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody _rbCompo;
    [SerializeField] private float damge;
    private Vector3 _mover = Vector3.zero;
    private Entity _entity;
    [SerializeField] private LayerMask _whatIsSheld;
    [SerializeField] private LayerMask _whatIsEnemy;
    private bool _isReflect = false;

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

        if (((1 << other.transform.gameObject.layer) & _whatIsSheld) != 0 && 
            other.GetComponent<BarrerCompo>().isPalling)
        {
            Vector3 reflectDir = (_entity.transform.position - transform.position).normalized;
            _rbCompo.linearVelocity = reflectDir * _rbCompo.linearVelocity.magnitude; 
            _entity = null;
            _isReflect = true;
        }
        else if (((1 << other.transform.gameObject.layer) & _whatIsSheld) != 0)
        {
            gameObject.SetActive(false);
        }
        else if((1 << other.transform.gameObject.layer & _whatIsEnemy) != 0 && _isReflect)
        {
            IDamgable damgable = other.GetComponentInChildren<IDamgable>();
            CameraManager.Instance.ShakeCamera(1, 0.15f);
            damgable.ApplyDamage(damge, false, 0, _entity);
            Destroy(gameObject);
        }
        else if (other.gameObject.TryGetComponent(out Player player))
        {
            IDamgable damgable = player.GetComponentInChildren<IDamgable>();
            CameraManager.Instance.ShakeCamera(1, 0.15f);
            damgable.ApplyDamage(damge, false, 0, _entity);
            Destroy(gameObject);
        }
    }
}
