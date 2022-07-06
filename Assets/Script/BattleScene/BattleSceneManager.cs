using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Text;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class BattleSceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject _background;
    [SerializeField]
    GameObject _front;
    [SerializeField]
    GameObject _back;
    [SerializeField]
    private List<Sprite> _backgrounds = new List<Sprite>();
    [SerializeField]
    private List<AudioClip> _backgroundMusic = new List<AudioClip>();
    [SerializeField]
    private List<Sprite> _movingObject = new List<Sprite>();
    [SerializeField]
    private List<GameObject> _bosses = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().clip = _backgroundMusic[StageNumber.CurrentStage-1];
        this.GetComponent<AudioSource>().Play();
        _background.GetComponent<SpriteRenderer>().sprite = _backgrounds[StageNumber.CurrentStage-1];
        _front.GetComponent<SpriteRenderer>().sprite = _movingObject[StageNumber.CurrentStage - 1];
        _back.GetComponent<SpriteRenderer>().sprite = _movingObject[StageNumber.CurrentStage - 1];
        _bosses[StageNumber.CurrentStage - 1].SetActive(true); 
        if (StageNumber.CurrentStage == 2 || StageNumber.CurrentStage == 4)
        {
            _front.transform.localScale = Vector3.one;
            _back.transform.localScale = Vector3.one;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Wrap(StageClearInfo stageClearInfo)
    {
        StartCoroutine(GetServerModeRoutine(stageClearInfo));
    }

    IEnumerator GetServerModeRoutine(StageClearInfo stageClearInfo)
    {
        StageNumber.IsClear = stageClearInfo.isClear;
        //var convertToJson = stageClearInfo.ToString();
        var convertToJson = JsonUtility.ToJson(stageClearInfo);
        var convertToByte = new UTF8Encoding().GetBytes(convertToJson);
        //var _email = EmailForToken.instance.KeyForToken;
        string _email = "999123@gmail.com";

        Debug.Log(convertToJson);
        // 해당 주소로 form 데이터를 전송
        using (UnityWebRequest mode = UnityWebRequest.Put("http://13.125.177.161:8080/api/v1/stages/"+ StageNumber.CurrentStage+"/result", convertToJson))
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
            SceneManager.LoadScene("GameClearScene");
            mode.Dispose();
        }

    }
}
