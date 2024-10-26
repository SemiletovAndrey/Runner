using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class UIManager : MonoBehaviour, IUIService
{
    private const float _timeToShowDeathUI = 0.5f;
    [SerializeField] private GameObject _deathUI;
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private GameObject _gUI;
    [SerializeField] private GameObject _leaderBoardUI;

    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private string _authSceneName = "FirebaseAuth";

    [Inject] private IPlayerStateMachine _playerStateMachine;
    [Inject(Id = "PlayerTransform")] private Transform _playerTransform;
    private PlayerController _playerController;
    private UIWindowAnimator _animatorDeath;

    private void Start()
    {
        _mainUI.SetActive(true);
        _deathUI.SetActive(false);
        _gUI.SetActive(false);

        _playerController = _playerTransform.GetComponent<PlayerController>();
        _playerController.enabled = false;

    }

    public void PressStartGame()
    {
        _mainUI.SetActive(false);
        _gUI?.SetActive(true);
        _playerStateMachine.ChangeState(_playerStateMachine.GetState<CenterSideState>());
        _playerController.enabled = true;
    }

    public void MainMenu()
    {
        _mainUI.SetActive(true);
        _deathUI.SetActive(false);
        EventBus.OnRestartGame?.Invoke();
        _playerStateMachine.ChangeState(_playerStateMachine.GetState<IdleState>());
    }

   

    public void ShowDeathUI()
    {
        _animatorDeath = new UIWindowAnimator(_deathUI.GetComponent<RectTransform>());
        StartCoroutine(SetActiveRestartCoroutine());
        _playerController.enabled = false;
    }

    public void ShowLeaderboard()
    {
        _leaderBoardUI.SetActive(true);
    }

    public void BackToMenu()
    {
        _leaderBoardUI.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void Logout()
    {
        FirebaseAuthManager.Instance.Logout();
        SceneManager.LoadScene(_authSceneName);
    }
    
    public void SettingsOn()
    {
        Debug.LogWarning("The settings are not implemented.");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator SetActiveRestartCoroutine()
    {
        yield return new WaitForSeconds(_timeToShowDeathUI);
        _deathUI.gameObject.SetActive(true);
        _animatorDeath.AnimateExpandWindow(Vector3.one);
        _gUI.SetActive(false);
    }
}
