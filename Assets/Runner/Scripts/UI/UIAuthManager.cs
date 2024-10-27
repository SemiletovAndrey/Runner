using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAuthManager : MonoBehaviour
{
    [SerializeField] private GameObject _loginUI;
    [SerializeField] private GameObject _registerUI;

    private void Start()
    {
        _loginUI.SetActive(true);
        _registerUI.SetActive(false);
    }

    public void LoginPanelOn()
    {
        _loginUI.SetActive(true);
        _registerUI.SetActive(false);
    }

    public void RegisterPanelOn()
    {
        _loginUI.SetActive(false);
        _registerUI.SetActive(true);
    }
}
