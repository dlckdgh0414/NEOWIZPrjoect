using UnityEngine;

public class Chain : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(other.TryGetComponent(out Entity boss))
            {
                boss.OnStun?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
