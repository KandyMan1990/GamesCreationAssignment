using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public partial class DatabaseEditor : EditorWindow
{
    const string DATABASE_CHARACTERS_NAME = @"Characters.asset";
    CharacterDB Character_DB;
    int SelectedCharacter = -1;

    void CharactersButton()
    {
        if (currentEditorState != EditorState.CHARACTERS)
        {
            if (GUILayout.Button("Characters"))
            {
                currentEditorState = EditorState.CHARACTERS;
                DatabaseEditor window = GetWindow<DatabaseEditor>();
                if (!window.maximized)
                {
                    window.maxSize = new Vector2(900, 600);
                    window.minSize = window.maxSize;
                }
                GUIUtility.keyboardControl = 0;
            }
        }
    }

    void CharactersTab()
    {
        if (Character_DB == null)
        {
            Character_DB = ScriptableObjectDatabase<CharacterDB>.GetDatabase<CharacterDB>(DATABASE_FOLDER_NAME, DATABASE_CHARACTERS_NAME);
        }

        GUILayout.BeginHorizontal("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        CharacterList();

        GUILayout.EndHorizontal();
    }

    void CharacterList()
    {
        GUILayout.BeginVertical("Box", GUILayout.Width(200));

        if (Character_DB.Count > 0)
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            for (int i = 0; i < Character_DB.Count; i++)
            {
                if (GUILayout.Button(Character_DB.Get(i).Name, "Box", GUILayout.Width(160), GUILayout.Height(20)))
                {
                    SelectedCharacter = i;
                    currentDetailsState = DetailsState.DETAILS;
                }
            }
            GUILayout.Space(5);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();

            for (int i = 0; i < Character_DB.Count; i++)
            {
                if (GUILayout.Button("X", "Box", GUILayout.Width(20), GUILayout.Height(20)))
                {
                    Character_DB.Remove(i);
                    Selection.activeInstanceID = 0;
                }
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Character"))
        {
            Character_DB.Add(new Character());
        }

        GUILayout.EndVertical();
    }

    void CharacterDetails()
    {
        GUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        if (SelectedCharacter > -1)
        {
            EditorGUILayout.LabelField("Name:");
            Character_DB.Get(SelectedCharacter).Name = EditorGUILayout.TextField(Character_DB.Get(SelectedCharacter).Name, GUILayout.Width(250));

            EditorGUILayout.LabelField("Class:");
            Character_DB.Get(SelectedCharacter).Class = (CharacterClass)EditorGUILayout.EnumPopup(Character_DB.Get(SelectedCharacter).Class, GUILayout.Width(250));

            EditorGUILayout.LabelField("Weapon Type:");
            string[] WeaponTypes = new string[Terms_DB.WeaponTypes.Count];
            for (int i = 0; i < Terms_DB.WeaponTypes.Count; i++)
            {
                WeaponTypes[i] = Terms_DB.WeaponTypes[i];
            }
            Character_DB.Get(SelectedCharacter).WeaponTypeIndex = EditorGUILayout.Popup(Character_DB.Get(SelectedCharacter).WeaponTypeIndex, WeaponTypes);
            Character_DB.Get(SelectedCharacter).WeaponType = Terms_DB.WeaponTypes[Character_DB.Get(SelectedCharacter).WeaponTypeIndex];

            EditorGUILayout.LabelField("Level:");
            Character_DB.Get(SelectedCharacter).Level = EditorGUILayout.IntSlider(Character_DB.Get(SelectedCharacter).Level, 1, 100, GUILayout.Width(250));

            EditorGUILayout.LabelField("Description:");
            Character_DB.Get(SelectedCharacter).Description = EditorGUILayout.TextField(Character_DB.Get(SelectedCharacter).Description, GUILayout.ExpandWidth(true), GUILayout.Height(100));

            EditorGUILayout.LabelField("Portrait:");
            GUILayout.BeginHorizontal();
            Character_DB.Get(SelectedCharacter).Portrait = EditorGUILayout.ObjectField(Character_DB.Get(SelectedCharacter).Portrait, typeof(Sprite), true) as Sprite;
            if (Character_DB.Get(SelectedCharacter).Portrait != null)
            {
                GUILayout.Box(Character_DB.Get(SelectedCharacter).Portrait.texture, GUILayout.Width(100), GUILayout.Height(100));
            }
            else
            {
                GUILayout.Box("NONE", GUILayout.Width(100), GUILayout.Height(100));
            }
            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Model:");
            GUILayout.BeginHorizontal();
            Character_DB.Get(SelectedCharacter).Model = EditorGUILayout.ObjectField(Character_DB.Get(SelectedCharacter).Model, typeof(GameObject), true) as GameObject;
            if (Character_DB.Get(SelectedCharacter).Model != null)
            {
                GUILayout.Box(AssetPreview.GetAssetPreview(Character_DB.Get(SelectedCharacter).Model), GUILayout.Width(100), GUILayout.Height(100));
            }
            else
            {
                GUILayout.Box("NONE", GUILayout.Width(100), GUILayout.Height(100));
            }
            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Health Stat:");
            GUILayout.BeginHorizontal(GUILayout.Width(200));

            EditorGUILayout.LabelField("Level 1:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).HealthStat.LvlOneValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).HealthStat.LvlOneValue);
            EditorGUILayout.LabelField("Level 20:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).HealthStat.LvlTwentyValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).HealthStat.LvlTwentyValue);
            EditorGUILayout.LabelField("Level 100:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).HealthStat.LvlOneHundredValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).HealthStat.LvlOneHundredValue);

            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Physical Attack Stat:");
            GUILayout.BeginHorizontal(GUILayout.Width(200));

            EditorGUILayout.LabelField("Level 1:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).PhyAtkStat.LvlOneValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).PhyAtkStat.LvlOneValue);
            EditorGUILayout.LabelField("Level 20:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).PhyAtkStat.LvlTwentyValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).PhyAtkStat.LvlTwentyValue);
            EditorGUILayout.LabelField("Level 100:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).PhyAtkStat.LvlOneHundredValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).PhyAtkStat.LvlOneHundredValue);

            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Physical Defence Stat:");
            GUILayout.BeginHorizontal(GUILayout.Width(200));

            EditorGUILayout.LabelField("Level 1:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).PhyDefStat.LvlOneValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).PhyDefStat.LvlOneValue);
            EditorGUILayout.LabelField("Level 20:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).PhyDefStat.LvlTwentyValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).PhyDefStat.LvlTwentyValue);
            EditorGUILayout.LabelField("Level 100:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).PhyDefStat.LvlOneHundredValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).PhyDefStat.LvlOneHundredValue);

            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Magical Attack Stat:");
            GUILayout.BeginHorizontal(GUILayout.Width(200));

            EditorGUILayout.LabelField("Level 1:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).MagAtkStat.LvlOneValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).MagAtkStat.LvlOneValue);
            EditorGUILayout.LabelField("Level 20:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).MagAtkStat.LvlTwentyValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).MagAtkStat.LvlTwentyValue);
            EditorGUILayout.LabelField("Level 100:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).MagAtkStat.LvlOneHundredValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).MagAtkStat.LvlOneHundredValue);

            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Magical Defence Stat:");
            GUILayout.BeginHorizontal(GUILayout.Width(200));

            EditorGUILayout.LabelField("Level 1:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).MagDefStat.LvlOneValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).MagDefStat.LvlOneValue);
            EditorGUILayout.LabelField("Level 20:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).MagDefStat.LvlTwentyValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).MagDefStat.LvlTwentyValue);
            EditorGUILayout.LabelField("Level 100:", GUILayout.Width(70));
            Character_DB.Get(SelectedCharacter).MagDefStat.LvlOneHundredValue = EditorGUILayout.IntField(Character_DB.Get(SelectedCharacter).MagDefStat.LvlOneHundredValue);

            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Starting Weapon:");
            List<Weapon> CharWepTypes = new List<Weapon>();
            foreach (Weapon wep in Weapon_DB.ReadDatabase)
            {
                if (wep.WepType == Character_DB.Get(SelectedCharacter).WeaponType)
                {
                    CharWepTypes.Add(wep);
                }
            }
            string[] Weapons = new string[CharWepTypes.Count];
            for (int i = 0; i < CharWepTypes.Count; i++)
            {
                Weapons[i] = CharWepTypes[i].Name;
            }
            Character_DB.Get(SelectedCharacter).WeaponIndex = EditorGUILayout.Popup(Character_DB.Get(SelectedCharacter).WeaponIndex, Weapons);
            Character_DB.Get(SelectedCharacter).Wep = CharWepTypes[Character_DB.Get(SelectedCharacter).WeaponIndex];

            EditorGUILayout.LabelField("Starting Armour");

            EditorGUILayout.LabelField("Starting Accessory 1");

            EditorGUILayout.LabelField("Starting Accessory 2");

            EditorGUILayout.LabelField("Starting Accessory 3");

            EditorGUILayout.LabelField("Starting Accessory 4");

            //    /*

            //    tempCharacter.Name = EditorGUILayout.TextField("Name: ", tempCharacter.Name);
            //    tempCharacter.StartingLevel = EditorGUILayout.IntSlider("Starting Level: ", tempCharacter.StartingLevel, 1, 100);
            //    tempCharacter.PhysicalAttackCurve = EditorGUILayout.CurveField("Physical Attack Curve: ", tempCharacter.PhysicalAttackCurve);
            //    tempCharacter.PhysicalDefenceCurve = EditorGUILayout.CurveField("Physical Defece Curve: ", tempCharacter.PhysicalDefenceCurve);
            //    tempCharacter.MagicalAttackCurve = EditorGUILayout.CurveField("Magical Attack Curve: ", tempCharacter.MagicalAttackCurve);
            //    tempCharacter.MagicalDefenceCurve = EditorGUILayout.CurveField("Magical Defence Curve: ", tempCharacter.MagicalDefenceCurve);
            //    tempCharacter.EvasionCurve = EditorGUILayout.CurveField("Evasion Curve: ", tempCharacter.EvasionCurve);

            //*/

            GUILayout.EndVertical();

            if (GUILayout.Button("Done"))
            {
                currentDetailsState = DetailsState.NONE;
                SelectedCharacter = -1;
                GUIUtility.keyboardControl = 0;
                EditorUtility.SetDirty(Character_DB);
            }
        }

    }
}