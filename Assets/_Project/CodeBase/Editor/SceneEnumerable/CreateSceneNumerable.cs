using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateSceneNumerable : EditorWindow
{
    [MenuItem("Tools/Generate Scene Enum")]
    public static void ShowWindow()
    {
        GetWindow(typeof(CreateSceneNumerable));
    }

    private void OnGUI()
    {
        GUILayout.Label("Scene Enum Generator", EditorStyles.boldLabel);

        if (GUILayout.Button("Generate Enum"))
        {
            GenerateSceneEnum();
        }
    }

    private void GenerateSceneEnum()
    {
        string outputPath = Application.dataPath + "/_Project/CodeBase/Core/Scenes";
        string outputFileName = "SceneEnum.cs";
        string outputFilePath = Path.Combine(outputPath, outputFileName);
         
        string scenesDirectory = Application.dataPath + "/_Project/Scenes";
        string[] scenePaths = Directory.GetFiles(scenesDirectory, "*.unity");

        // Extract scene names from paths
        List<string> sceneNames = new List<string>();
        foreach (string scenePath in scenePaths)
        {
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);
            sceneNames.Add(sceneName);
        }

        // Create enum content
        string enumContent = "public enum SceneEnum\n{\n";
        foreach (string sceneName in sceneNames)
        {
            enumContent += $"    {sceneName},\n";
        }
        enumContent += "}\n";

        // Write to file
        File.WriteAllText(outputFilePath, enumContent);

        // Refresh the asset database to make sure the new file is recognized by Unity
        AssetDatabase.Refresh();

        Debug.Log($"Scene enum generated at: {outputFilePath}");
    }
}
