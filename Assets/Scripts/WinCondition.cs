using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    List<int> conditions = new List<int>(GameInfo.GAMEINFO.NumPlayers);
    bool change = false;

    void Start()
    {
        // 0 for neither win/lose
        // 1 for victory
        // -1 if lost
        for (int i = 0; i < GameInfo.GAMEINFO.NumPlayers; i++)
        {
            conditions.Add(0);
        }
    }

    void playerWin(int playerNum)
    {
        conditions[playerNum] = 1;
        change = true;
    }

    void playerLose(int playerNum)
    {
        conditions[playerNum] = -1;
        change = true;
    }

    // return 0 if noone has won
    // return playerNumber
    int checkPlayers()
    {
        if (!change)
            return 0;
        //check if any player has won
        /// or if everyone else has lost
        int numRemaining = 0;
        int remaining = -1;
        for (int i = 0; i < conditions.Count && numRemaining < 2; i++)
        {
            if (conditions[i] == 1) return i;
            if (conditions[i] != 0)
            {
                remaining = i;
                numRemaining++;
            }
        }

        if (numRemaining == 1)
            return remaining;
        return 0;
    }
}
