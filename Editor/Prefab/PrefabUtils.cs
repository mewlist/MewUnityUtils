using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace Mew.UnityEditorUtils
{
    public static class PrefabUtils
    {
        /// <summary>
        /// go が インスタンスとして配置された Prefab の一部であるかどうかを判定
        /// </summary>
        public static bool IsUnderPrefab(GameObject go)
        {
            var prefabInstanceRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(go);
            return prefabInstanceRoot && go != prefabInstanceRoot;
        }

        /// <summary>
        /// go がネストされた Prefab インスタンスであるかどうかを判定
        /// </summary>
        public static bool IsNestedPrefabInstance(GameObject go)
        {
            var nearest = PrefabUtility.GetNearestPrefabInstanceRoot(go);
            var outerMost = PrefabUtility.GetOutermostPrefabInstanceRoot(go);
            return nearest != outerMost;
        }

        /// <summary>
        /// go が Prefab インスタンスの root であればそのソースオブジェクトを取得
        /// </summary>
        public static GameObject GetSourcePrefab(GameObject go)
        {
            var nearest = PrefabUtility.GetNearestPrefabInstanceRoot(go);
            return nearest == go
                ? PrefabUtility.GetCorrespondingObjectFromOriginalSource(nearest)
                : null;
        }

        /// <summary>
        /// go が Prefab インスタンスの root であるかどうかを判定
        /// </summary>
        public static bool IsPrefabInstanceRoot(GameObject go)
        {
            var nearest = PrefabUtility.GetNearestPrefabInstanceRoot(go);
            return nearest && nearest == go;
        }

        public static EditPrefabScope StartEditPrefab(string prefabPath)
        {
            Assert.IsTrue(prefabPath.EndsWith(".prefab"), "Prefab path must end with .prefab");
            return new EditPrefabScope(prefabPath);
        }
    }
}