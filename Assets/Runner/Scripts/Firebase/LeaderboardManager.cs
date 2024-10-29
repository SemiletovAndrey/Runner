using TMPro;
using UnityEngine;
using Zenject;
using Firebase.Database;
using Firebase.Auth;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

public class LeaderboardManager : MonoBehaviour
{
    [Inject] private PlayerData _playerData;
    [Inject] private PlayerModel _playerModel;

    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _playerScore;

    [SerializeField] private TextMeshProUGUI _leaderText;

    private DatabaseReference _dataBaseRef;
    private FirebaseAuth _firebaseAuth;

    private void Start()
    {
        _dataBaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        _firebaseAuth = FirebaseAuth.DefaultInstance;
        EventBus.OnRecivedMaxScore += UpdateScoreOnLeaderBoard;

        StartCoroutine(LoadPlayerScore());
        _playerName.text = _playerData.UserName;
    }

    private void OnDestroy()
    {
        EventBus.OnRecivedMaxScore -= UpdateScoreOnLeaderBoard;
    }

    public void OpenLeaderBoard()
    {
        StartCoroutine(GetLeaders());
    }

    public void CloseLeaderBoard()
    {
        _leaderText.text = "";
    }

    public void UpdateScoreOnLeaderBoard()
    {
        _playerData.MaxScore = _playerModel.MaxScore;
        _playerScore.text = _playerData.MaxScore.ToString();
        Debug.Log("Update leaderboard");
        SaveScoreInDataBase();
    }

    public void SaveScoreInDataBase()
    {
        _dataBaseRef.Child("Leaderboard").Child(_playerData.UserName.Replace(".", "")).Child("UserName").SetValueAsync(_playerData.UserName);
        _dataBaseRef.Child("Leaderboard").Child(_playerData.UserName.Replace(".", "")).Child("Score").SetValueAsync(_playerData.MaxScore);
    }

    private IEnumerator GetLeaders()
    {
        Task<DataSnapshot> leaders = _dataBaseRef.Child("Leaderboard").OrderByChild("Score").GetValueAsync();

        yield return new WaitUntil(() => leaders.IsCompleted);

        if (leaders.Exception != null)
        {
            Debug.LogError($"ERROR: {leaders.Exception}");
        }
        else if (leaders.Result?.Value == null)
        {
            Debug.LogError("ERROR: Value == null");
        }
        else
        {
            DataSnapshot snapshot = leaders.Result;
            int numPlayer = 1;

            foreach (DataSnapshot item in snapshot.Children.Reverse())
            {
                string userName = item.Child("UserName").Value?.ToString() ?? "Unknown";
                string score = item.Child("Score").Value?.ToString() ?? "0";

                _leaderText.text += $"\n{numPlayer}. {userName} : {score}";
                numPlayer++;
            }
        }
    }

    private IEnumerator LoadPlayerScore()
    {
        Task<DataSnapshot> user = _dataBaseRef.Child("Leaderboard").Child(_playerData.UserName).GetValueAsync();

        yield return new WaitUntil(() => user.IsCompleted);

        if (user.Exception != null)
        {
            Debug.LogError(user.Exception);
        }
        else if (user.Result?.Value == null)
        {
            Debug.Log("User not found in the leaderboard, setting score to 0");
            _playerData.MaxScore = 0;
            _playerScore.text = _playerData.MaxScore.ToString();
            _playerModel.MaxScore = _playerData.MaxScore;
        }
        else
        {
            DataSnapshot snapshot = user.Result;
            _playerData.MaxScore = int.Parse(snapshot.Child("Score").Value.ToString());
            _playerScore.text = _playerData.MaxScore.ToString();
            Debug.Log($"{_playerData.UserName} = score {snapshot.Child("Score").Value}");
            _playerModel.MaxScore = _playerData.MaxScore;
        }
    }
}
