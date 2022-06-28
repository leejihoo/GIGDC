using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Complete : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _email;
    [SerializeField]
    private TMP_InputField _password;
    [SerializeField]
    private TMP_InputField _passwordConfirm;
    private LoginForm _loginForm;
    public void ClickCompleteButton()
    {
        StartCoroutine(GetServerModeRoutine());
    }

    IEnumerator GetServerModeRoutine()
    {
        if(_email.text == "")
        {
            Debug.Log("이메일을 입력해주세요.");
            yield break;
        }

        if (_password.text == "")
        {
            Debug.Log("비밀번호를 입력해주세요.");
            yield break;
        }

        if (_password.text != _passwordConfirm.text)
        {
            Debug.Log("비밀번호를 확인해주세요.");
            yield break;
        }

        _loginForm = new LoginForm() { email = _email.text, password = _password.text };
        Debug.Log(_loginForm.email + " " + _loginForm.password);
        var convertToJson = JsonUtility.ToJson(_loginForm);
        var convertToByte = new UTF8Encoding().GetBytes(convertToJson);
        Debug.Log(convertToJson);
        // 해당 주소로 form 데이터를 전송
        //http://localhost:8080/api/v1/login 
        using (UnityWebRequest mode = UnityWebRequest.Post("http://13.125.177.161:8080/api/v1/signup", convertToJson))
        {
            mode.uploadHandler = new UploadHandlerRaw(convertToByte);
            mode.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            mode.SetRequestHeader("Content-Type", "application/json");
            
            if (PlayerPrefs.HasKey(_email.text))
            {
                var a = JObject.Parse(PlayerPrefs.GetString(_email.text));
                mode.SetRequestHeader("Authorization", "Bearer " + a["token"]);
            }

            // 통신이 될 때까지 기다린다.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {
                // text는 byte배열을 자동으로 string 형식으로 변환해준다.
                if (!PlayerPrefs.HasKey(_email.text))
                {
                    PlayerPrefs.SetString(_email.text, mode.downloadHandler.text);
                    Debug.Log(mode.downloadHandler.text);
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
