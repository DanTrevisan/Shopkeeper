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

    public static float CurrentGold
    {
        get
        {
            return m_currentGold;
        }
        set
        {
            m_currentGold = value;
        }
    }
    private static float  m_currentGold;
    #endregion
    public float initialGold = 2500;
    private void Start()
    {
        m_currentGold = initialGold;
    }
}
