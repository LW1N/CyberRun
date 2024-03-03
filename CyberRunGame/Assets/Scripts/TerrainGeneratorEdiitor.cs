using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainGenerator))]
public class TerrainGeneratorEdiitor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TerrainGenerator myScript = (TerrainGenerator)target;
        if (GUILayout.Button("Generate"))
        {
            myScript.Generate();
        }
    }
}
