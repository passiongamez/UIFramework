using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccountManagement : MonoBehaviour
{
    [SerializeField] TMP_InputField _usernameInput;
    [SerializeField] TMP_InputField _passwordInput;
    [SerializeField] TextMeshProUGUI _usernameDebug;
    [SerializeField] TextMeshProUGUI _passwordDebug;
    [SerializeField] TMP_InputField _loginUsername;
    [SerializeField] TMP_InputField _loginPassword;
    [SerializeField] TextMeshProUGUI _loginUsernameDebug;
    [SerializeField] TextMeshProUGUI _loginPasswordDebug;
    [SerializeField] string _username;
    [SerializeField] string _password;

    public void CreateAccount()
    {
        if(_usernameInput.text.Length > 4 && _usernameInput.text.Length < 10 && _passwordInput.text.Length > 4 && _passwordInput.text.Length < 10)
        {
            _username = _usernameInput.text;
            PlayerPrefs.SetString("Username", _username);
            _usernameDebug.text = "Username accepted. Your username is " + _username;

            _password = _passwordInput.text;
            PlayerPrefs.SetString("Password", _password);
            _passwordDebug.text = "Password accepted. Your password is " + _password;
        }
        else
        {
            _usernameDebug.text = "Username is invalid. Username must be between 4 and 10 characters.";
            _username = null;
            _usernameInput.text = "";

            _passwordDebug.text = "Password is invalid. Password must be between 4 and 10 characters long.";
            _password = null;
            _passwordInput.text = "";
        }

        _usernameInput.text = "";
        _passwordInput.text = "";
    }

    public void Login()
    {
        if(_loginUsername.text == _username && _loginPassword.text == _password)
        {
            PlayerPrefs.GetString("Username", _username);
            PlayerPrefs.GetString("Password", _password);
            _loginUsernameDebug.text = "Signed in as " + PlayerPrefs.GetString("Username", _username);
            _loginPasswordDebug.text = "Password " + PlayerPrefs.GetString("Password", _password) + " was correct.";
        }
        else
        {
            _loginUsernameDebug.text = "Wrong Username.";
            _loginPasswordDebug.text = "Wrong Password.";
            _loginUsername.text = "";
            _loginPassword.text = "";
        }
        _loginUsername.text = "";
        _loginPassword.text = "";
    }
}
