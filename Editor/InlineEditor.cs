using UnityEditor;
using UnityEngine;

namespace Mew.UnityEditorUtils
{
    public class InlineEditor<T>
        where T: Component
    {
        private Editor editor;

        public bool FoldOut { get; set; } = false;
        public T Component { get; private set; }

        public void OnInspectorGUI()
        {
            var labelName = $"{typeof(T).Name} Inspector";
            FoldOut = EditorGUILayout.Foldout(FoldOut, labelName);

            if (!Component)
            {
                Component = Object.FindAnyObjectByType<T>();
                editor = null;
            }

            if (!FoldOut) return;

            if (Component)
            {
                editor ??= Editor.CreateEditor(Component);
                editor.OnInspectorGUI();
            }
            else
            {
                GUILayout.Label("Component not found in the scene.");
            }

            GUILayout.Space(12f);
        }
    }
}