using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Member.Kmj._01.Scipt.Player.MousePlayer
{
    public enum AttriType
    {
        Fire, Water, Ground,Normal
    }
    public abstract class AttributeType : MonoBehaviour
    {
        public AttriType CurrentType = AttriType.Normal;
        [SerializeField] protected LayerMask _whatIsEnemy;
        
        [SerializeField] protected SkinnedMeshRenderer _entityRenderer;
        
        [SerializeField] protected List<Material> _typeMaterials = new List<Material>();   
    }
}