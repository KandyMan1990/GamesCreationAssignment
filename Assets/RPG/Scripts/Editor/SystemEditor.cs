using UnityEngine;
using UnityEditor;

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
                if (!window.maximized)
                {
                    window.maxSize = new Vector2(900, 380);
                    window.minSize = window.maxSize;
                }
                GUIUtility.keyboardControl = 0;
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

        GUILayout.BeginHorizontal(GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
        SystemMainSection();
        SystemMusicSection();
        SystemSfxSection();
        GUILayout.EndHorizontal();

        GUILayout.EndScrollView();
    }

    void SystemMainSection()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Main Section:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Game Title:");
        System_DB.GameTitle = EditorGUILayout.TextField(System_DB.GameTitle, GUILayout.Width(200));

        EditorGUILayout.LabelField("Game Version:");
        System_DB.VersionNumber = EditorGUILayout.TextField(System_DB.VersionNumber, GUILayout.Width(100));

        EditorGUILayout.LabelField("Game Currency:");
        System_DB.CurrencyUnit = EditorGUILayout.TextField(System_DB.CurrencyUnit, GUILayout.Width(100));

        EditorGUILayout.LabelField("Game Window:");
        if (System_DB.WindowColour)
            selectedTexture = System_DB.WindowColour.texture;
        else
            selectedTexture = null;

        if (GUILayout.Button(selectedTexture, GUILayout.Width(75), GUILayout.Height(75)))
        {
            int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
            EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
        }

        string commandName = Event.current.commandName;
        if (commandName == "ObjectSelectorUpdated")
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

        EditorGUILayout.LabelField("Battle Music:");
        System_DB.BattleMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.BattleMusic, typeof(IntroloopAudio), true);

        EditorGUILayout.LabelField("Boss Music:");
        System_DB.BossMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.BossMusic, typeof(IntroloopAudio), true);

        EditorGUILayout.LabelField("Victory Music:");
        System_DB.VictoryMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.VictoryMusic, typeof(IntroloopAudio), true);

        EditorGUILayout.LabelField("Game Over Music:");
        System_DB.GameOverMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.GameOverMusic, typeof(IntroloopAudio), true);

        GUILayout.EndVertical();
    }

    void SystemSfxSection()
    {
        GUILayout.BeginHorizontal("Box");
        GUILayout.BeginVertical();

        EditorGUILayout.LabelField("Sound Effects Section:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        SystemSFXMain();
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        EditorGUILayout.LabelField("", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        SystemSFXBattle();
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    void SystemSFXMain()
    {
        EditorGUILayout.LabelField("Cursor Sound:");
        System_DB.CursorSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.CursorSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("OK Sound:");
        System_DB.OkSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.OkSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Cancel Sound:");
        System_DB.CancelSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.CancelSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Error Sound:");
        System_DB.ErrorSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.ErrorSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Equip Sound:");
        System_DB.EquipSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.EquipSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Save Sound:");
        System_DB.SaveSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.SaveSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Load Sound:");
        System_DB.LoadSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.LoadSFX, typeof(AudioClip), true);
    }

    void SystemSFXBattle()
    {
        EditorGUILayout.LabelField("Battle Start Sound:");
        System_DB.BattleStartSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.BattleStartSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Boss Start Sound:");
        System_DB.BossStartSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.BossStartSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Escape Sound:");
        System_DB.EscapeSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.EscapeSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Physical Miss Sound:");
        System_DB.PhysicalMissSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.PhysicalMissSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Magical Miss Sound:");
        System_DB.MagicMissSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.MagicMissSFX, typeof(AudioClip), true);
    }

    //set dirty will be removed in future versions, look for alternatives
}