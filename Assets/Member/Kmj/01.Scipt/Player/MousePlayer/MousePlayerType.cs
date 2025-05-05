using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Member.Kmj._01.Scipt.Player.MousePlayer
{
    public enum SoulType
    {
        Fire, Water, Ground,Normal
    }
    public class MousePlayerType : MonoBehaviour
    {
        public SoulType CurrentType;
        [SerializeField] private LayerMask _whatIsEnemy;
        
        [SerializeField] private SkinnedMeshRenderer _entityRenderer;
        
        [SerializeField] private List<Material> _typeMaterials = new List<Material>();   

        private void Update()
        {
            switch (CurrentType)
            {   
                case SoulType.Fire:
                    _entityRenderer.material = _typeMaterials[0];
                    break;
                case SoulType.Water:
                    break;
                case SoulType.Ground:
                    break;
                case SoulType.Normal:
                    _entityRenderer.material = _typeMaterials[1];
                    break;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (CurrentType == SoulType.Fire && (1 << other.transform.gameObject.layer & _whatIsEnemy) != 0)
            {
                if(other.TryGetComponent(out IDamgable hit))
                    hit.ApplyDamage(10, true,0, null);
            
                print("불데미지");
            }
        }
    }
}