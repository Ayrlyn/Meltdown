using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMessenger : SingletonDontDestroy<EventMessenger>
{
    public event Action<Player> PlayerInfo;
    public event Action<Competitor> CompetitorInfo;
    public event Action<bool> GameOver;

    public void SendGameOver(bool victory)
    {
        GameOver?.Invoke(victory);
    }

    public void SendPlayerInformation(Player player)
    {
        PlayerInfo?.Invoke(player);
    }

    public void SendCompetitorInfo(Competitor competitor)
    {
        CompetitorInfo?.Invoke(competitor);
    }
}