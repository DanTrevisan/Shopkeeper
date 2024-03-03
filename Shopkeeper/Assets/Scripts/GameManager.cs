using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class GameManager : MonoBehaviour
{

    public enum GameState
    {
        STATE_PLAYING,
        STATE_PAUSED
    }
    #region variables
    public static GameState CurrentState
    {
        get
        {
            return m_GameState;
        }
        set
        {
            m_GameState = value;
        }
    }
    private static GameState m_GameState;
    #endregion
}
