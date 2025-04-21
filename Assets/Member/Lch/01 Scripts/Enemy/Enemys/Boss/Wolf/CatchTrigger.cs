using UnityEngine;

public class CatchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            CatcingPlayer(player);
        }
    }

    private void CatcingPlayer(Player player)
    {

    }
}
