using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClickLogin : MonoBehaviour
{
    [SerializeField]
    private InputField _email;
    [SerializeField]
    private InputField _password;
    private LoginForm _loginForm; 
    public void ClickLoginButton()
    {
        StartCoroutine(GetServerModeRoutine());
    }

    IEnumerator GetServerModeRoutine()
    {
        _loginForm = new LoginForm(_email.text, _password.text);
        var convertToJson = JsonUtility.ToJson(_loginForm);
        var convertToByte = new UTF8Encoding().GetBytes(convertToJson);
        // 해당 주소로 form 데이터를 전송
        
        using (UnityWebRequest mode = UnityWebRequest.Post("http://localhost:8080/api/v1/login", convertToJson))
        {
            if (PlayerPrefs.HasKey(_email.text))
            {
                mode.SetRequestHeader("Token", PlayerPrefs.GetString(_email.text));
            }
            
            // 통신이 될 때까지 기다린다.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {
                // text는 byte배열을 자동으로 string 형식으로 변환해준다.
                if (!PlayerPrefs.HasKey(_email.text))
                {
                    PlayerPrefs.SetString(_email.text, mode.downloadHandler.text);
                }

                // 로그인 성공 후 화면 전환 
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }
        }
       
    }
}
