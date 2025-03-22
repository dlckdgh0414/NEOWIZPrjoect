
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

    public bool CastDamage(float damage, Vector2 knockback)
    {
        Collider[] collider = Physics.OverlapBox(_entity.transform.position,
            _attackRadius,Quaternion.identity,_whatIsEnemy);

        if(collider != null)
        {
          /*7  collider.ToList().ForEach(collider => collider.GetComponent<EntityHealth>()
            .ApplyDamage();*/
        }

        return true;
    }
}
