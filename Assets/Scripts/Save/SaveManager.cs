using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class SaveManager
{
    private static string fileExtension = ".json";

    //private static bool encryptSave = false;

    private static string GetSaveDirectory()
    {
        string path = Application.isEditor ? Application.dataPath : Application.persistentDataPath;
        path = Path.Combine(path, "Save");
        return path;
    }

    private static string ValidateFileName(string fileName)
    {
        if (!fileName.EndsWith(fileExtension))
        {
            fileName += fileExtension;
        }

        return fileName;
    }

    public static bool Load<T>(string fileName, ref T data)
    {
        fileName = ValidateFileName(fileName);

#if UNITY_EDITOR || UNITY_STANDALONE
        string path = Path.Combine(GetSaveDirectory(), fileName);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            bool isEncrypted = !json.StartsWith("{");
            if (isEncrypted)
            {
                try
                {
                    //json = SecurityManager.Decrypt(json);
                }
                catch
                {
                    Debug.LogWarning("save file was modified");
                }
            }

            try
            {
                object o = JsonUtility.FromJson<T>(json);
                data = (T)o;
            }
            catch
            {
                Debug.LogWarning("invalid json");
                return false;
            }

            return true;
        }
        else
        {
            return false;
        }
#elif UNITY_WEBGL
        // to do: handle enctypted data

        bool exists = PlayerPrefs.HasKey(fileName);

        if (exists)
        {
            string json = PlayerPrefs.GetString(fileName);
            object o = JsonUtility.FromJson<T>(json);
            data = (T)o;

            return true;
        }

        return false;
#endif

    }

    public static void Save<T>(string fileName, T data)
    {
        string json = JsonUtility.ToJson(data, true);
        //if (encryptSave) json = SecurityManager.Encrypt(json);

        fileName = ValidateFileName(fileName);

#if UNITY_EDITOR || UNITY_STANDALONE
        string directory = GetSaveDirectory();

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        string path = Path.Combine(directory, fileName);
        SaveFile(path, json);
#elif UNITY_WEBGL
        PlayerPrefs.SetString(fileName, json);
#endif
    }

    private static void SaveFile(string path, string content)
    {
        using (FileStream stream = File.Open(path, FileMode.Create))
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}