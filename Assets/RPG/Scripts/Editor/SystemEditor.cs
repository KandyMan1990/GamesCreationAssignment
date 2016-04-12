using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public partial class DatabaseEditor : EditorWindow
{
    const string DATABASE_SYSTEM_NAME = @"System.asset";
    SystemDB System_DB;
    Texture2D selectedTexture;

    void SystemButton()
    {
        if (currentEditorState != EditorState.SYSTEM)
        {
            if (GUILayout.Button("System"))
            {
                currentEditorState = EditorState.SYSTEM;
                DatabaseEditor window = GetWindow<DatabaseEditor>();
                window.minSize = new Vector2(1126, 560);
                Selection.activeInstanceID = 0;
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

        GUILayout.BeginHorizontal("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
        SystemMainSection();
        SystemMusicSection();
        GUILayout.EndHorizontal();

        GUILayout.EndScrollView();

        EditorUtility.SetDirty(System_DB);
    }

    void SystemMainSection()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Main Section:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Game Title:");
        System_DB.GameTitle = EditorGUILayout.TextField(System_DB.GameTitle, GUILayout.Width(200));

        EditorGUILayout.LabelField("Game Version:");
        System_DB.VersionNumber = EditorGUILayout.FloatField(System_DB.VersionNumber, GUILayout.Width(100));

        EditorGUILayout.LabelField("Game Currency:");
        System_DB.CurrencyUnit = EditorGUILayout.TextField(System_DB.CurrencyUnit, GUILayout.Width(100));

        EditorGUILayout.LabelField("Game Window:");
        if (System_DB.WindowColour)
            selectedTexture = System_DB.WindowColour.texture;
        else
            selectedTexture = null;

        if(GUILayout.Button(selectedTexture, GUILayout.Width(75), GUILayout.Height(75)))
        {
            int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
            EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
        }

        string commandName = Event.current.commandName;
        if(commandName == "ObjectSelectorUpdated")
        {
            System_DB.WindowColour = (Sprite)EditorGUIUtility.GetObjectPickerObject();
            Repaint();
        }

        GUILayout.EndVertical();
    }

    void SystemMusicSection()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Music Section:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Title Music:");
        System_DB.TitleMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.TitleMusic, typeof(IntroloopAudio), true);

        //TODO: fix editor keeping objects selected/blank objects when they arent (try repaint?)
        //TODO: too many box layouts on page
        //keep working

        GUILayout.EndVertical();
    }

    void SystemSfxSection()
    {

    }
}