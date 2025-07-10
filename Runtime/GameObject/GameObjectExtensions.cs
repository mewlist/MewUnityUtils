using System.Collections.Generic;
using UnityEngine;

namespace Mew.UnityUtils
{
    public static class GameObjectExtensions
    {
        public static IEnumerable<GameObject> GetChildren(
            this GameObject gameObject,
            bool onlyActive = false,
            bool recursive = false)
        {
            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                var t = gameObject.transform.GetChild(i);
                if (recursive)
                {
                    foreach (var child in t.gameObject.GetChildren(onlyActive, recursive:true))
                    {
                        if (onlyActive && !child.activeSelf)
                            continue;
                        yield return child;
                    }
                }

                if (onlyActive && !t.gameObject.activeSelf)
                    continue;
                yield return t.gameObject;
            }
        }

        public static Bounds GetBoundsIncludeChildren(this GameObject g)
        {
            var b = new Bounds(g.transform.position, Vector3.zero);
            foreach (Renderer r in g.GetComponentsInChildren<Renderer>()) {
                b.Encapsulate(r.bounds);
            }
            return b;
        }

        public static GameObject FindOrCreate(this GameObject root, string name, Vector3 position, bool includeInactive = false)
        {
            var go = root.GetChildByName(name);
            if (!go)
            {
                go = new GameObject(name);
            }
            go.transform.SetParent(root.transform);
            go.transform.position = position;

            return go;
        }

        public static GameObject GetChildByName(this GameObject gameObject, string name)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.name == name)
                    return child.gameObject;
            }

            return null;
        }

        public static GameObject CreateChild(this GameObject gameObject, string name)
        {
            var child = new GameObject(name);
            child.transform.SetParent(gameObject.transform);
            return child;
        }

        public static void DestroyChildren(this GameObject gameObject)
        {
            while (gameObject.transform.childCount > 0)
            {
                var child = gameObject.transform.GetChild(0);
                child.parent = null;
                Object.DestroyImmediate(child.gameObject);
            }
        }
    }
}