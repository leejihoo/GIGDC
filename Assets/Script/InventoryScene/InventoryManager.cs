using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private JArray _itmes;
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private GameObject _slot;
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
        var _email = EmailForToken.instance.KeyForToken;
        //string _email = "999123@gmail.com";

        // 해당 주소로 form 데이터를 전송
        using (UnityWebRequest mode = UnityWebRequest.Get("http://13.125.177.161:8080/api/v1/items"))
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
                _itmes = JArray.Parse(mode.downloadHandler.text);
                Debug.Log(_itmes);
                itemInfoUpdate();
                AddItemToInventory();
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }

            mode.Dispose();
        }

    }

    public void itemInfoUpdate()
    {
        foreach(var itemInfo in _itmes)
        {
            foreach(var item in ItemDatabase.instance.itemDB)
            {
                if((string)itemInfo["name"] == item.Name)
                {
                    item.Count = (int)itemInfo["count"];
                    item.Desdescription = (string)itemInfo["desdescription"];
                    break;
                }
            }           
        }
    }

    public void AddItemToInventory()
    {
        foreach (var item in ItemDatabase.instance.itemDB)
        {
            if(item.Count > 0)
            {
                var slot = Instantiate(_slot);
                slot.transform.GetChild(0).GetComponent<Image>().sprite = item.ItemImage;
                slot.transform.SetParent(_panel.transform);
                slot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Convert.ToString(item.Count);
            }
        }
    }
}
