using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ColorsMultiplicities")]
    public class Colors : ScriptableObject
    {
        public ColorMultiplicity[] Multiplicities;
        public Color Default;
    }

    [Serializable]
    public class ColorMultiplicity
    {
        public int[] Multiplicities;
        public Color Colour;
    }
}