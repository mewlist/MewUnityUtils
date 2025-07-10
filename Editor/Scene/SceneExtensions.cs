using System.IO;
using Scene = UnityEngine.SceneManagement.Scene;

namespace Mew.UnityEditorUtils
{
    public static class SceneExtensions
    {
        public static string AssetPath(this Scene scene)
        {
            return Path.GetDirectoryName(scene.path);
        }

        public static string AssetPath(this Scene scene, string subPath)
        {
            if (string.IsNullOrEmpty(subPath))
                return Path.GetDirectoryName(scene.path);

            if (subPath.StartsWith("/"))
                subPath = subPath.Substring(1);

            if (subPath.EndsWith("/"))
                subPath = subPath.Substring(0, subPath.Length - 1);

            return Path.Combine(Path.GetDirectoryName(scene.path), subPath);
        }
    }
}