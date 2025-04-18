using UnityEngine;

public interface IDamgable
{
    public void ApplyDamage(float damage, bool isHit,int stunLevel ,Entity delear);
}
