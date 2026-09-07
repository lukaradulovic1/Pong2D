using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(Player player, Opponent opponent, Ball ball)
    {
        GameData data = new GameData(
            player.position,
            opponent.position,
            ball.position,
            player.score,
            opponent.score
        );

        PlayerPrefs.SetString("saveData", JsonUtility.ToJson(data));
    }

    public static GameData LoadGame()
    {
        string saveData = PlayerPrefs.GetString("saveData", null);
        if (saveData != null)
        {
            return JsonUtility.FromJson<GameData>(saveData);
        }
        return null;
    }
}
