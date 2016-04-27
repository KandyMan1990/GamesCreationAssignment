using UnityEngine;
using UnityEditor;

public partial class DatabaseEditor : EditorWindow
{
    const string DATABASE_WEAPONS_NAME = @"Weapons.asset";
    WeaponDB Weapon_DB;
    int SelectedWeapon = -1;

    void WeaponsButton()
    {
        if (currentEditorState != EditorState.WEAPONS)
        {
            if (GUILayout.Button("Weapons"))
            {
                currentEditorState = EditorState.WEAPONS;
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

    void WeaponsTab()
    {
        if (Weapon_DB == null)
        {
            Weapon_DB = ScriptableObjectDatabase<WeaponDB>.GetDatabase<WeaponDB>(DATABASE_FOLDER_NAME, DATABASE_WEAPONS_NAME);
        }

        GUILayout.BeginHorizontal("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        WeaponList();

        GUILayout.EndHorizontal();
    }

    void WeaponList()
    {
        GUILayout.BeginVertical("Box", GUILayout.Width(200));

        if (Weapon_DB.Count > 0)
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            for (int i = 0; i < Weapon_DB.Count; i++)
            {
                if (GUILayout.Button(Weapon_DB.Get(i).Name, "Box", GUILayout.Width(160), GUILayout.Height(20)))
                {
                    SelectedWeapon = i;
                    currentDetailsState = DetailsState.DETAILS;
                }
            }
            GUILayout.Space(5);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();

            for (int i = 0; i < Weapon_DB.Count; i++)
            {
                if (GUILayout.Button("X", "Box", GUILayout.Width(20), GUILayout.Height(20)))
                {
                    Weapon_DB.Remove(i);
                    Selection.activeInstanceID = 0;
                }
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Weapon"))
        {
            Weapon_DB.Add(new Weapon());
        }

        GUILayout.EndVertical();
    }

    void WeaponDetails()
    {
        //list of stats (can be + or -)
        //element (physical, physical and fire etc)
        GUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        if (SelectedWeapon > -1)
        {
            EditorGUILayout.LabelField("Name:");
            Weapon_DB.Get(SelectedWeapon).Name = EditorGUILayout.TextField(Weapon_DB.Get(SelectedWeapon).Name, GUILayout.Width(250));

            EditorGUILayout.LabelField("Description:");
            Weapon_DB.Get(SelectedWeapon).Description = EditorGUILayout.TextField(Weapon_DB.Get(SelectedWeapon).Description, GUILayout.Width(250));

            EditorGUILayout.LabelField("Cost:");
            Weapon_DB.Get(SelectedWeapon).Cost = EditorGUILayout.IntField(Weapon_DB.Get(SelectedWeapon).Cost, GUILayout.Width(250));

            EditorGUILayout.LabelField("Type:");
            Weapon_DB.Get(SelectedWeapon).WeaponTypeIndex = EditorGUILayout.Popup(Weapon_DB.Get(SelectedWeapon).WeaponTypeIndex, Terms_DB.WeaponTypes.ToArray());
            Weapon_DB.Get(SelectedWeapon).WepType = Terms_DB.WeaponTypes[Weapon_DB.Get(SelectedWeapon).WeaponTypeIndex];

            EditorGUILayout.LabelField("Damage Type:");
            Weapon_DB.Get(SelectedWeapon).WeaponDamageTypeIndex = EditorGUILayout.Popup(Weapon_DB.Get(SelectedWeapon).WeaponDamageTypeIndex, Element_DB.ToStringArray());
            Weapon_DB.Get(SelectedWeapon).DamageType = Element_DB.Get(Weapon_DB.Get(SelectedWeapon).WeaponDamageTypeIndex);

            EditorGUILayout.LabelField("Physical Attack:");
            Weapon_DB.Get(SelectedWeapon).PhysicalAttack = EditorGUILayout.IntField(Weapon_DB.Get(SelectedWeapon).PhysicalAttack, GUILayout.Width(200));

            EditorGUILayout.LabelField("Magical Attack:");
            Weapon_DB.Get(SelectedWeapon).MagicalAttack = EditorGUILayout.IntField(Weapon_DB.Get(SelectedWeapon).MagicalAttack, GUILayout.Width(200));

            EditorGUILayout.LabelField("Icon:");
            GUILayout.BeginHorizontal();
            Weapon_DB.Get(SelectedWeapon).Icon = EditorGUILayout.ObjectField(Weapon_DB.Get(SelectedWeapon).Icon, typeof(Sprite), true) as Sprite;
            if (Weapon_DB.Get(SelectedWeapon).Icon != null)
            {
                GUILayout.Box(Weapon_DB.Get(SelectedWeapon).Icon.texture, GUILayout.Width(100), GUILayout.Height(100));
            }
            else
            {
                GUILayout.Box("NONE", GUILayout.Width(100), GUILayout.Height(100));
            }
            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Model:");
            GUILayout.BeginHorizontal();
            Weapon_DB.Get(SelectedWeapon).Model = EditorGUILayout.ObjectField(Weapon_DB.Get(SelectedWeapon).Model, typeof(GameObject), true) as GameObject;
            if (Weapon_DB.Get(SelectedWeapon).Model != null)
            {
                GUILayout.Box(AssetPreview.GetAssetPreview(Weapon_DB.Get(SelectedWeapon).Model), GUILayout.Width(100), GUILayout.Height(100));
            }
            else
            {
                GUILayout.Box("NONE", GUILayout.Width(100), GUILayout.Height(100));
            }
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            if (GUILayout.Button("Done"))
            {
                currentDetailsState = DetailsState.NONE;
                SelectedWeapon = -1;
                GUIUtility.keyboardControl = 0;
                scrollPos = Vector2.zero;
                EditorUtility.SetDirty(Weapon_DB);
            }
        }
    }
}