using UnityEngine;
using UnityEditor;

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

            EditorGUILayout.LabelField("Health Curve:");
            Character_DB.Get(SelectedCharacter).HpCurve = EditorGUILayout.CurveField(Character_DB.Get(SelectedCharacter).HpCurve);

            EditorGUILayout.LabelField("Physical Attack Curve:");
            Character_DB.Get(SelectedCharacter).PhyAtkCurve = EditorGUILayout.CurveField(Character_DB.Get(SelectedCharacter).PhyAtkCurve);

            EditorGUILayout.LabelField("Physical Defence Curve:");
            Character_DB.Get(SelectedCharacter).PhyDefCurve = EditorGUILayout.CurveField(Character_DB.Get(SelectedCharacter).PhyDefCurve);

            EditorGUILayout.LabelField("Magical Attack Curve:");
            Character_DB.Get(SelectedCharacter).MagAtkCurve = EditorGUILayout.CurveField(Character_DB.Get(SelectedCharacter).MagAtkCurve);

            EditorGUILayout.LabelField("Magical Defence Curve:");
            Character_DB.Get(SelectedCharacter).MagDefCurve = EditorGUILayout.CurveField(Character_DB.Get(SelectedCharacter).MagDefCurve);

            EditorGUILayout.LabelField("Speed Curve:");
            Character_DB.Get(SelectedCharacter).SpeedCurve = EditorGUILayout.CurveField(Character_DB.Get(SelectedCharacter).SpeedCurve);

            EditorGUILayout.LabelField("Luck Curve:");
            Character_DB.Get(SelectedCharacter).LuckCurve = EditorGUILayout.CurveField(Character_DB.Get(SelectedCharacter).LuckCurve);

            EditorGUILayout.LabelField("Starting Weapon:");
            string[] Weapons = new string[Weapon_DB.Count];
            for(int i = 0; i < Weapon_DB.Count; i++)
            {
                Weapons[i] = Weapon_DB.Get(i).Name;
            }
            Character_DB.Get(SelectedCharacter).WeaponIndex = EditorGUILayout.Popup(Character_DB.Get(SelectedCharacter).WeaponIndex, Weapons);
            Character_DB.Get(SelectedCharacter).Wep = Weapon_DB.Get(Character_DB.Get(SelectedCharacter).WeaponIndex);

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
                EditorUtility.SetDirty(Character_DB);
            }
        }

    }
}