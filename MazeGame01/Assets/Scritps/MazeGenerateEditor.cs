using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(MazeGenerator))]
public class MazeGenerateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MazeGenerator mazeGenerator = (MazeGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
            mazeGenerator.GenerateMazeBasic();
        else if (GUILayout.Button("Run Alghoritm"))
            mazeGenerator.GenerateRandomPaths();
        else if (GUILayout.Button("Clear"))
            mazeGenerator.DestroyMaze();
    }
}
