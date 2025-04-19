using UnityEngine;

public class Wolf : BTBoss
{
    [HideInInspector] public bool IsAttack = false;
    [HideInInspector] public float RushDamge = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(IsAttack)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (collision.gameObject.TryGetComponent(out IDamgable damgable))
                {
                    damgable.ApplyDamage(RushDamge, false, 0, this);
                }
            }
        }
    }
}
