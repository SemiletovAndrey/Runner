using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIService
{
    private const float _timeToShowDeathUI = 1.5f;
    [SerializeField] private GameObject _deathUI;
    [SerializeField] private GameObject _mainUI;

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

    private IEnumerator SetActiveRestartCoroutine()
    {
        yield return new WaitForSeconds(_timeToShowDeathUI);
        _deathUI.gameObject.SetActive(true);
        _animatorDeath.AnimateExpandWindow(Vector3.one);
    }
}
