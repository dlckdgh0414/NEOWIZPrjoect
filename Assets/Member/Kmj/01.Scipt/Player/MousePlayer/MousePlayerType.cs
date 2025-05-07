using Member.Kmj._01.Scipt.Player.MousePlayer;
using UnityEngine;

public class MousePlayerType : AttributeType
{
    private void Update()
    {
        switch (CurrentType)
        {   
            case AttriType.Fire:
                _entityRenderer.material = _typeMaterials[0];
                break;
            case AttriType.Water:
                break;
            case AttriType.Ground:
                break;
            case AttriType.Normal:
                _entityRenderer.material = _typeMaterials[1];
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CurrentType == AttriType.Fire && (1 << other.transform.gameObject.layer & _whatIsEnemy) != 0)
        {
            if(other.TryGetComponent(out IDamgable hit))
                hit.ApplyDamage(10, true,0, null);
            
            print("불데미지");
        }
    }
}
