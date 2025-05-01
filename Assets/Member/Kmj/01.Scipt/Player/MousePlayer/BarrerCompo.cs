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
            other.TryGetComponent(out Rigidbody rb);
            rb.linearVelocity = Vector3.Reflect(rb.linearVelocity, transform.forward);
            other.GetComponent<SoulBullet>()._isReflect = true;
        }
        else if ((1 << other.transform.gameObject.layer & _whatIsBlockObj) != 0)
        {
            other.gameObject.SetActive(false);
        }
    }
}
