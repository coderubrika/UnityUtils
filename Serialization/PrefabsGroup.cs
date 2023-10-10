using System;
using UnityEngine;

namespace Suburb.Utils.Serialization
{
    [Serializable]
    public class PrefabsGroup
    {
        [SerializeField] private string name;
        [SerializeField] private GameObject[] prefabs;

        public string Name => name;

        public GameObject[] Prefabs => prefabs;
    }
}