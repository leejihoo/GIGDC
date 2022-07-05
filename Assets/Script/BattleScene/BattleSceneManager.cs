using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
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

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().clip = _backgroundMusic[StageNumber.CurrentStage-1];
        this.GetComponent<AudioSource>().Play();
        _background.GetComponent<SpriteRenderer>().sprite = _backgrounds[StageNumber.CurrentStage-1];
        _front.GetComponent<SpriteRenderer>().sprite = _movingObject[StageNumber.CurrentStage - 1];
        _back.GetComponent<SpriteRenderer>().sprite = _movingObject[StageNumber.CurrentStage - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
