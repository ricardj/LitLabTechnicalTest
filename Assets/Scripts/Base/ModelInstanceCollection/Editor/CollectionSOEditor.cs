using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CollectionSO<>))]
public class CollectionSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Development options");
        if (GUILayout.Button("Add Item instance"))
        {

        }
    }
}
