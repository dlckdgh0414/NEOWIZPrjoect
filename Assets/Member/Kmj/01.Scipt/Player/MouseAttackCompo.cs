using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MouseAttackCompo : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsEnemy;
    
   [SerializeField] private Animator _animator;

    private MousePlayer _player;

    private int animValue;
    private void Awake()
    {
        _player = GetComponentInParent<MousePlayer>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            print(other.gameObject.name);
            _player.ChangeState("ATTACK");
        }
    }

}
