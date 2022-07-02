using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
public class RewordManager : MonoBehaviour
{
    private int _stageId;
    private bool _IsCleared;
    public ItemInfoForJsons itemInfoForJsons;
    public GameObject RewordSlot;
    public GameObject SlotGroup;
    public JArray itemInfoForJsons1;
    //public List<ItemInfoForJson> itemInfoForJsons = new List<ItemInfoForJson>();

    public RewordManager()
    {
        // itemInfoForJsons = new ItemInfoForJsons();
        itemInfoForJsons1 = new JArray();
    }
    public void Start()
    {
        // test ����
        _IsCleared = true;
        _stageId = 1;

        RewordSetting();
        StartCoroutine(GetServerModeRoutine());
    }

    public void RewordSetting()
    {
        if (_IsCleared)
        {

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
        }
        else
        {

        }
    }

    IEnumerator GetServerModeRoutine()
    {
        var convertToJson = itemInfoForJsons1.ToString();
        //var convertToJson = JsonUtility.ToJson(itemInfoForJsons.itemInfoForJsons);
        var convertToByte = new UTF8Encoding().GetBytes(convertToJson);
        //var _email = EmailForToken.instance.KeyForToken;
        string _email = "999123@gmail.com";

        Debug.Log(convertToJson);
        // �ش� �ּҷ� form �����͸� ����
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

            // ����� �� ������ ��ٸ���.
            yield return mode.SendWebRequest();
            if (mode.error == null)
            {
                Debug.Log("�����ͺ��̽��� ȹ�� ������ ���� ����");
            }
            else
            {
                Debug.Log("GetServerMode: " + mode.error);
            }

            mode.Dispose();
        }

    }
}
