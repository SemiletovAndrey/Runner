using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAuthManager : MonoBehaviour
{
    [SerializeField] private GameObject _loginUI;
    [SerializeField] private GameObject _registerUI;

    [SerializeField] private TextMeshProUGUI _errorLoginText;
    [SerializeField] private TextMeshProUGUI _errorRegisterText;

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

    public void ErrorLoginText(string error)
    {
        _errorLoginText.text = "";
        _errorLoginText.text = error;
    }
    public void ErrorRegisterText(string error)
    {
        _errorRegisterText.text = "";
        _errorRegisterText.text = error;
    }
}
