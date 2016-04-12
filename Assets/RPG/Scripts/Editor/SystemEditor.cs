using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public partial class DatabaseEditor : EditorWindow
{
    const string DATABASE_SYSTEM_NAME = @"System.asset";
    SystemDB System_DB;

    void SystemButton()
    {
        if (currentEditorState != EditorState.SYSTEM)
        {
            if (GUILayout.Button("System"))
            {
                currentEditorState = EditorState.SYSTEM;
                DatabaseEditor window = GetWindow<DatabaseEditor>();
                window.minSize = new Vector2(1126, 560);
            }
        }
    }

    void SystemTab()
    {
        if (System_DB == null)
        {
            System_DB = ScriptableObjectDatabase<SystemDB>.GetDatabase<SystemDB>(DATABASE_FOLDER_NAME, DATABASE_SYSTEM_NAME);
        }

        scrollPos = GUILayout.BeginScrollView(scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        GUILayout.EndScrollView();

        EditorUtility.SetDirty(System_DB);

    }
}