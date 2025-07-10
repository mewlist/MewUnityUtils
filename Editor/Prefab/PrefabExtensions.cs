using System.Linq;
using Mew.UnityUtils;
using UnityEngine;

namespace Mew.UnityEditorUtils
{
    public static class PrefabExtensions
    {
        /// <summary>
        /// go の子に含まれる Prefab インスタンスを全て取得
        /// </summary>
        public static GameObject[] GetAllPrefabInstanceRootInChildren(this GameObject go)
        {
            return go
                .GetChildren(onlyActive: false, recursive: true)
                .Where(PrefabUtils.IsPrefabInstanceRoot)
                .ToArray();
        }
    }
}