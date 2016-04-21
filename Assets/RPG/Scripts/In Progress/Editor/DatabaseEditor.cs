using UnityEngine;
using UnityEditor;

public partial class DatabaseEditor : EditorWindow
{
    enum EditorState
    {
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

    const string DATABASE_FOLDER_NAME = @"Resources/Databases";

    EditorState currentEditorState;
    DetailsState currentDetailsState;

    //Buttons scroll view
    Vector2 scrollPos = Vector2.zero;
    //int listViewWidth = 150;
    //int listViewButtonWidth = 142;
    //int listViewButtonHeight = 25;

    //int selectedIndex = -1;

    //details scroll view
    //Vector2 detailsScrollPos = Vector2.zero;

    [MenuItem("Window/Database Editor")]
    public static void Init()
    {
        DatabaseEditor window = GetWindow<DatabaseEditor>();
        window.titleContent = new GUIContent("RPG Database");
        if (!window.maximized)
        {
            window.maxSize = new Vector2(1134, 560);
            window.minSize = window.maxSize;
        }
        window.Show();
    }

    void OnEnable()
    {
        currentEditorState = EditorState.TERMS;
        currentDetailsState = DetailsState.NONE;
        if (Character_DB == null)
        {
            Character_DB = ScriptableObjectDatabase<CharacterDB>.GetDatabase<CharacterDB>(DATABASE_FOLDER_NAME, DATABASE_CHARACTERS_NAME);
        }
        if (Terms_DB == null)
        {
            Terms_DB = ScriptableObjectDatabase<TermsDB>.GetDatabase<TermsDB>(DATABASE_FOLDER_NAME, DATABASE_TERMS_NAME);
        }
        if (Element_DB == null)
        {
            Element_DB = ScriptableObjectDatabase<ElementDB>.GetDatabase<ElementDB>(DATABASE_FOLDER_NAME, DATABASE_ELEMENTS_NAME);
        }
        if (Weapon_DB == null)
        {
            Weapon_DB = ScriptableObjectDatabase<WeaponDB>.GetDatabase<WeaponDB>(DATABASE_FOLDER_NAME, DATABASE_WEAPONS_NAME);
        }
        if (System_DB == null)
        {
            System_DB = ScriptableObjectDatabase<SystemDB>.GetDatabase<SystemDB>(DATABASE_FOLDER_NAME, DATABASE_SYSTEM_NAME);
        }
    }


    void OnDestroy()
    {
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    void OnGUI()
    {
        if(currentDetailsState != DetailsState.DETAILS)
            TopBar();

        GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
        EditorGUILayout.LabelField(currentEditorState.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal(GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
        DisplayState();
        DisplayDetails();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.EndHorizontal();

        //DatabaseEditor window = GetWindow<DatabaseEditor>();
        //EditorGUILayout.LabelField(window.position.width.ToString() + " / " + window.position.height.ToString());
    }

    #region Top Bar Buttons
    void TopBar()
    {
        GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

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
    #endregion

    #region Editor Tabs
    void DisplayState()
    {
        if (currentDetailsState == DetailsState.NONE)
        {
            switch (currentEditorState)
            {
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
    #endregion

    void DisplayDetails()
    {
        if (currentDetailsState == DetailsState.DETAILS)
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            ObjectDetails();
            GUILayout.EndScrollView();
        }
    }

    void ObjectDetails()
    {
        switch (currentEditorState)
        {
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
                WeaponDetails();
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

    //TODO: remember to set window min size per tab
}