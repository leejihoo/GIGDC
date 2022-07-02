using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

public class CharaterSceneManager : MonoBehaviour
{
    JArray _charaterInfos;
    [SerializeField]
    private int _charaterNumber;
    public int CurrentCharaterOrder;
    public Button HpBtn;
    public Button StaminaBtn;

    // Start is called before the first frame update
    void Start()
    {
        //CurrentCharaterOrder = 1;
        _charaterNumber = 3;
        for(int i = 1; i<= _charaterNumber; i++)
        {
            StartCoroutine(GetServerModeRoutineForUnlcok(i.ToString()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetServerModeRoutine()
    {
        //var _email = EmailForToken.instance.KeyForToken;
        string _email = "999123@gmail.com";

        // 해당 주소로 form 데이터를 전송
        using (UnityWebRequest mode = UnityWebRequest.Get("http://13.125.177.161:8080/api/v1/characters"))
        {
            mode.downloadHandler = new DownloadHandlerBuffer();

            if (PlayerPrefs.HasKey(_email))
            {
                var a = JObject.Parse(PlayerPrefs.GetString(_email));
                Debug.Log("Bearer " + a["token"]);
                mode.SetRequestHeader("Authorization", "Bearer " + a["token"]);
            }

            // 통신이 될 때까지 기다린다.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {
                Debug.Log("캐릭터들 정보 가져옴");
                _charaterInfos = JArray.Parse(mode.downloadHandler.text);
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }

            mode.Dispose();
        }

    }

    IEnumerator GetServerModeRoutineForUnlcok(string number)
    {
        //var _email = EmailForToken.instance.KeyForToken;
        string _email = "999123@gmail.com";

        using (UnityWebRequest mode = UnityWebRequest.Post("http://13.125.177.161:8080/api/v1/characters/" + number, ""))
        {
            mode.uploadHandler = new UploadHandlerRaw(null);
            mode.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            mode.SetRequestHeader("Content-Type", "application/json");

            if (PlayerPrefs.HasKey(_email))
            {
                var a = JObject.Parse(PlayerPrefs.GetString(_email));
                Debug.Log("Bearer " + a["token"]);
                mode.SetRequestHeader("Authorization", "Bearer " + a["token"]);
            }

            // 통신이 될 때까지 기다린다.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {
                if(Convert.ToUInt32(number) == _charaterNumber)
                {
                    Debug.Log("캐릭터들 잠금해제");
                    StartCoroutine(GetServerModeRoutine());
                }                
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }
        }

    }

    IEnumerator GetServerModeRoutineForLevelUp(string number, string state)
    {
        //var _email = EmailForToken.instance.KeyForToken;
        string _email = "999123@gmail.com";
        
        using (UnityWebRequest mode = UnityWebRequest.Post("http://13.125.177.161:8080/api/v1/characters/" + number + "/" + state, ""))
        {
            mode.uploadHandler = new UploadHandlerRaw(null);
            mode.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            mode.SetRequestHeader("Content-Type", "application/json");

            if (PlayerPrefs.HasKey(_email))
            {
                //Debug.Log("http://13.125.177.161:8080/api/v1/characters/" + number + "/" + state);
                var a = JObject.Parse(PlayerPrefs.GetString(_email));          
                mode.SetRequestHeader("Authorization", "Bearer " + a["token"]);
            }

            // 통신이 될 때까지 기다린다.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {
                Debug.Log(state + " 업그레이드 완료");
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }
        }

    }

    public void ClickRightButton()
    {
        if(CurrentCharaterOrder < 3)
        {
            CurrentCharaterOrder += 1;
        }

        Debug.Log("CurrentCharaterOrder " + CurrentCharaterOrder);
        //var Charaterinfo = _charaterInfos[CurrentCharaterOrder - 1];
        
        //if (!(bool)Charaterinfo["isopen"])
        //{
        //    HpBtn.interactable = false;
        //    StaminaBtn.interactable = false;
        //}
        //else
        //{
        //    HpBtn.interactable = true;
        //    StaminaBtn.interactable = true;
        //}

        
    }

    public void ClickLeftButton()
    {

        if (CurrentCharaterOrder > 1)
        {
            CurrentCharaterOrder -= 1;
        }

        Debug.Log("CurrentCharaterOrder " + CurrentCharaterOrder);
        //var Charaterinfo = _charaterInfos[CurrentCharaterOrder - 1];

        //if (!(bool)Charaterinfo["isopen"])
        //{
        //    HpBtn.interactable = false;
        //    StaminaBtn.interactable = false;
        //}
        //else
        //{
        //    HpBtn.interactable = true;
        //    StaminaBtn.interactable = true;
        //}

        
    }

    public void ClickHpBtn()
    {
        StartCoroutine(GetServerModeRoutineForLevelUp(CurrentCharaterOrder.ToString(), "health"));

    }

    public void ClickStaminaBtn()
    {
        StartCoroutine(GetServerModeRoutineForLevelUp(CurrentCharaterOrder.ToString(), "stamina"));
    }

}
