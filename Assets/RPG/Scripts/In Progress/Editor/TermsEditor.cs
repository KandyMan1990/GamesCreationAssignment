﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public partial class DatabaseEditor : EditorWindow
{
    const string DATABASE_TERMS_NAME = @"Terms.asset";
    const string DATABASE_ELEMENTS_NAME = @"Elements.asset";
    Terms Terms_DB;
    ElementDB _elementDB;

    void TermsButton()
    {
        if (currentEditorState != EditorState.TERMS)
        {
            if (GUILayout.Button("Terms"))
            {
                currentEditorState = EditorState.TERMS;
                DatabaseEditor window = GetWindow<DatabaseEditor>();
                if (!window.maximized)
                {
                    window.maxSize = new Vector2(1134, 560);
                    window.minSize = window.maxSize;
                }
                GUIUtility.keyboardControl = 0;
            }
        }
    }

    void TermsTab()
    {
        if (Terms_DB == null)
        {
            Terms_DB = ScriptableObjectDatabase<Terms>.GetDatabase<Terms>(DATABASE_FOLDER_NAME, DATABASE_TERMS_NAME);
        }

        if (_elementDB == null)
        {
            _elementDB = ScriptableObjectDatabase<ElementDB>.GetDatabase<ElementDB>(DATABASE_FOLDER_NAME, DATABASE_ELEMENTS_NAME);
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
        TermsListElements();
        TermsListType("Weapon Types", Terms_DB.WeaponTypes, "Weapon");
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        TermsListType("Skill Types", Terms_DB.SkillTypes, "Skill");
        TermsListType("Armour Types", Terms_DB.ArmourTypes, "Armour");
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();


        GUILayout.EndScrollView();
    }

    void TermsTitleScreen()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Title Screen:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("New Game:");
        Terms_DB.NewGame = EditorGUILayout.TextField(Terms_DB.NewGame, GUILayout.Width(100));

        EditorGUILayout.LabelField("Load Game:");
        Terms_DB.LoadGame = EditorGUILayout.TextField(Terms_DB.LoadGame, GUILayout.Width(100));

        EditorGUILayout.LabelField("Quit Game:");
        Terms_DB.Quit = EditorGUILayout.TextField(Terms_DB.Quit, GUILayout.Width(100));

        EditorGUILayout.LabelField("Cancel:");
        Terms_DB.Cancel = EditorGUILayout.TextField(Terms_DB.Cancel, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsMenuScreen()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("In-Game Menus:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Weapons:");
        Terms_DB.Weapons = EditorGUILayout.TextField(Terms_DB.Weapons, GUILayout.Width(100));

        EditorGUILayout.LabelField("Armours:");
        Terms_DB.Armours = EditorGUILayout.TextField(Terms_DB.Armours, GUILayout.Width(100));

        EditorGUILayout.LabelField("Items:");
        Terms_DB.Items = EditorGUILayout.TextField(Terms_DB.Items, GUILayout.Width(100));

        EditorGUILayout.LabelField("Equip:");
        Terms_DB.Equip = EditorGUILayout.TextField(Terms_DB.Equip, GUILayout.Width(100));

        EditorGUILayout.LabelField("Optimize:");
        Terms_DB.AutoEquip = EditorGUILayout.TextField(Terms_DB.AutoEquip, GUILayout.Width(100));

        EditorGUILayout.LabelField("Clear:");
        Terms_DB.Clear = EditorGUILayout.TextField(Terms_DB.Clear, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsCommands()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Commands:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Fight:");
        Terms_DB.Fight = EditorGUILayout.TextField(Terms_DB.Fight, GUILayout.Width(100));

        EditorGUILayout.LabelField("Escape:");
        Terms_DB.Escape = EditorGUILayout.TextField(Terms_DB.Escape, GUILayout.Width(100));

        EditorGUILayout.LabelField("Skills:");
        Terms_DB.Skills = EditorGUILayout.TextField(Terms_DB.Skills, GUILayout.Width(100));

        EditorGUILayout.LabelField("Status:");
        Terms_DB.Status = EditorGUILayout.TextField(Terms_DB.Status, GUILayout.Width(100));

        EditorGUILayout.LabelField("Save:");
        Terms_DB.Save = EditorGUILayout.TextField(Terms_DB.Save, GUILayout.Width(100));

        GUILayout.EndVertical();


    }

    void TermsEquipmentTypes()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Equipment Types:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Weapon:");
        Terms_DB.Weapon = EditorGUILayout.TextField(Terms_DB.Weapon, GUILayout.Width(100));

        EditorGUILayout.LabelField("Armour:");
        Terms_DB.Armour = EditorGUILayout.TextField(Terms_DB.Armour, GUILayout.Width(100));

        EditorGUILayout.LabelField("Accessory:");
        Terms_DB.Accessory = EditorGUILayout.TextField(Terms_DB.Accessory, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsBasicStatus()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Basic Status:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Level:");
        Terms_DB.Level = EditorGUILayout.TextField(Terms_DB.Level, GUILayout.Width(100));

        EditorGUILayout.LabelField("Level (Short):");
        Terms_DB.LevelShort = EditorGUILayout.TextField(Terms_DB.LevelShort, GUILayout.Width(100));

        EditorGUILayout.LabelField("Health Points:");
        Terms_DB.HP = EditorGUILayout.TextField(Terms_DB.HP, GUILayout.Width(100));

        GUILayout.EndVertical();
    }

    void TermsParameters()
    {
        GUILayout.BeginVertical("Box", GUILayout.Height(160), GUILayout.Width(120));

        EditorGUILayout.LabelField("Parameters:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Maximum Health Points:");
        Terms_DB.MaxHP = EditorGUILayout.TextField(Terms_DB.MaxHP, GUILayout.Width(100));

        EditorGUILayout.LabelField("Physical Attack:");
        Terms_DB.StatPhysicalAttack = EditorGUILayout.TextField(Terms_DB.StatPhysicalAttack, GUILayout.Width(100));

        EditorGUILayout.LabelField("Physical Defence:");
        Terms_DB.StatPhysicalDefence = EditorGUILayout.TextField(Terms_DB.StatPhysicalDefence, GUILayout.Width(100));

        EditorGUILayout.LabelField("Magical Attack:");
        Terms_DB.StatMagicalAttack = EditorGUILayout.TextField(Terms_DB.StatMagicalAttack, GUILayout.Width(100));

        EditorGUILayout.LabelField("Magical Defence:");
        Terms_DB.StatMagicalDefence = EditorGUILayout.TextField(Terms_DB.StatMagicalDefence, GUILayout.Width(100));

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
            if (GUILayout.Button("X", GUILayout.Width(25), GUILayout.Height(15)))
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

    void TermsListElements()
    {
        GUILayout.BeginVertical("Box");

        EditorGUILayout.LabelField("Elements:", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal(GUILayout.Width(200));

        if (_elementDB.Count > 0)
        {
            GUILayout.BeginVertical();
            EditorGUILayout.LabelField("Name:", GUILayout.Width(100));
            for (int i = 0; i < _elementDB.Count; i++)
            {
                _elementDB.Get(i).Name = EditorGUILayout.TextField(_elementDB.Get(i).Name);
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            EditorGUILayout.LabelField("Base Value:", GUILayout.Width(80));
            for (int i = 0; i < _elementDB.Count; i++)
            {
                _elementDB.Get(i).BaseValue = EditorGUILayout.IntField(_elementDB.Get(i).BaseValue, GUILayout.Width(30));
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            EditorGUILayout.LabelField("", EditorStyles.boldLabel, GUILayout.Width(25));
            for (int i = 0; i < _elementDB.Count; i++)
            {
                if (GUILayout.Button("X", GUILayout.Width(25), GUILayout.Height(15)))
                {
                    _elementDB.Remove(i);
                    Selection.activeInstanceID = 0;
                }
            }
            GUILayout.EndVertical();
        }

        GUILayout.EndHorizontal();

        if (GUILayout.Button("Add Element"))
        {
            _elementDB.Add(new Element("New Element", 1));
            Selection.activeInstanceID = 0;
        }
        GUILayout.EndVertical();
    }
}