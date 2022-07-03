using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    private JArray _stages;
    [SerializeField]
    private GameObject _stageOne;
    [SerializeField]
    private GameObject _stageTwo;
    [SerializeField]
    private GameObject _stageThree;
    [SerializeField]
    private GameObject _stageFour;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetServerModeRoutine());
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
        using (UnityWebRequest mode = UnityWebRequest.Get("http://13.125.177.161:8080/api/v1/stages"))
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
                _stages = JArray.Parse(mode.downloadHandler.text);
                SetStageInfo();
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }

            mode.Dispose();
        }

    }

    public void SetStageInfo()
    {
        foreach(var stageInfo in _stages)
        {
            foreach(var stage in StageDatabase.instance.stage)
            {
                if ((int)stageInfo["stageId"] == stage.stageId)
                {
                    stage.isClear = Convert.ToBoolean(stageInfo["isClear"]);
                    stage.isOpen = (bool)stageInfo["isOpen"];
                    
                    if (!stage.isOpen)
                    {
                        switch (stage.stageId)
                        {
                            case 1:
                                _stageOne.GetComponent<Button>().interactable = false;
                                break;
                            case 2:
                                _stageTwo.GetComponent<Button>().interactable = false;
                                break;
                            case 3:
                                _stageThree.GetComponent<Button>().interactable = false;
                                break;
                            case 4:
                                _stageFour.GetComponent<Button>().interactable = false;
                                break;
                        }
                    }
                    else
                    {
                        switch (stage.stageId)
                        {
                            case 1:
                                _stageOne.GetComponent<Button>().interactable = true;
                                break;
                            case 2:
                                _stageTwo.GetComponent<Button>().interactable = true;
                                break;
                            case 3:
                                _stageThree.GetComponent<Button>().interactable = true;
                                break;
                            case 4:
                                _stageFour.GetComponent<Button>().interactable = true;
                                break;
                        }
                    }

                    break;
                }
            }
        }
    }
}
