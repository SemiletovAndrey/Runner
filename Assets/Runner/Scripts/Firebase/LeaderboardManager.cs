using TMPro;
using UnityEngine;
using Zenject;
using Firebase.Database;
using Firebase.Auth;
using System.Collections;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    [Inject] private PlayerData _playerData;

    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _playerScore;

    [SerializeField] private TextMeshProUGUI _leaderText;

    private DatabaseReference _dataBaseRef;
    private FirebaseAuth _firebaseAuth;

    private void Start()
    {
        _playerData.MaxScore = PlayerPrefs.GetInt("MaxScore");
        _playerName.text = _playerData.UserName;
        _playerScore.text = _playerData.MaxScore.ToString();
        EventBus.OnDeathPlayer += UpdateScoreonLeaderBoard;

        _dataBaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        _firebaseAuth = FirebaseAuth.DefaultInstance;
    }

    public void OpenLeaderBoard()
    {
        StartCoroutine(GetLeaders());
    }

    public void CloseLeaderBoard()
    {
        _leaderText.text = "";
    }

    public void UpdateScoreonLeaderBoard()
    {
        _playerData.MaxScore = PlayerPrefs.GetInt("MaxScore");
        _playerScore.text = _playerData.MaxScore.ToString();
        SaveScoreInDataBase();
    }

    public void SaveScoreInDataBase()
    {
        _dataBaseRef.Child("Leaderboard").Child(_playerData.UserName.Replace(".", "")).Child("UserName").SetValueAsync(_playerData.UserName);
        _dataBaseRef.Child("Leaderboard").Child(_playerData.UserName.Replace(".", "")).Child("Score").SetValueAsync(_playerData.MaxScore);
    }

    private IEnumerator GetLeaders()
    {
        var leaders = _dataBaseRef.Child("Leaderboard").OrderByChild("Score").GetValueAsync();

        yield return new WaitUntil(predicate: () => leaders.IsCompleted);

        if (leaders.Exception != null)
        {
            Debug.Log($" ERROR: {leaders.Exception}");
        }
        else if (leaders.Result.Value == null)
        {
            Debug.LogError($"ERROR Value == null");
        }
        else
        {
            DataSnapshot snapshot = leaders.Result;
            int numPlayer = 1;
            foreach (DataSnapshot item in snapshot.Children.Reverse())
            {
                _leaderText.text += "\n" + numPlayer + " " + item.Child("UserName").Value.ToString() + " : " + item.Child("Score").Value.ToString();
                numPlayer++;
            }
        }
    }
}
