using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, IUIService
{
    private const float _timeToShowDeathUI = 1.5f;
    [SerializeField] private GameObject _deathUI;
    [SerializeField] private GameObject _mainUI;

    [SerializeField] private string _authSceneName = "FirebaseAuth";

    private UIWindowAnimator _animatorDeath;

    private void Start()
    {
        _mainUI.SetActive(false);
        _deathUI.SetActive(false);
    }

    public void ShowDeathUI()
    {
        _animatorDeath = new UIWindowAnimator(_deathUI.GetComponent<RectTransform>());
        StartCoroutine(SetActiveRestartCoroutine());
    }

    public void Logout()
    {
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
    }
}
