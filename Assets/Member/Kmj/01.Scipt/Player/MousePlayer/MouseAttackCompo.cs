
using UnityEngine;

public class MouseAttackCompo : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsEnemy;
    
   [SerializeField] private Animator _animator;

    private MousePlayer _player;
    [SerializeField] private float _damage;

    //[SerializeField] private MousePlayerEnergy _energyCompo;

    private int animValue;

    private void Awake()
    {
        _player = GetComponentInParent<MousePlayer>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _whatIsEnemy) != 0)
        {
            CameraManager.Instance.ShakeCamera(_damage / 2, 1 / 2);
            print("±â¸ðµü");
            print(other .name);
            _player.ChangeState("ATTACK");
            other.gameObject.GetComponentInChildren<IDamgable>().ApplyDamage(_damage, false, 0, _player);
     //       _energyCompo.energy += 5f;
        }
    }

}
