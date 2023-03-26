using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    #region local variables
    [SerializeField]List<Competitor> _competitors;
    #endregion

    #region Unity methods
    void Start()
    {
        EventMessenger.Instance.CompetitorInfo += OnCompetitorDefeated;
    }

    void onDestroy()
    {
        EventMessenger.Instance.CompetitorInfo -= OnCompetitorDefeated;
    }
    #endregion

    #region local methods
    void OnCompetitorDefeated(Competitor competitor)
    {
        _competitors.Remove(competitor);
        if(_competitors.Count <= 0) { EventMessenger.Instance.SendGameOver(true); }
    }
    #endregion
}
