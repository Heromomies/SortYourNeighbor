using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
   #region Singleton
   public static GameSaveManager instance;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }else if (instance != this)
      {
         Destroy(this);
      }
      DontDestroyOnLoad(this);
   }
   

   #endregion

   public LevelData levelScriptable;
   public bool IsSaveFile()
   {
      return Directory.Exists(Application.persistentDataPath + "/game_save");
   }
   public void SaveGame()
   {
      if (!IsSaveFile())
      {
         Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
         Debug.Log(Application.persistentDataPath);
      }
      if (!Directory.Exists(Application.persistentDataPath + "/game_save/level_data"))
      {
         Directory.CreateDirectory(Application.persistentDataPath + "/game_save/level_data");
      }  
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Create(Application.persistentDataPath + "/game_save/level_data/level_save.txt");
      
      var json = JsonUtility.ToJson(levelScriptable);
      
      bf.Serialize(file, json);
      file.Close();
   }

   public void LoadGame()
   {
      if (!Directory.Exists(Application.persistentDataPath + "/game_save/level_data"))
      {
         Directory.CreateDirectory(Application.persistentDataPath + "/game_save/level_data");
      }  
      BinaryFormatter bf = new BinaryFormatter();
      if (File.Exists(Application.persistentDataPath + "/game_save/level_data/level_save.txt"))
      {
         FileStream file = File.Open(Application.persistentDataPath + "/game_save/level_data/level_save.txt", FileMode.Open);
         JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), levelScriptable);
         file.Close();
      }
   }
}
