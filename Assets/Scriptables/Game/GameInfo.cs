using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Information", menuName = "Custom Assets/Game/Game Information", order = 1)]
public class GameInfo : ScriptableObject
{
    private static GameInfo _instance;
    public static GameInfo Instance
    {
        get
        {
            if (!_instance)
                _instance = Resources.FindObjectsOfTypeAll<GameInfo>().FirstOrDefault();

            if (!_instance)
                _instance = ScriptableObject.CreateInstance<GameInfo>();

            return _instance;
        }
    }

    public int GameId;
    public LevelInfo LevelInfo;

    public PlayerInfo PlayerOne;
    public PlayerInfo PlayerTwo;

    public int CurrentTurn = 0;
    public int TurnCount = 0;

    public bool IsGameOver()
    {
        return false;
    }
}

