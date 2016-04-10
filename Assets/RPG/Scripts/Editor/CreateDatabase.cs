﻿using UnityEngine;
using UnityEditor;

public class CreateDatabase : EditorWindow
{
    enum EditorState
    {
        HOME,       //default/blank state for editor
        CHARACTERS, //characters in game
        CLASSES,    //classes in game (protagonist/party member/enemy?/boss?/final boss???)
        SKILLS,     //list of attacks, magics
        ITEMS,      //list of items in game
        WEAPONS,    //list of weapons in game
        ARMOURS,    //list of armouts in game
        ACCESSORIES,//list of accessories in game
        ENEMIES,    //list of enemy types in game
        ENEMYGROUPS,//list of enemy groups (contains a list of enemies to fight in a battle)
        STATES,     //list of possible states for players and eneimes, including death, poison, sleep, hp regen, also include buff/debuff such as protect, temporary strength up etc.
        QUESTS,     //list of quests in game including main/side quests, list of triggers/progressions
        SYSTEM,     //contains things such as game title, currency unit, defualt window colour/image, default music assets/sfx assets
        TERMS       //list of references such as what to call level, what to call the attack command, what weapon/armour types exist, what elements exist etc.
    }

    enum DetailsState
    {
        NONE,
        DETAILS
    }

    //TODO: list of databases here (not actual list, just variables)

    const string DATABASE_FOLDER_NAME = @"RPG/Databases";

    EditorState currentEditorState;
    DetailsState currentDetailsState;

    //Buttons scroll view
    Vector2 scrollPos = Vector2.zero;
    int listViewWidth = 150;
    int listViewButtonWidth = 142;
    int listViewButtonHeight = 25;

    int selectedIndex = -1;

    //details scroll view
    Vector2 detailsScrollPos = Vector2.zero;

    [MenuItem("Window/Database Editor")]
    public static void Init()
    {
        CreateDatabase window = GetWindow<CreateDatabase>();
        window.titleContent = new GUIContent("RPG Database");
        window.minSize = new Vector2(950, 250);
        window.Show();
    }

    void OnEnable()
    {
        currentEditorState = EditorState.HOME;
        currentDetailsState = DetailsState.NONE;
    }

