using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

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

    Terms TermsDB;

    const string DATABASE_FOLDER_NAME = @"RPG/Databases";
    const string DATABASE_TERMS_NAME = @"Terms.asset";
    const string DATABASE_MAIN_NAME = @"RPG Database.asset";

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

        //EditorGUILayout.LabelField(window.position.width.ToString() + " / " + window.position.height.ToString());
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
            {
                currentEditorState = EditorState.TERMS;
                CreateDatabase window = GetWindow<CreateDatabase>();
                window.minSize = new Vector2(1126, 560);
            }
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
        /*
                if (charDatabase == null)
        {
            charDatabase = ScriptableObjectUtility.GetDatabase<CharacterDatabase>(DATABASE_FOLDER_NAME, "Characters Database.asset");
        }
        scrollPos = GUILayout.BeginScrollView(scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(listViewWidth));

        for (int i = 0; i < charDatabase.Count; i++)
        {
            if (GUILayout.Button(charDatabase.Get(i).Name, GUILayout.Width(listViewButtonWidth), GUILayout.Height(listViewButtonHeight)))
            {
                selectedIndex = i;
                tempCharacter = new BaseCharacter();
                tempCharacter.Clone(charDatabase.Get(i));
                currentDetailsState = DetailsState.DETAILS;
                GUI.FocusControl("SaveButton");
            }
        }

        GUILayout.EndScrollView();
        */
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
        if (TermsDB == null)
        {
            TermsDB = ScriptableObjectDatabase<Terms>.GetDatabase<Terms>(DATABASE_FOLDER_NAME, DATABASE_TERMS_NAME);
        }

        scrollPos = GUILayout.BeginScrollView(scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));


        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        TermsTitleScreen();
        TermsMenuScreen();
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        TermsCommands();
        TermsEquipmentTypes();
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        TermsParameters();
        TermsBasicStatus();
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        TermsListType("Elements", TermsDB.ElementTypes, "Element");
        TermsListType("Weapon Types", TermsDB.WeaponTypes, "Weapon");
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        TermsListType("Skill Types", TermsDB.SkillTypes, "Skill");
        TermsListType("Armour Types", TermsDB.ArmourTypes, "Armour");
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();


        GUILayout.EndScrollView();

        EditorUtility.SetDirty(TermsDB);
    }
    #endregion

    void DisplayDetails()
    {
        if (currentDetailsState == DetailsState.DETAILS)
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            ObjectDetails();
            GUILayout.EndHorizontal();
        }
    }

    void ObjectDetails()
    {
        switch (currentEditorState)
        {
            case EditorState.HOME:
                break;
            case EditorState.CHARACTERS:
                CharacterDetails();
                break;
            case EditorState.CLASSES:
                break;
            case EditorState.SKILLS:
                break;
            case EditorState.ITEMS:
                break;
            case EditorState.WEAPONS:
                break;
            case EditorState.ARMOURS:
                break;
            case EditorState.ACCESSORIES:
                break;
            case EditorState.ENEMIES:
                break;
            case EditorState.ENEMYGROUPS:
                break;
            case EditorState.STATES:
                break;
            case EditorState.QUESTS:
                break;
            case EditorState.SYSTEM:
                break;
            case EditorState.TERMS:
                break;
        }
    }

    void CharacterDetails()
    {
        /*
                EditorGUILayout.BeginScrollView(detailsScrollPos);

        tempCharacter.Name = EditorGUILayout.TextField("Name: ", tempCharacter.Name);
        tempCharacter.StartingLevel = EditorGUILayout.IntSlider("Starting Level: ", tempCharacter.StartingLevel, 1, 100);
        tempCharacter.HealthCurve = EditorGUILayout.CurveField("Health Curve: ", tempCharacter.HealthCurve);
        tempCharacter.PhysicalAttackCurve = EditorGUILayout.CurveField("Physical Attack Curve: ", tempCharacter.PhysicalAttackCurve);
        tempCharacter.PhysicalDefenceCurve = EditorGUILayout.CurveField("Physical Defece Curve: ", tempCharacter.PhysicalDefenceCurve);
        tempCharacter.MagicalAttackCurve = EditorGUILayout.CurveField("Magical Attack Curve: ", tempCharacter.MagicalAttackCurve);
        tempCharacter.MagicalDefenceCurve = EditorGUILayout.CurveField("Magical Defence Curve: ", tempCharacter.MagicalDefenceCurve);
        tempCharacter.EvasionCurve = EditorGUILayout.CurveField("Evasion Curve: ", tempCharacter.EvasionCurve);

        EditorGUILayout.EndScrollView();
    */
    }

    void TermsTitleScreen()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Title Screen:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("New Game:");
        TermsDB.NewGame = EditorGUILayout.TextField(TermsDB.NewGame, GUILayout.Width(100));

        EditorGUILayout.LabelField("Load Game:");
        TermsDB.LoadGame = EditorGUILayout.TextField(TermsDB.LoadGame, GUILayout.Width(100));

        EditorGUILayout.LabelField("Quit Game:");
        TermsDB.Quit = EditorGUILayout.TextField(TermsDB.Quit, GUILayout.Width(100));

        EditorGUILayout.LabelField("Cancel:");
        TermsDB.Cancel = EditorGUILayout.TextField(TermsDB.Cancel, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsMenuScreen()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("In-Game Menus:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Weapons:");
        TermsDB.Weapons = EditorGUILayout.TextField(TermsDB.Weapons, GUILayout.Width(100));

        EditorGUILayout.LabelField("Armours");
        TermsDB.Armours = EditorGUILayout.TextField(TermsDB.Armours, GUILayout.Width(100));

        EditorGUILayout.LabelField("Items:");
        TermsDB.Items = EditorGUILayout.TextField(TermsDB.Items, GUILayout.Width(100));

        EditorGUILayout.LabelField("Equip:");
        TermsDB.Equip = EditorGUILayout.TextField(TermsDB.Equip, GUILayout.Width(100));

        EditorGUILayout.LabelField("Optimize:");
        TermsDB.AutoEquip = EditorGUILayout.TextField(TermsDB.AutoEquip, GUILayout.Width(100));

        EditorGUILayout.LabelField("Clear:");
        TermsDB.Clear = EditorGUILayout.TextField(TermsDB.Clear, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsCommands()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Commands:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Fight:");
        TermsDB.Fight = EditorGUILayout.TextField(TermsDB.Fight, GUILayout.Width(100));

        EditorGUILayout.LabelField("Escape");
        TermsDB.Escape = EditorGUILayout.TextField(TermsDB.Escape, GUILayout.Width(100));

        EditorGUILayout.LabelField("Skills:");
        TermsDB.Skills = EditorGUILayout.TextField(TermsDB.Skills, GUILayout.Width(100));

        EditorGUILayout.LabelField("Status:");
        TermsDB.Status = EditorGUILayout.TextField(TermsDB.Status, GUILayout.Width(100));

        EditorGUILayout.LabelField("Save:");
        TermsDB.Save = EditorGUILayout.TextField(TermsDB.Save, GUILayout.Width(100));

        GUILayout.EndVertical();


    }

    void TermsEquipmentTypes()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Equipment Types:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Weapon:");
        TermsDB.Weapon = EditorGUILayout.TextField(TermsDB.Weapon, GUILayout.Width(100));

        EditorGUILayout.LabelField("Armour");
        TermsDB.Armour = EditorGUILayout.TextField(TermsDB.Armour, GUILayout.Width(100));

        EditorGUILayout.LabelField("Accessory:");
        TermsDB.Accessory = EditorGUILayout.TextField(TermsDB.Accessory, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsBasicStatus()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Basic Status:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Level:");
        TermsDB.Level = EditorGUILayout.TextField(TermsDB.Level, GUILayout.Width(100));

        EditorGUILayout.LabelField("Level (Short)");
        TermsDB.LevelShort = EditorGUILayout.TextField(TermsDB.LevelShort, GUILayout.Width(100));

        EditorGUILayout.LabelField("Health Points:");
        TermsDB.HP = EditorGUILayout.TextField(TermsDB.HP, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsParameters()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Parameters:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Maximum Health Points:");
        TermsDB.MaxHP = EditorGUILayout.TextField(TermsDB.MaxHP, GUILayout.Width(100));

        EditorGUILayout.LabelField("Physical Attack");
        TermsDB.StatPhysicalAttack = EditorGUILayout.TextField(TermsDB.StatPhysicalAttack, GUILayout.Width(100));

        EditorGUILayout.LabelField("Physical Defence:");
        TermsDB.StatPhysicalDefence = EditorGUILayout.TextField(TermsDB.StatPhysicalDefence, GUILayout.Width(100));

        EditorGUILayout.LabelField("Magical Attack");
        TermsDB.StatMagicalAttack = EditorGUILayout.TextField(TermsDB.StatMagicalAttack, GUILayout.Width(100));

        EditorGUILayout.LabelField("Magical Defence:");
        TermsDB.StatMagicalDefence = EditorGUILayout.TextField(TermsDB.StatMagicalDefence, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsListType(string title, List<string> list, string type)
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField(title + ":", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        for (int i = 0; i < list.Count; i++)
        {
            GUILayout.BeginHorizontal();
            list[i] = EditorGUILayout.TextField(list[i]);
            if (GUILayout.Button("X"))
                list.RemoveAt(i);
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add " + type))
        {
            list.Add("New " + type);
        }

        GUILayout.EndVertical();
    }

    //TODO: make partial classes to move methods for each tab into their own file
    //TODO: remember to set window min size per tab
    //TODO: scriptable object utility can be deleted (I think)
}