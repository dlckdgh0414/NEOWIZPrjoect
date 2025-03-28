
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    [SerializeField] private Vector3 _attackRadius;
    [SerializeField] private LayerMask _whatIsEnemy;
    private Entity _entity;
    public void InitCaster(Entity owener)
    {
        _entity = owener;
    }
}
