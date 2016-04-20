using UnityEngine;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScriptableObjectDatabase<T> : ScriptableObject where T : class
{
    [SerializeField]
    private List<T> database = new List<T>();

    public void Add(T type)
    {
        database.Add(type);
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }

    public void Insert(int index, T type)
    {
        database.Insert(index, type);
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }

    public void Remove(int index)
    {
        database.RemoveAt(index);
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }

    public void ClearDatabase()
    {
        database.Clear();
        database.TrimExcess();
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }

    public int Count
    {
        get { return database.Count; }
    }

    public T Get(int index)
    {
        return database.ElementAt(index);
    }

    public void Replace(int index, T type)
    {
        database[index] = type;
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }

    public T[] ToArray()
    {
        return database.ToArray();
    }

    public static U GetDatabase<U>(string dbPath, string dbName) where U : ScriptableObject
    {
        string dbFullPath = @"Assets/" + dbPath + "/" + dbName;

#if UNITY_EDITOR
        U db = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;
        if (db == null)
        {
            if (!AssetDatabase.IsValidFolder(@"Assets/" + dbPath))
                AssetDatabase.CreateFolder("Assets/", dbPath);

            db = CreateInstance<U>() as U;
            AssetDatabase.CreateAsset(db, dbFullPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        return db;
#endif
        U dbGame = Resources.Load(dbFullPath, typeof(U)) as U;

        return dbGame;

    }
}