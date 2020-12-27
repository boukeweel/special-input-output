using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class TileTool : EditorWindow
{
    [MenuItem("Tools/tile tool")]
    public static void showWindow()
    {
        EditorWindow.GetWindow<TileTool>("tile tool");
    }
    private void OnGUI()
    {
        if (GUILayout.Button("collider and layer"))
        {
            AddLayerMask();
            AddMeshCollider();
            //Make_Prefab();
        }
        if (GUILayout.Button("prefab"))
        {
            Make_Prefab();
        }
    }

    private void AddLayerMask()
    {
        foreach(GameObject obj in Selection.gameObjects)
        {
            obj.layer = LayerMask.NameToLayer("Ground");
        }
    }
    private void AddMeshCollider()
    {
       
        foreach (GameObject obj in Selection.gameObjects)
        {
            obj.AddComponent<MeshCollider>();
        }
    }
    private void Make_Prefab()
    {

        //make a prefab from all slected objects and put it in the prefabes folder
        foreach (GameObject obj in Selection.gameObjects)
        {
            string localpath = "Assets/prefabs" + obj.name + ".prefab";

            localpath = AssetDatabase.GenerateUniqueAssetPath(localpath);

            PrefabUtility.SaveAsPrefabAssetAndConnect(obj, localpath, InteractionMode.UserAction);
        }
    }

}
