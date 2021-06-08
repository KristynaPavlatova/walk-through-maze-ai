using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnPrefabGrid))] //linking scripts
public class SpawnPrefabGridEditor : Editor
{
    SerializedProperty cubes;
    SerializedProperty gridX;
    SerializedProperty gridZ;
    SerializedProperty gridOrigin;

    private void OnEnable()
    {
        cubes = serializedObject.FindProperty("cubes");
        gridX = serializedObject.FindProperty("gridX");
        gridZ = serializedObject.FindProperty("gridZ");
        gridOrigin = serializedObject.FindProperty("gridOrigin");

        SpawnPrefabGrid grid = (SpawnPrefabGrid)target;//the target for the editor is the script CustomTerrain, it is terrain var here
        grid.FindBuildingBlocks();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();//always at the start - updates properties that go between this script and the CustomTerrain

        SpawnPrefabGrid grid = (SpawnPrefabGrid)target;//the target for the editor is the script CustomTerrain, it is terrain var here

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        GUILayout.Label("Generate grid based on values", EditorStyles.boldLabel);
        //display values
        EditorGUILayout.PropertyField(gridX);
        EditorGUILayout.PropertyField(gridZ);
        EditorGUILayout.PropertyField(gridOrigin);
        EditorGUILayout.PropertyField(cubes);

        if (GUILayout.Button("SpawnGrid"))
        {
            grid.SpawnGrid();
        }
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);//noninteractive line
    }
}
