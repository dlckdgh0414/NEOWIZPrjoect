using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
        if(other.gameObject.layer == _whatIsEnemy)
        {
            other.gameObject.GetComponentInChildren<IDamgable>().ApplyDamage(_damage, false,0, _player);
            _player.ChangeState("ATTACK");
        }
    }

}
