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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.TryGetComponent(out IDamgable damgable))
            {
                damgable.ApplyDamage(damge,false,_entity);
                Destroy(gameObject); 
            }
        }
    }
}
