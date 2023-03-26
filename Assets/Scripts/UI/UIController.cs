using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    #region serializable variables
    [SerializeField] GameObject _gameOverPopup;
    [SerializeField] TMP_Text _winLoseText;
    #endregion

    #region unity methods
    void Start()
    {
        EventMessenger.Instance.GameOver += OnGameOver;
    }

    private void OnDestroy()
    {
        EventMessenger.Instance.GameOver -= OnGameOver;
    }
    #endregion

    #region local methods
    void OnGameOver(bool victory)
    {
        if (_gameOverPopup.activeSelf) { return; }
        _gameOverPopup.SetActive(true);
        if (victory) 
        {
            _winLoseText.text = "You Win!";
            _winLoseText.color = Color.blue;
        }
        else
        {
            _winLoseText.text = "You Lose :(";
            _winLoseText.color = Color.red;
        }
    }
    #endregion

    #region public methods
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