    void OnGUI()
    {
        TopBar();

        GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
        EditorGUILayout.LabelField(currentEditorState.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal(GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
        DisplayState();
        DisplayDetails();
        GUILayout.EndHorizontal();

        //AddButton();

        GUILayout.BeginHorizontal();
        //CancelButton();
        //DeleteButton();
        GUILayout.EndHorizontal();
    }

    #region Top Bar Buttons
    void TopBar()
    {
        GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

        HomeButton();
        CharactersButton();
        ClassesButton();
        SkillsButton();
        ItemsButton();
        WeaponsButton();
        ArmoursButton();
        AccessoriesButton();
        EnemiesButton();
        EnemyGroupsButton();
        StatesButton();
        QuestsButton();
        SystemButton();
        TermsButton();

        GUILayout.EndHorizontal();
    }

    void HomeButton()
    {
        if (currentEditorState != EditorState.HOME)
        {
            if (GUILayout.Button("Home"))
                currentEditorState = EditorState.HOME;
        }
    }
    void CharactersButton()
    {
        if (currentEditorState != EditorState.CHARACTERS)
        {
            if (GUILayout.Button("Characters"))
                currentEditorState = EditorState.CHARACTERS;
        }
    }
    void ClassesButton()
    {
        if (currentEditorState != EditorState.CLASSES)
        {
            if (GUILayout.Button("Classes"))
                currentEditorState = EditorState.CLASSES;
        }
    }
    void SkillsButton()
    {
        if (currentEditorState != EditorState.SKILLS)
        {
            if (GUILayout.Button("Skills"))
                currentEditorState = EditorState.SKILLS;
        }
    }
    void ItemsButton()
    {
        if (currentEditorState != EditorState.ITEMS)
        {
            if (GUILayout.Button("Items"))
                currentEditorState = EditorState.ITEMS;
        }
    }
    void WeaponsButton()
    {
        if (currentEditorState != EditorState.WEAPONS)
        {
            if (GUILayout.Button("Weapons"))
                currentEditorState = EditorState.WEAPONS;
        }
    }
    void ArmoursButton()
    {
        if (currentEditorState != EditorState.ARMOURS)
        {
            if (GUILayout.Button("Armours"))
                currentEditorState = EditorState.ARMOURS;
        }
    }
    void AccessoriesButton()
    {
        if (currentEditorState != EditorState.ACCESSORIES)
        {
            if (GUILayout.Button("Accessories"))
                currentEditorState = EditorState.ACCESSORIES;
        }
    }
    void EnemiesButton()
    {
        if (currentEditorState != EditorState.ENEMIES)
        {
            if (GUILayout.Button("Enemies"))
                currentEditorState = EditorState.ENEMIES;
        }
    }
    void EnemyGroupsButton()
    {
        if (currentEditorState != EditorState.ENEMYGROUPS)
        {
            if (GUILayout.Button("Enemy Groups"))
                currentEditorState = EditorState.ENEMYGROUPS;
        }
    }
    void StatesButton()
    {
        if (currentEditorState != EditorState.STATES)
        {
            if (GUILayout.Button("States"))
                currentEditorState = EditorState.STATES;
        }
    }
    void QuestsButton()
    {
        if (currentEditorState != EditorState.QUESTS)
        {
            if (GUILayout.Button("Quests"))
                currentEditorState = EditorState.QUESTS;
        }
    }
    void SystemButton()
    {
        if (currentEditorState != EditorState.SYSTEM)
        {
            if (GUILayout.Button("System"))
                currentEditorState = EditorState.SYSTEM;
        }
    }
    void TermsButton()
    {
        if (currentEditorState != EditorState.TERMS)
        {
            if (GUILayout.Button("Terms"))
                currentEditorState = EditorState.TERMS;
        }
    }
    #endregion

    #region Editor Tabs
    void DisplayState()
    {
        switch (currentEditorState)
        {
            case EditorState.HOME:
                HomeTab();
                break;
            case EditorState.CHARACTERS:
                CharactersTab();
                break;
            case EditorState.CLASSES:
                ClassesTab();
                break;
            case EditorState.SKILLS:
                SkillsTab();
                break;
            case EditorState.ITEMS:
                ItemsTab();
                break;
            case EditorState.WEAPONS:
                WeaponsTab();
                break;
            case EditorState.ARMOURS:
                ArmoursTab();
                break;
            case EditorState.ACCESSORIES:
                AccessoriesTab();
                break;
            case EditorState.ENEMIES:
                EnemiesTab();
                break;
            case EditorState.ENEMYGROUPS:
                EnemyGroupsTab();
                break;
            case EditorState.STATES:
                StatesTab();
                break;
            case EditorState.QUESTS:
                QuestsTab();
                break;
            case EditorState.SYSTEM:
                SystemTab();
                break;
            case EditorState.TERMS:
                TermsTab();
                break;
        }
    }

    void HomeTab()
    {

    }
    void CharactersTab()
    {

    }
    void ClassesTab()
    {

    }
    void SkillsTab()
    {

    }
    void ItemsTab()
    {

    }
    void WeaponsTab()
    {

    }
    void ArmoursTab()
    {

    }
    void AccessoriesTab()
    {

    }
    void EnemiesTab()
    {

    }
    void EnemyGroupsTab()
    {

    }
    void StatesTab()
    {

    }
    void QuestsTab()
    {

    }
    void SystemTab()
    {

    }
    void TermsTab()
    {

    }
    #endregion

    void DisplayDetails()
    {
        //TODO: continue from here
    }
}