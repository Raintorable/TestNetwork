using UnityEngine;
using System.Collections.Generic;


public class Player : MonoBehaviourSingleton<Player>
{
    #region Varibles

    [SerializeField] string nickname;
    [SerializeField] int balance;
    [SerializeField] int score;

    [SerializeField] int friendsCount = 100;

    List<Friend> friends;

    #endregion



    #region Properties

    public List<Friend> GetFriendsList
    {
        get
        {
            return friends;
        }
    }


    public string Nickname
    {
        get
        {
            return nickname;
        }
    }


    public int Balance
    {
        get
        {
            return balance;
        }
    }


    public int Score
    {
        get
        {
            return score;
        }
    }

    #endregion



    #region Unity lifecycle

    void Awake()
    {
        friends = new List<Friend>();

        for (int i = 0; i < friendsCount; i++)
        {
            Friend friend = new Friend("PLAYERSNAME", Random.Range(100, 1000), Random.Range(10, 100), Random.Range(10, 100));
            friends.Add(friend);
        }
    }

    #endregion
}
