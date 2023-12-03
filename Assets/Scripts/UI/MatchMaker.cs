using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Security.Cryptography;
using System.Text;

[System.Serializable]
public class Match
{
    public string matchID;
    public bool publicMatch;
    public bool inMatch;
    public bool matchFull;
    public List<Player> players = new List<Player>();

    public Match(string matchID, Player player)//, bool publicMatch)
    {
        matchFull = false;
        inMatch = false;
        this.matchID = matchID;
        //this.publicMatch = publicMatch;
        players.Add(player);
    }

    public Match() { }
}



public class MatchMaker : NetworkBehaviour
{
    public static MatchMaker instance;

    public SyncList<Match> matches = new SyncList<Match>();
    public SyncList<String> matchIDs = new SyncList<String>();


    private void Start()
    {
        instance = this;
    }
    public bool HostGame(string _matchID, Player _player)
    {
        if (!matchIDs.Contains(_matchID))
        {
            matchIDs.Add(_matchID);
            Match match = new Match(_matchID, _player);
            matches.Add(match);
            Debug.Log($"Match generated");
            return true;
        }
        else
        {
            Debug.Log($"Match ID already exists");
            return false;
        }

    }

    public bool JoinGame(string _matchID, Player _player)//, out int playerIndex)
    {
        //playerIndex = -1;

        if (matchIDs.Contains(_matchID))
        {

            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].matchID == _matchID)
                {
                    if (!matches[i].inMatch && !matches[i].matchFull)
                    {
                        matches[i].players.Add(_player);
                        _player.currentMatch = matches[i];
                        // playerIndex = matches[i].players.Count;

                        //matches[i].players[0].PlayerCountUpdated(matches[i].players.Count);

                        //if (matches[i].players.Count == maxMatchPlayers)
                        //{
                        //    matches[i].matchFull = true;
                        //}

                        break;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            Debug.Log($"Match joined");
            return true;
        }
        else
        {
            Debug.Log($"Match ID does not exist");
            return false;
        }
    }


    public static string GetRandomMatchID()
    {
        string _id = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            int random = UnityEngine.Random.Range(0, 36);
            if (random < 26)
            {
                _id += (char)(random + 65);
            }
            else
            {
                _id += (random - 26).ToString();
            }
        }
        Debug.Log($"Random Match ID: {_id}");
        return _id;
    }




}

public static class MatchExtensions
{
    public static Guid ToGuid(this string id)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] inputBytes = Encoding.Default.GetBytes(id);
        byte[] hashBytes = provider.ComputeHash(inputBytes);

        return new Guid(hashBytes);
    }
}