using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

[CustomEditor(typeof(PlayerData))]
public class PlayerDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerData PlayerData = (PlayerData)target;
        base.OnInspectorGUI();
        if (PlayerData.PlayerBehavior == PlayerData.Behavior.Random)
        {
            if (GUILayout.Button("Appuie"))
            {
                Debug.Log("J'appuie");
            }
        }
    }
}
