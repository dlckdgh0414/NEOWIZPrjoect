using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField] private Pillar pillar;
    [SerializeField] private Pillar pillar2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(other.TryGetComponent(out BTBoss boss))
            {
                if (boss.IsStun)
                {
                    boss.OnStun?.Invoke();
                    pillar.OffPillar();
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
