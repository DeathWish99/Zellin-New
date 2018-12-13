using System.Collections;
using System.Collections.Generic;
/*
 * Made by Abia P.H. and Kevin T.
 * 5 November 2018
 */

public static class LevelData {

    public static int currLevelIndex = 3;

    // a method to change the current index to the next level's
    public static void NextLevel()
    {
        currLevelIndex++;
    }

    // a method to reset the current index to the first level
    public static void ResetLevel()
    {
        currLevelIndex = 3;
    }

    //////// PROPERTIES ////////
    public static int CurrLevelIndex
    {
        get
        {
            return currLevelIndex;
        }
        set
        {
            currLevelIndex = value;
        }
    }
}
