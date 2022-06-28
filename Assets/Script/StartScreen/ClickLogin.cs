using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;

public class ClickLogin : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _email;
    [SerializeField]
    private TMP_InputField _password;
    private LoginForm _loginForm; 
    public void ClickLoginButton()
    {
        StartCoroutine(GetServerModeRoutine());
    }
    
    IEnumerator GetServerModeRoutine()
    {

        _loginForm = new LoginForm() { email = _email.text, password = _password.text };
        EmailForToken.instance.KeyForToken = _email.text;
        var convertToJson = JsonUtility.ToJson(_loginForm);
        var convertToByte = new UTF8Encoding().GetBytes(convertToJson);
        // 해당 주소로 form 데이터를 전송
        //http://localhost:8080/api/v1/login 
        using (UnityWebRequest mode = UnityWebRequest.Post("http://13.125.177.161:8080/api/v1/login", convertToJson))
        {

            mode.uploadHandler = new UploadHandlerRaw(convertToByte);
            mode.downloadHandler = new DownloadHandlerBuffer();
            mode.SetRequestHeader("Content-Type", "application/json");

            Debug.Log(mode.disposeDownloadHandlerOnDispose.ToString());
            Debug.Log(mode.disposeUploadHandlerOnDispose.ToString());
            Debug.Log(new UTF8Encoding().GetString(mode.uploadHandler.data));

            if (PlayerPrefs.HasKey(_email.text))
            {
                var a = JObject.Parse(PlayerPrefs.GetString(_email.text));
                mode.SetRequestHeader("Authorization","Bearer " + a["token"]);
            }

            // 통신이 될 때까지 기다린다.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {
                Debug.Log("로그인 성공");
                // text는 byte배열을 자동으로 string 형식으로 변환해준다.
                if (!PlayerPrefs.HasKey(_email.text))
                {
                    PlayerPrefs.SetString(_email.text, mode.downloadHandler.text);
                    Debug.Log("토큰 로컬저장소에 저장");
                }
                // 로그인 성공 후 화면 전환 
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }

            mode.Dispose();
        } 
       
    }
}
