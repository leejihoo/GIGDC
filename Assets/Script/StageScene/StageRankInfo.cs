using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class StageRankInfo : MonoBehaviour
{
    JObject result;
    [SerializeField]
    private TMP_Text _rankerInfo;
    [SerializeField]
    private TMP_Text _mybestScore;
    [SerializeField]
    private GameObject _content;
    
    // Start is called before the first frame update
    public void WrapCoroutine(string number)
    {   
        StartCoroutine(GetServerModeRoutine(number));
        StageNumber.CurrentStage = Convert.ToInt32(number);
    }

    IEnumerator GetServerModeRoutine(string number)
    {
        //var _email = EmailForToken.instance.KeyForToken;
        string _email = "999123@gmail.com";

        // 해당 주소로 form 데이터를 전송
        using (UnityWebRequest mode = UnityWebRequest.Get("http://13.125.177.161:8080/api/v1/stages/"+ number+"/info"))
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
                Debug.Log("랭킹 정보를 가져옵니다.");
                result = JObject.Parse(mode.downloadHandler.text);
                AddRanker();
                RenewBestScore();
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }

            mode.Dispose();
        }

    }

    public void AddRanker()
    {
        JArray ranking = (JArray)result["ranking"];

        foreach(var item in ranking)
        {
            
            var rankerInfo = Instantiate(_rankerInfo);
            rankerInfo.text = (string)item["ranking"]+ "   " + (string)item["email"] + "   " + (string)item["bestScore"];
            rankerInfo.transform.SetParent(_content.transform);
        }
    }

    public void RenewBestScore()
    {
        var info = result["info"];
        _mybestScore.text = (string)info["bestScore"];
    }

    public void ClickStartBtn()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
