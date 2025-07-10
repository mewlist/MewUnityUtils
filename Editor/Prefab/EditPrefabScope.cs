using System;
using UnityEditor;
using UnityEngine;

namespace Mew.UnityEditorUtils
{
    public class EditPrefabScope : IDisposable
    {
        private readonly string prefabPath;
        public GameObject PrefabContents { get; private set; }

        public EditPrefabScope(string prefabPath)
        {
            this.prefabPath = prefabPath;
            PrefabContents = PrefabUtility.LoadPrefabContents(prefabPath);
        }

        public void Dispose()
        {
            if (!PrefabContents) return;

            PrefabUtility.SaveAsPrefabAsset(PrefabContents, prefabPath);
            PrefabUtility.UnloadPrefabContents(PrefabContents);
            PrefabContents = null;
        }
    }
}