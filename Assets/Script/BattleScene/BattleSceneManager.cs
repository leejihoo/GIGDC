using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
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
        Application.targetFrameRate = 60;
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


}
