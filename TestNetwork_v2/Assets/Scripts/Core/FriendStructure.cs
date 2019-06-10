[System.Serializable]
public struct Friend
{
    #region Varibles

    string nickname;
    int score;
    int winCount;
    int loseCount;

    #endregion



    #region Properties

    public string Nickname
    {
        get
        {
            return nickname;
        }
    }


    public int Score
    {
        get
        {
            return score;
        }
    }


    public int WinCount
    {
        get
        {
            return winCount;
        }
    }


    public int LoseCount
    {
        get
        {
            return loseCount;
        }
    }

    #endregion



    #region Constructors

    public Friend(string nickname, int score, int winCount, int loseCount)
    {
        this.nickname = nickname;
        this.score = score;
        this.winCount = winCount;
        this.loseCount = loseCount;
    }

    #endregion
}



