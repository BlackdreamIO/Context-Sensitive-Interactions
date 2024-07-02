using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using ContextSensitiveSystem.CSI;

[CustomEditor(typeof(CSI))]
public class CSIEditor : Editor
{
    private ReorderableList reorderableList;

    private void OnEnable()
    {
        reorderableList = new ReorderableList(serializedObject,
                serializedObject.FindProperty("events"),
                true, true, true, true);

        reorderableList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Context Situations");
        };

        reorderableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            float singleLineHeight = EditorGUIUtility.singleLineHeight;
            float fieldHeight = EditorGUI.GetPropertyHeight(element.FindPropertyRelative("unityEvent"), true);
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, rect.width, singleLineHeight),
                element.FindPropertyRelative("eventName"),
                GUIContent.none
            );
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y + singleLineHeight + 2, rect.width, fieldHeight),
                element.FindPropertyRelative("unityEvent"),
                GUIContent.none
            );
        };

        reorderableList.elementHeightCallback = (index) =>
        {
            var element = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            float singleLineHeight = EditorGUIUtility.singleLineHeight;
            float fieldHeight = EditorGUI.GetPropertyHeight(element.FindPropertyRelative("unityEvent"), true);
            return singleLineHeight + fieldHeight + 6;
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        reorderableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}