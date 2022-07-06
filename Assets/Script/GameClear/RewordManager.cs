using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using TMPro;
public class RewordManager : MonoBehaviour
{
    private int _stageId;
    public static bool _IsCleared;
    public ItemInfoForJsons itemInfoForJsons;
    public GameObject RewordSlot;
    public GameObject SlotGroup;
    public JArray itemInfoForJsons1;
    public GameObject CharaterImage;
    public Sprite clear;
    public Sprite fail;
    public List<AudioClip> audioClips;
    public GameObject clearText;
    //public List<ItemInfoForJson> itemInfoForJsons = new List<ItemInfoForJson>();

    public RewordManager()
    {
        audioClips = new List<AudioClip>();
        // itemInfoForJsons = new ItemInfoForJsons();
        itemInfoForJsons1 = new JArray();
    }
    public void Start()
    {
        _IsCleared = StageNumber.IsClear;
        _stageId = StageNumber.CurrentStage;
        RewordSetting();
        
    }

    public void RewordSetting()
    {
        if (_IsCleared)
        {
            clearText.GetComponent<TextMeshProUGUI>().text = "Game Clear";
            gameObject.GetComponent<AudioSource>().clip = audioClips[1];
            CharaterImage.GetComponent<Image>().sprite = clear;
            ItemInfoForJson dogGum = new ItemInfoForJson() { itemId = 1, addCount = _stageId };
            ItemInfoForJson bossBooty;

            var firstItem = Instantiate(RewordSlot);
            var secondItem = Instantiate(RewordSlot);
            
            firstItem.transform.GetChild(0).GetComponent<Image>().sprite = ItemDatabase.instance.itemDB[1].ItemImage;
            firstItem.transform.SetParent(SlotGroup.transform);
            itemInfoForJsons1.Add(JObject.FromObject(dogGum));

            switch (_stageId)
            {
                case 1:
                    bossBooty = new ItemInfoForJson() { itemId = 2, addCount = 1};
                    secondItem.transform.GetChild(0).GetComponent<Image>().sprite = ItemDatabase.instance.itemDB[2].ItemImage;
                    itemInfoForJsons1.Add(JObject.FromObject(bossBooty));
                    break;
                case 2:
                    bossBooty = new ItemInfoForJson() { itemId = 3, addCount = 1 };
                    secondItem.transform.GetChild(0).GetComponent<Image>().sprite = ItemDatabase.instance.itemDB[3].ItemImage;
                    itemInfoForJsons1.Add(JObject.FromObject(bossBooty));
                    break;
                case 3:
                    bossBooty = new ItemInfoForJson() { itemId = 4, addCount = 1 };
                    secondItem.transform.GetChild(0).GetComponent<Image>().sprite = ItemDatabase.instance.itemDB[4].ItemImage;
                    itemInfoForJsons1.Add(JObject.FromObject(bossBooty));
                    break;
                case 4:
                    bossBooty = new ItemInfoForJson() { itemId = 5, addCount = 1 };
                    secondItem.transform.GetChild(0).GetComponent<Image>().sprite = ItemDatabase.instance.itemDB[5].ItemImage;
                    itemInfoForJsons1.Add(JObject.FromObject(bossBooty));
                    break;
                
            }

            secondItem.transform.SetParent(SlotGroup.transform);
            StartCoroutine(GetServerModeRoutine());
        }
        else
        {
            clearText.GetComponent<TextMeshProUGUI>().text = "Game Over";
            CharaterImage.GetComponent<Image>().sprite = fail;
            gameObject.GetComponent<AudioSource>().clip = audioClips[0];

        }
        gameObject.GetComponent<AudioSource>().Play();
    }

    IEnumerator GetServerModeRoutine()
    {
        var convertToJson = itemInfoForJsons1.ToString();
        //var convertToJson = JsonUtility.ToJson(itemInfoForJsons.itemInfoForJsons);
        var convertToByte = new UTF8Encoding().GetBytes(convertToJson);
        var _email = EmailForToken.instance.KeyForToken;
        //string _email = "999123@gmail.com";

        Debug.Log(convertToJson);
        // 해당 주소로 form 데이터를 전송
        using (UnityWebRequest mode = UnityWebRequest.Put("http://13.125.177.161:8080/api/v1/members/{memberId}/items", convertToJson))
        {

            mode.uploadHandler = new UploadHandlerRaw(convertToByte);
            mode.downloadHandler = new DownloadHandlerBuffer();
            mode.SetRequestHeader("Content-Type", "application/json");

            Debug.Log(mode.disposeDownloadHandlerOnDispose.ToString());
            Debug.Log(mode.disposeUploadHandlerOnDispose.ToString());
            Debug.Log(new UTF8Encoding().GetString(mode.uploadHandler.data));

            if (PlayerPrefs.HasKey(_email))
            {
                Debug.Log(PlayerPrefs.GetString(_email));
                var a = JObject.Parse(PlayerPrefs.GetString(_email));
                Debug.Log("Bearer " + a["token"]);
                mode.SetRequestHeader("Authorization", "Bearer " + a["token"]);
            }

            // 통신이 될 때까지 기다린다.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {
                Debug.Log("데이터베이스에 획득 아이템 저장 성공");
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }

            mode.Dispose();
        }

    }
}
