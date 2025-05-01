
using UnityEngine;

public class MouseAttackCompo : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsEnemy;
    
   [SerializeField] private Animator _animator;

    private MousePlayer _player;
    [SerializeField] private float _damage;

    //[SerializeField] private MousePlayerEnergy _energyCompo;

    private int animValue;
    [field: SerializeField] public Vector3 _boxSize { get; private set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,_boxSize);
        Gizmos.color = Color.white;
    }

}
