using TMPro;
using UnityEngine;
using Zenject;

using Firebase.Database;
using Firebase.Auth;

public class LeaderboardManager : MonoBehaviour
{
    [Inject] private PlayerData _playerData;

    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _playerScore;

    private void Start()
    {
        _playerData.MaxScore = PlayerPrefs.GetInt("MaxScore");
        _playerName.text = _playerData.UserName;
        _playerScore.text = _playerData.MaxScore.ToString();
        EventBus.OnDeathPlayer += UpdateScoreonLeaderBoard;
    }

    public void UpdateScoreonLeaderBoard()
    {
        _playerData.MaxScore = PlayerPrefs.GetInt("MaxScore");
        _playerScore.text = _playerData.MaxScore.ToString();
    }
}
