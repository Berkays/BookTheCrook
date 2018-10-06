using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public PlayerInfo CopInfo, ThiefInfo;

    public int CurrentTurn = 0;
    public int TurnCount = 0;

    public bool isGameEnd()
    {
        return false;
    }
}

