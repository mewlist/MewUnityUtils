using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mew.UnityUtils
{
    public static class GameObjectUtils
    {
        public static GameObject FindOrCreate(string name, Transform parent, Vector3 position, bool includeInactive = false)
        {
            var go = SceneManager.GetActiveScene().GetRootGameObjects()
                .Where(x => includeInactive || x.activeInHierarchy)
                .FirstOrDefault(x => x.name == name);
            if (!go)
            {
                go = new GameObject(name);
            }
            if (parent) go.transform.SetParent(parent);
            go.transform.position = position;

            return go;
        }

    }
}