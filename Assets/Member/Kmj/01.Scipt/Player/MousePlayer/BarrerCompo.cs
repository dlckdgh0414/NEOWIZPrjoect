using System.Reflection;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BarrerCompo : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsBlockObj;

    [SerializeField] private MousePlayer _player;

    public bool isPalling => _player._barrerSkill.isPalling;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.transform.gameObject.layer) & _whatIsBlockObj) != 0 && isPalling)
        {
            other.TryGetComponent(out SoulBullet bullet);

            bullet._isReflect = true;
            Vector3 reflectDir = (bullet._entity.transform.position - bullet.transform.position).normalized;
            bullet._rbCompo.linearVelocity = reflectDir * bullet._rbCompo.linearVelocity.magnitude; 
        }
        else if ((1 << other.transform.gameObject.layer & _whatIsBlockObj) != 0)
        {
            other.gameObject.SetActive(false);
        }
    }
}
