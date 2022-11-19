using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InventoryController))]
public class InventoryControllerEditor : Editor
{
    float xDisplacement = 1;

    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        EditorGUILayout.LabelField("Developer options");
        if (GUILayout.Button("Fetch inventory slots"))
        {
            InventoryController inventoryController = (InventoryController)target;
            inventoryController.inventorySlots = inventoryController.gameObject.GetComponentsInChildren<InventorySlot>().ToList();

        }

        xDisplacement = EditorGUILayout.FloatField("X Displacement", xDisplacement);
        if (GUILayout.Button("Algin Inventory Slots"))
        {
            InventoryController inventoryController = ((InventoryController)target);
            List<InventorySlot> inventorySlots = inventoryController.inventorySlots;
            for (int i = 0; i < inventorySlots.Count; i++)
            {
                InventorySlot currentSlot = inventorySlots[i];
                currentSlot.inventorySlotId = i;
                currentSlot.transform.position = inventoryController.transform.position;
                currentSlot.transform.localPosition += Vector3.left * i * xDisplacement;
            }
        }


    }
}