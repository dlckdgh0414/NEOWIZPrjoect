using UnityEngine;

public interface IDamgable
{
    public void ApplyDamage(float damage, Vector2 distatnce, Vector2 knockbackPower, Entity dealer);
}
