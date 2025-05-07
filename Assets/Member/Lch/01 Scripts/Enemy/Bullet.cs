using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected LayerMask _whatIsSheld;
    [SerializeField] protected LayerMask _whatIsEnemy;
    public bool _isReflect { get; set; } = false;
    protected Rigidbody _rbCompo;

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody>();
    }

}
