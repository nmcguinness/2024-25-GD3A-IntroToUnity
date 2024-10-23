namespace GD.Items.Editor
{
    /*
    [CustomEditor(typeof(InventoryCollection))]
    public class InventoryCollectionEditor : UnityEditor.Editor
    {
        // Store foldout states for each category
        private Dictionary<ItemCategoryType, bool> foldoutStates = new Dictionary<ItemCategoryType, bool>();

        public override void OnInspectorGUI()
        {
            // Get reference to InventoryCollection
            InventoryCollection inventoryCollection = (InventoryCollection)target;

            // Draw the default script field
            DrawDefaultInspector();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Inventory Summary", EditorStyles.boldLabel);

            // Display a summary of each inventory category and its count with foldout
            foreach (var inventoryEntry in inventoryCollection.Contents)
            {
                Inventory inventory = inventoryEntry.Value;
                if (inventory != null)
                {
                    // Ensure foldout state is tracked for each category
                    if (!foldoutStates.ContainsKey(inventoryEntry.Key))
                    {
                        foldoutStates[inventoryEntry.Key] = true;
                    }

                    foldoutStates[inventoryEntry.Key] = EditorGUILayout.Foldout(foldoutStates[inventoryEntry.Key], $"Category: {inventoryEntry.Key}");

                    if (foldoutStates[inventoryEntry.Key])
                    {
                        EditorGUILayout.BeginVertical("box");

                        // Add a field to show and allow opening of the ScriptableObject inventory
                        EditorGUILayout.ObjectField("Inventory ScriptableObject", inventory, typeof(Inventory), false);

                        int itemCount = inventory != null ? inventory.Contents.Count : 0;
                        EditorGUILayout.LabelField($"{inventoryEntry.Key}: {itemCount}");

                        foreach (var item in inventory.Contents)
                        {
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField($"Item: {item.Key.Name}", GUILayout.Width(200));
                            EditorGUILayout.LabelField($"Count: {item.Value}", GUILayout.Width(80));
                            EditorGUILayout.EndHorizontal();
                        }

                        // Add a button to remove this inventory from the collection
                        if (GUILayout.Button("Remove Inventory"))
                        {
                            if (EditorUtility.DisplayDialog("Remove Inventory", $"Are you sure you want to remove the inventory for category {inventoryEntry.Key}?", "Yes", "No"))
                            {
                                inventoryCollection.Contents.Remove(inventoryEntry.Key);
                                break; // Exit the loop to avoid modifying the collection while iterating
                            }
                        }

                        EditorGUILayout.EndVertical();
                    }
                }
                else
                {
                    EditorGUILayout.LabelField($"Category: {inventoryEntry.Key} - No inventory found.");
                }
            }

            EditorGUILayout.Space();

            // Optionally add buttons for functionality
            if (GUILayout.Button("Clear Inventory"))
            {
                if (EditorUtility.DisplayDialog("Clear Inventory", "Are you sure you want to clear the inventory? This action cannot be undone.", "Yes", "No"))
                {
                    inventoryCollection.ClearAllInventories();
                }
            }

            // Apply changes when the GUI is modified
            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }
    }
    */
}