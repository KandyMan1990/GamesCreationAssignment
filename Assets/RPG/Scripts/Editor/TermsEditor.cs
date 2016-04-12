using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public partial class DatabaseEditor : EditorWindow
{
    const string DATABASE_TERMS_NAME = @"Terms.asset";
    Terms TermsDB;

    void TermsButton()
    {
        if (currentEditorState != EditorState.TERMS)
        {
            if (GUILayout.Button("Terms"))
            {
                currentEditorState = EditorState.TERMS;
                DatabaseEditor window = GetWindow<DatabaseEditor>();
                window.minSize = new Vector2(1126, 560);
            }
        }
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

        EditorGUILayout.LabelField("Armours:");
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

        EditorGUILayout.LabelField("Escape:");
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

        EditorGUILayout.LabelField("Armour:");
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

        EditorGUILayout.LabelField("Level (Short):");
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

        EditorGUILayout.LabelField("Physical Attack:");
        TermsDB.StatPhysicalAttack = EditorGUILayout.TextField(TermsDB.StatPhysicalAttack, GUILayout.Width(100));

        EditorGUILayout.LabelField("Physical Defence:");
        TermsDB.StatPhysicalDefence = EditorGUILayout.TextField(TermsDB.StatPhysicalDefence, GUILayout.Width(100));

        EditorGUILayout.LabelField("Magical Attack:");
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
            {
                list.RemoveAt(i);
                Selection.activeInstanceID = 0;
            }
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add " + type))
        {
            list.Add("New " + type);
            Selection.activeInstanceID = 0;
        }

        GUILayout.EndVertical();
    }
}