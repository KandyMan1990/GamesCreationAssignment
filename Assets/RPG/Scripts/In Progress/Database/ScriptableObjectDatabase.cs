using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;

public class ScriptableObjectDatabase<T> : ScriptableObject where T : class
{
    [SerializeField]
    private List<T> database = new List<T>();

    public void Add(T type)
    {
        database.Add(type);
        EditorUtility.SetDirty(this);
    }

    public void Insert(int index, T type)
    {
        database.Insert(index, type);
        EditorUtility.SetDirty(this);
    }

    public void Remove(int index)
    {
        database.RemoveAt(index);
        EditorUtility.SetDirty(this);
    }

    public void ClearDatabase()
    {
        database.Clear();
        database.TrimExcess();
        EditorUtility.SetDirty(this);
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
        EditorUtility.SetDirty(this);
    }

    public T[] ToArray()
    {
        return database.ToArray();
    }

    public static U GetDatabase<U>(string dbPath, string dbName) where U : ScriptableObject
    {
        string dbFullPath = @"Assets/" + dbPath + "/" + dbName;

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
    }
}