
using UnityEngine;

public class MouseAttackCompo : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsEnemy;
    
   [SerializeField] private Animator _animator;

    private MousePlayer _player;
    [SerializeField] private float _damage;

    private MousePlayerEnergy _energyCompo;

    private int animValue;

    private void Awake()
    {
        _player = GetComponentInParent<MousePlayer>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print(gameObject.name);
            _player.ChangeState("ATTACK");
            other.gameObject.GetComponentInChildren<IDamgable>().ApplyDamage(_damage, false, 0, _player);
            _energyCompo.energy += 5f;
        }
    }

}
