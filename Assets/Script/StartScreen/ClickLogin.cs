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
        // �ش� �ּҷ� form �����͸� ����
        
        using (UnityWebRequest mode = UnityWebRequest.Post("http://localhost:8080/api/v1/login", convertToJson))
        {
            if (PlayerPrefs.HasKey(_email.text))
            {
                mode.SetRequestHeader("Token", PlayerPrefs.GetString(_email.text));
            }
            
            // ����� �� ������ ��ٸ���.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {
                // text�� byte�迭�� �ڵ����� string �������� ��ȯ���ش�.
                if (!PlayerPrefs.HasKey(_email.text))
                {
                    PlayerPrefs.SetString(_email.text, mode.downloadHandler.text);
                }

                // �α��� ���� �� ȭ�� ��ȯ 
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }
        }
       
    }
}
