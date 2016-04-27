using UnityEngine;
using UnityEditor;

public partial class DatabaseEditor : EditorWindow
{
    const string DATABASE_ARMOURS_NAME = @"Armours.asset";
    ArmourDB Armour_DB;
    int SelectedArmour = -1;

    void ArmoursButton()
    {
        if (currentEditorState != EditorState.ARMOURS)
        {
            if (GUILayout.Button("Armours"))
            {
                currentEditorState = EditorState.ARMOURS;
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

    void ArmoursTab()
    {
        if (Armour_DB == null)
        {
            Armour_DB = ScriptableObjectDatabase<ArmourDB>.GetDatabase<ArmourDB>(DATABASE_FOLDER_NAME, DATABASE_ARMOURS_NAME);
        }

        GUILayout.BeginHorizontal("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        ArmourList();

        GUILayout.EndHorizontal();
    }

    void ArmourList()
    {
        GUILayout.BeginVertical("Box", GUILayout.Width(200));

        if (Armour_DB.Count > 0)
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            for (int i = 0; i < Armour_DB.Count; i++)
            {
                if (GUILayout.Button(Armour_DB.Get(i).Name, "Box", GUILayout.Width(160), GUILayout.Height(20)))
                {
                    SelectedArmour = i;
                    currentDetailsState = DetailsState.DETAILS;
                }
            }
            GUILayout.Space(5);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();

            for (int i = 0; i < Armour_DB.Count; i++)
            {
                if (GUILayout.Button("X", "Box", GUILayout.Width(20), GUILayout.Height(20)))
                {
                    Armour_DB.Remove(i);
                    Selection.activeInstanceID = 0;
                }
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Armour"))
        {
            Armour_DB.Add(new Armour());
        }

        GUILayout.EndVertical();
    }

    void ArmourDetails()
    {
        GUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        if (SelectedArmour > -1)
        {
            EditorGUILayout.LabelField("Name:");
            Armour_DB.Get(SelectedArmour).Name = EditorGUILayout.TextField(Armour_DB.Get(SelectedArmour).Name, GUILayout.Width(250));

            EditorGUILayout.LabelField("Description:");
            Armour_DB.Get(SelectedArmour).Description = EditorGUILayout.TextField(Armour_DB.Get(SelectedArmour).Description, GUILayout.Width(250));

            EditorGUILayout.LabelField("Cost:");
            Armour_DB.Get(SelectedArmour).Cost = EditorGUILayout.IntField(Armour_DB.Get(SelectedArmour).Cost, GUILayout.Width(250));

            EditorGUILayout.LabelField("Type:");
            Armour_DB.Get(SelectedArmour).ArmourTypeIndex = EditorGUILayout.Popup(Armour_DB.Get(SelectedArmour).ArmourTypeIndex, Terms_DB.ArmourTypes.ToArray());
            Armour_DB.Get(SelectedArmour).ArmType = Terms_DB.ArmourTypes[Armour_DB.Get(SelectedArmour).ArmourTypeIndex];

            EditorGUILayout.LabelField("Physical Defence:");
            Armour_DB.Get(SelectedArmour).PhysicalDefence = EditorGUILayout.IntField(Armour_DB.Get(SelectedArmour).PhysicalDefence, GUILayout.Width(200));

            EditorGUILayout.LabelField("Magical Defence:");
            Armour_DB.Get(SelectedArmour).MagicalDefence = EditorGUILayout.IntField(Armour_DB.Get(SelectedArmour).MagicalDefence, GUILayout.Width(200));

            EditorGUILayout.LabelField("Icon:");
            GUILayout.BeginHorizontal();
            Armour_DB.Get(SelectedArmour).Icon = EditorGUILayout.ObjectField(Armour_DB.Get(SelectedArmour).Icon, typeof(Sprite), true) as Sprite;
            if (Armour_DB.Get(SelectedArmour).Icon != null)
            {
                GUILayout.Box(Armour_DB.Get(SelectedArmour).Icon.texture, GUILayout.Width(100), GUILayout.Height(100));
            }
            else
            {
                GUILayout.Box("NONE", GUILayout.Width(100), GUILayout.Height(100));
            }
            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Model:");
            GUILayout.BeginHorizontal();
            Armour_DB.Get(SelectedArmour).Model = EditorGUILayout.ObjectField(Armour_DB.Get(SelectedArmour).Model, typeof(GameObject), true) as GameObject;
            if (Armour_DB.Get(SelectedArmour).Model != null)
            {
                GUILayout.Box(AssetPreview.GetAssetPreview(Armour_DB.Get(SelectedArmour).Model), GUILayout.Width(100), GUILayout.Height(100));
            }
            else
            {
                GUILayout.Box("NONE", GUILayout.Width(100), GUILayout.Height(100));
            }
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Done"))
            {
                currentDetailsState = DetailsState.NONE;
                SelectedArmour = -1;
                EditorUtility.SetDirty(Armour_DB);
            }
        }
    }
}