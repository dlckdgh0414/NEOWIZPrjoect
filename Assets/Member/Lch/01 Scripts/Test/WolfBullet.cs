using UnityEngine;

public class WolfBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 5f;
    private Rigidbody _rbCompo;

    private float _timer = 0f;
    private Vector3 _direction;

    private Entity _entity;
    public void Fire(Vector3 dir,Entity entity)
    {
        _entity = entity;
        _direction = dir.normalized;
        _timer = 0f;
    }

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rbCompo.linearVelocity = _direction * Time.deltaTime;
        _timer += Time.deltaTime;

        if (_timer >= lifeTime)
            Destroy(gameObject);
    }
}

