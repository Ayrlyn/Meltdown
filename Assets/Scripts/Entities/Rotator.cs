using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    #region local variables
    float _acceleration = 1f;
    float _currentDifficultyTimer = 0f;
    float _currentSpeed = 0f;
    float _difficultyTimer = 10f;
    float _targetSpeed = 1f;
    #endregion

    #region unity methods
    void Start()
    {
        EventMessenger.Instance.CompetitorInfo += OnCompetitorDefeated;
    }

    void FixedUpdate()
    {
        if(_currentSpeed < _targetSpeed) { _currentSpeed += Time.deltaTime * _acceleration; }

        float x = this.transform.rotation.eulerAngles.x;
        float y = this.transform.rotation.eulerAngles.y + _currentSpeed;
        float z = this.transform.rotation.eulerAngles.z;
        this.transform.Rotate(Vector3.up, _currentSpeed);
    }

    void Update()
    {
        _currentDifficultyTimer += Time.deltaTime;
        if(_currentDifficultyTimer >= _difficultyTimer)
        {
            IncreaseSpeed();
        }
    }
    #endregion

    #region local methods
    void IncreaseSpeed()
    {
        _currentDifficultyTimer = 0f;
        _targetSpeed *= Random.Range(0.8f, 1.6f);
    }
    void OnCompetitorDefeated(Competitor competitor)
    {
        IncreaseSpeed();
    }
    #endregion
}
