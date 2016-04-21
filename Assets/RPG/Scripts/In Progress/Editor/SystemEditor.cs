using UnityEngine;
using UnityEditor;

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
                if (!window.maximized)
                {
                    window.maxSize = new Vector2(900, 400);
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

        GUILayout.BeginHorizontal(GUILayout.ExpandHeight(true), GUILayout.Width(120));
        SystemInitialParty();
        GUILayout.EndHorizontal();

        GUILayout.EndScrollView();
    }

    void SystemMainSection()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Main Section:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Game Title:");
        System_DB.SetGameTitle = EditorGUILayout.TextField(System_DB.GameTitle, GUILayout.Width(200));

        EditorGUILayout.LabelField("Game Version:");
        System_DB.SetVersionNumber = EditorGUILayout.TextField(System_DB.VersionNumber, GUILayout.Width(100));

        EditorGUILayout.LabelField("Game Currency:");
        System_DB.SetCurrencyUnit = EditorGUILayout.TextField(System_DB.CurrencyUnit, GUILayout.Width(100));

        EditorGUILayout.LabelField("EXP to Next Level:");
        System_DB.SetExpToLevelUp = EditorGUILayout.IntField(System_DB.ExpToLevelUp, GUILayout.Width(100));

        EditorGUILayout.LabelField("Game Window:");
        System_DB.SetWindowColour = EditorGUILayout.ObjectField(System_DB.WindowColour, typeof(Sprite), true) as Sprite;
        if (System_DB.WindowColour != null)
        {
            GUILayout.Box(System_DB.WindowColour.texture, GUILayout.Width(193), GUILayout.Height(50));
        }
        else
        {
            GUILayout.Box("NONE", GUILayout.Width(100), GUILayout.Height(100));
        }

        GUILayout.EndVertical();
    }

    void SystemMusicSection()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Music Section:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Title Music:");
        System_DB.SetTitleMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.TitleMusic, typeof(IntroloopAudio), true);

        EditorGUILayout.LabelField("Battle Music:");
        System_DB.SetBattleMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.BattleMusic, typeof(IntroloopAudio), true);

        EditorGUILayout.LabelField("Boss Music:");
        System_DB.SetBossMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.BossMusic, typeof(IntroloopAudio), true);

        EditorGUILayout.LabelField("Victory Music:");
        System_DB.SetVictoryMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.VictoryMusic, typeof(IntroloopAudio), true);

        EditorGUILayout.LabelField("Game Over Music:");
        System_DB.SetGameOverMusic = (IntroloopAudio)EditorGUILayout.ObjectField(System_DB.GameOverMusic, typeof(IntroloopAudio), true);

        GUILayout.EndVertical();
    }

    void SystemSfxSection()
    {
        GUILayout.BeginHorizontal("Box");
        GUILayout.BeginVertical();

        EditorGUILayout.LabelField("Sound Effects Section:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        SystemSFXSection1();
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        EditorGUILayout.LabelField("", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        SystemSFXSection2();
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    void SystemSFXSection1()
    {
        EditorGUILayout.LabelField("Cursor Sound:");
        System_DB.SetCursorSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.CursorSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("OK Sound:");
        System_DB.SetOkSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.OkSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Cancel Sound:");
        System_DB.SetCancelSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.CancelSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Error Sound:");
        System_DB.SetErrorSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.ErrorSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Equip Sound:");
        System_DB.SetEquipSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.EquipSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Save Sound:");
        System_DB.SetSaveSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.SaveSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Load Sound:");
        System_DB.SetLoadSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.LoadSFX, typeof(AudioClip), true);
    }

    void SystemSFXSection2()
    {
        EditorGUILayout.LabelField("New Game Sound:");
        System_DB.SetNewGameSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.NewGameSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Character Select Sound:");
        System_DB.SetCharacterTurnSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.CharacterTurnSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Battle Start Sound:");
        System_DB.SetBattleStartSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.BattleStartSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Boss Start Sound:");
        System_DB.SetBossStartSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.BossStartSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Escape Sound:");
        System_DB.SetEscapeSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.EscapeSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Physical Miss Sound:");
        System_DB.SetPhysicalMissSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.PhysicalMissSFX, typeof(AudioClip), true);

        EditorGUILayout.LabelField("Magical Miss Sound:");
        System_DB.SetMagicMissSFX = (AudioClip)EditorGUILayout.ObjectField(System_DB.MagicMissSFX, typeof(AudioClip), true);
    }

    void SystemInitialParty()
    {
        GUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("Current party goes here");
        GUILayout.EndVertical();
    }

    //set dirty will be removed in future versions, look for alternatives
}