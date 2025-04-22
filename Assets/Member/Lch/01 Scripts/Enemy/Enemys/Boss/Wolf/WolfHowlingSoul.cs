using UnityEngine;

public class WolfHowlingSoul : MonoBehaviour
{
    private Vector3 _movDir;
    [SerializeField] private float speed;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetDir(Transform target)
    {
        _movDir = target.position - transform.position;
        _movDir.y = 0;
        _movDir.Normalize();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _movDir * speed;
    }

}
