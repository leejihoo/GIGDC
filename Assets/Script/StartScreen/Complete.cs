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
            Debug.Log("�̸����� �Է����ּ���.");
            yield break;
        }

        if (_password.text == "")
        {
            Debug.Log("��й�ȣ�� �Է����ּ���.");
            yield break;
        }

        if (_password.text != _passwordConfirm.text)
        {
            Debug.Log("��й�ȣ�� Ȯ�����ּ���.");
            yield break;
        }

        _loginForm = new LoginForm() { email = _email.text, password = _password.text };
        Debug.Log(_loginForm.email + " " + _loginForm.password);
        var convertToJson = JsonUtility.ToJson(_loginForm);
        var convertToByte = new UTF8Encoding().GetBytes(convertToJson);
        Debug.Log(convertToJson);
        // �ش� �ּҷ� form �����͸� ����
        //http://localhost:8080/api/v1/login 
        using (UnityWebRequest mode = UnityWebRequest.Post("http://13.125.177.161:8080/api/v1/signup", convertToJson))
        {
            mode.uploadHandler = new UploadHandlerRaw(convertToByte);
            mode.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            mode.SetRequestHeader("Content-Type", "application/json");

            // ����� �� ������ ��ٸ���.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {

            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }
        }

    }
}
