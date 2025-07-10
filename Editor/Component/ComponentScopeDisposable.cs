using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Mew.UnityEditorUtils
{
    public class ComponentScopeDisposable<T> : IDisposable
        where T: Component
    {
        private readonly T targetComponent;

        public ComponentScopeDisposable(GameObject targetGo, out T outComponent)
        {
            if (!targetGo)
                throw new ArgumentNullException(nameof(targetGo));

            if (targetGo.TryGetComponent<T>(out var component))
                Object.DestroyImmediate(component);

            targetComponent = targetGo.AddComponent<T>();
            outComponent = targetComponent;
        }

        public void Dispose()
        {
            Object.DestroyImmediate(targetComponent);
        }
    }
}