using System;
using UnityEditor;

namespace Mew.UnityEditorUtils
{
    public static class ComponentExtensions
    {
        public static void ForEachProgress<T>(this T[] self, string message, Action<T> action, bool startAssetEditing = true)
            where T : UnityEngine.Component
        {
            try
            {
                var totalCount = self.Length;
                var count = 0;

                if (startAssetEditing)
                    AssetDatabase.StartAssetEditing();
                foreach (var cluster in self)
                {
                    var cancel = EditorUtility.DisplayCancelableProgressBar(message,
                        $"{count}/{totalCount}", (float)count / totalCount);
                    count++;

                    if (cancel) break;
                    action(cluster);
                }
            }
            finally
            {
                if (startAssetEditing) AssetDatabase.StopAssetEditing();
                EditorUtility.ClearProgressBar();
            }
        }
    }
}