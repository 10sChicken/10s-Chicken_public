using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Husk
{
    public class SaveData : MonoBehaviour
    {
        [Header("저장 데이터")]
        public static SaveData instance;
        public PlayerData playerData;
        private string saveFileName = "SaveData.json";
        public bool seeOpening = false;
        private void Awake() 
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

            LoadGame();
        }



        [ContextMenu("Save Game")]
        public void SaveGame()
        {
            string dataToJson = JsonUtility.ToJson(playerData, true);

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(dataToJson);
            string code = System.Convert.ToBase64String(bytes);

            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            path = Path.Combine(path, saveFileName);

            File.WriteAllText(path, code);
        }


        [ContextMenu("Load Game")]
        public void LoadGame()
        {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            path = Path.Combine(path, saveFileName);

            if(!File.Exists(path))
            {
                NewGame();
                return;
            }


            string DataFromJson = File.ReadAllText(path);

            byte[] bytes = System.Convert.FromBase64String(DataFromJson);
            string classData = System.Text.Encoding.UTF8.GetString(bytes);
            playerData = JsonUtility.FromJson<PlayerData>(classData);

            // 암호화 하면 아래 삭제
            // playerData = JsonUtility.FromJson<PlayerData>(DataFromJson);
            
        }


        [ContextMenu("New Game")]
        public void NewGame()
        {
            playerData = new PlayerData();
            SaveGame();
            LoadGame();
        }


        #region playerData 관련
        public void PlayerDeadUpdate()
        {
            playerData.playerDeadCount++;
            SaveGame();
        }

        public void StageClearSave(int stageIndex)
        {
            playerData.stagesCleared[stageIndex] = true;
            SaveGame();
        }

        #endregion
    }

    [System.Serializable]
    public class PlayerData
    {
        public int playerDeadCount;
        public float soundVolume = .5f;
        public int langNo;
        public bool[] stagesCleared = new bool[60];

        public PlayerData()
        {
            stagesCleared[0] = true;
        }
    }
}
