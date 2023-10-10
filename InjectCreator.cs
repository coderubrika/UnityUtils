using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Suburb.Utils
{
    public class InjectCreator
    {
        private readonly DiContainer diContainer;

        public InjectCreator(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public GameObject Create(Object prefab, Transform parent)
        {
            return diContainer.InstantiatePrefab(prefab, parent);
        }

        public T Create<T>(Object prefab, Transform parent)
        {
            return diContainer.InstantiatePrefabForComponent<T>(prefab, parent);
        }

        public T Create<T>(Object prefab, Transform parent, IEnumerable<object> args)
        {
            return diContainer.InstantiatePrefabForComponent<T>(prefab, parent, args);
        }

        public T Create<T> (object[] args = null)
        {
            if (args != null)
                return diContainer.Instantiate<T>(args);
            return diContainer.Instantiate<T>();
        }
    }
}
