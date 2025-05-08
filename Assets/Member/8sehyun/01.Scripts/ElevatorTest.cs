using UnityEngine;
using DG.Tweening;

public class ElevatorTest : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform goal;
    bool activated = false;


    private void OnTriggerEnter(Collider other)
    {
        if (activated == false && other.CompareTag("Player"))
        {
            activated = true;
            target.DOMoveY(target.position.y, 5);
        }
    }
}
