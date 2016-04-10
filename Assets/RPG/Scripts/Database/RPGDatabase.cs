using UnityEngine;
using UnityEditor;
using System.Collections;

public class RPGDatabase : ScriptableObject
{
    private static RPGDatabase db = null;

    public static RPGDatabase DB
    {
        get
        {
            if (db != null)
                return db;
            else
            {
                RPGDatabase asset = null;
                asset = AssetDatabase.LoadAssetAtPath<RPGDatabase>("Assets/RPG/Database");  //UNFINISHED

                //TODO: finish singleton/implement error checking for getting asset
                //basically if db is null, create db
                //check old projects or bergzergarcade for how to on error checking with database assets
                //class variable for each tab.  classes need to be made for each tab including data such as strings, lists, slots for music etc... great
            }
        }
    }
}

/*
    private static T GetInstance()
    {
#if UNITY_EDITOR
        // If there's no instance, load or create one
        if( s_Instance == null )
        {
            string assetPathAndName = GeneratePath();
 
            // Check the asset database for an existing instance of the asset
            T asset = null;
            asset = AssetDatabase.LoadAssetAtPath( assetPathAndName, typeof( ScriptableObject ) ) as T;
 
            // If the asset doesn't exist, create it
            if( asset == null )
            {
                asset = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset( asset, assetPathAndName );
                AssetDatabase.SaveAssets();
            }
 
            s_Instance = asset;
        }
#endif
 
        return s_Instance;
    }
 
    public void SaveInstanceData()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty( s_Instance );
        AssetDatabase.SaveAssets();
#endif
    }
 
    private static string GeneratePath()
    {
        return "Assets/Singleton " + typeof( T ).ToString() + ".asset";
    }
}
*/
