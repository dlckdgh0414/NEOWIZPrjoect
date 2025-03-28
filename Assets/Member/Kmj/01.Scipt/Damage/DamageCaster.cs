using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    private Entity _owner;
    [SerializeField] private LayerMask _whatIsEnemy;
    public void InitCaster(Entity owner)
    {
        _owner = owner;
    }

    public bool CastDamage(float damage, Vector2 knockback)
    {
        Debug.Log("�ϴ� �� �ƴ�");
        RaycastHit hit;
        Debug.Log("�ʵ� �ƴ�");
        bool isHit = Physics.SphereCast(transform.position,transform.lossyScale.x * 0.5f, transform.forward,
            out hit,3, _whatIsEnemy);

        Debug.Log("�ʱ���?");
        Debug.Log(isHit);

        
        if(isHit && hit.transform != null)
        {
            Debug.Log("�� �ƴ�");
            Debug.Log(hit.transform.name);
            if(hit.transform.TryGetComponent(out EntityHealth health))
            {
                health.ApplyDamage(damage, knockback);
            }
 
        }
          Debug.Log("�ʱ���");

        return isHit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.lossyScale.x * 0.5f);
        Gizmos.color = Color.white;
    }
}
