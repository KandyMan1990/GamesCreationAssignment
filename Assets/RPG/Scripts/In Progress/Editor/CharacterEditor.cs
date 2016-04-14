using UnityEngine;
using UnityEditor;

public partial class DatabaseEditor : EditorWindow
{
    const string DATABASE_CHARACTERS_NAME = @"Characters.asset";
    CharacterDB Character_DB;
    Texture2D TempPortrait;
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
                    window.maxSize = new Vector2(900, 900);
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
                if (GUILayout.Button(Character_DB.Get(i).Name, "MiniButton", GUILayout.Width(160)))
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
                if (GUILayout.Button("X", "MiniButton", GUILayout.Width(25), GUILayout.Height(15)))
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

                EditorGUILayout.LabelField("Level:");
            Character_DB.Get(SelectedCharacter).Level = EditorGUILayout.IntSlider(Character_DB.Get(SelectedCharacter).Level, 1, 100, GUILayout.Width(250));

            EditorGUILayout.LabelField("Description:");
            Character_DB.Get(SelectedCharacter).Description = EditorGUILayout.TextArea(Character_DB.Get(SelectedCharacter).Description, GUILayout.Width(250), GUILayout.Height(250));

                EditorGUILayout.LabelField("Portrait:");
            if (Character_DB.Get(SelectedCharacter).Portrait)
                TempPortrait = Character_DB.Get(SelectedCharacter).Portrait.texture;
            else
                TempPortrait = null;

            if (GUILayout.Button(TempPortrait, GUILayout.Width(75), GUILayout.Height(75)))
            {
                int controllerID = EditorGUIUtility.GetControlID(FocusType.Passive);
                EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controllerID);
            }

            string commandName = Event.current.commandName;
            if (commandName == "ObjectSelectorUpdated")
            {
                Character_DB.Get(SelectedCharacter).Portrait = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                Repaint();
            }

            //    public GameObject Model (what type is model? just game object or specific mesh type?)


            //    /*

            //    tempCharacter.Name = EditorGUILayout.TextField("Name: ", tempCharacter.Name);
            //    tempCharacter.StartingLevel = EditorGUILayout.IntSlider("Starting Level: ", tempCharacter.StartingLevel, 1, 100);
            //    tempCharacter.HealthCurve = EditorGUILayout.CurveField("Health Curve: ", tempCharacter.HealthCurve);
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