using UnityEditor;
using UnityEngine;


public class CollectionSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Development options");
        ICountable collectionSO = (ICountable)target;
        GUILayout.Label("Current Items: " + collectionSO.GetCount());
        //if (GUILayout.Button("Add Item instance"))
        //{
        //}
    }
}
