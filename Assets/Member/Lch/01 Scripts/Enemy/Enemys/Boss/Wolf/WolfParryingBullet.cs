using UnityEngine;

public class WolfParryingBullet : Bullet
{
    [SerializeField] private float speed = 10f;
  
    private Vector3 _direction;

    private Entity _entity;

    public void Fire(Vector3 dir,Entity entity)
    {
        _entity = entity;
        _direction = dir - transform.position ;
        _direction.y = 0 ;
        _direction.Normalize();
    }
    void Update()
    {
        if (_isReflect == false)
        {
            _rbCompo.linearVelocity = _direction*speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((1 << other.transform.gameObject.layer & _whatIsEnemy) != 0 && _isReflect)
        {
            IDamgable damgable = other.GetComponentInChildren<IDamgable>();
            CameraManager.Instance.ShakeCamera(1, 0.15f);
            damgable.ApplyDamage(0, false, 0, _entity);
            Destroy(gameObject);
        }
        else if (other.gameObject.TryGetComponent(out Player player))
        {
            CameraManager.Instance.ShakeCamera(1, 0.15f);
            player.ApplyDamage(0, false, 0, _entity);
            Destroy(gameObject);
        }
    }
}
