using UnityEngine;
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

        TermsTitleScreen();
        TermsMenuScreen();

        GUILayout.EndScrollView();

        EditorUtility.SetDirty(TermsDB);
    }
    #endregion

    void DisplayDetails()
    {
        if(currentDetailsState == DetailsState.DETAILS)
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            ObjectDetails();
            GUILayout.EndHorizontal();
        }
    }

    void ObjectDetails()
    {
        switch(currentEditorState)
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

        EditorGUILayout.LabelField("Title Screen:",EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("New Game:");
        TermsDB._newGame = EditorGUILayout.TextField(TermsDB._newGame,GUILayout.Width(100));

        EditorGUILayout.LabelField("Load Game:");
        TermsDB._loadGame = EditorGUILayout.TextField(TermsDB._loadGame, GUILayout.Width(100));

        EditorGUILayout.LabelField("Quit Game:");
        TermsDB._quit = EditorGUILayout.TextField(TermsDB._quit, GUILayout.Width(100));

        EditorGUILayout.LabelField("Cancel:");
        TermsDB._cancel = EditorGUILayout.TextField(TermsDB._cancel, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsMenuScreen()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("In-Game Menus:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Weapons:");
        TermsDB._weapons = EditorGUILayout.TextField(TermsDB._weapons, GUILayout.Width(100));

        EditorGUILayout.LabelField("Armours");
        TermsDB._armours = EditorGUILayout.TextField(TermsDB._armours, GUILayout.Width(100));

        EditorGUILayout.LabelField("Items:");
        TermsDB._items = EditorGUILayout.TextField(TermsDB._items, GUILayout.Width(100));

        EditorGUILayout.LabelField("Equip:");
        TermsDB._equip = EditorGUILayout.TextField(TermsDB._equip, GUILayout.Width(100));

        EditorGUILayout.LabelField("Optimize:");
        TermsDB._autoEquip = EditorGUILayout.TextField(TermsDB._autoEquip, GUILayout.Width(100));

        EditorGUILayout.LabelField("Clear:");
        TermsDB._clear = EditorGUILayout.TextField(TermsDB._clear, GUILayout.Width(100));

        GUILayout.EndVertical();
}
}