using System.IO;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int score;
}

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public PlayerData bestPlayer;
    public PlayerData currentPlayer;

    public string playerName;
    public int maxScore;

    private void Awake()
    {
        if (null != gameManager)
        {
            Destroy(gameObject);
            return;
        }

        gameManager = this;
        DontDestroyOnLoad(gameObject);
        bestPlayer = new PlayerData();
        currentPlayer = new PlayerData();

        LoadPlayer();
    }


    public void SavePlayer()
    {
        if (currentPlayer.score >= bestPlayer.score)
        {
            bestPlayer = currentPlayer;
        }

        string json = JsonUtility.ToJson(bestPlayer);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            bestPlayer = JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
