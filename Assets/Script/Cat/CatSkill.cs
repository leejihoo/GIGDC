using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSkill : MonoBehaviour
{
    public List<GameObject> Skill;
    public bool IsDelay;
    public bool SkillRunnig;

    private GameObject _assassination;
    private GameObject _chattering;
    private GameObject _grooming;
    private GameObject _hairBall;
    [SerializeField]
    private List<AudioClip> _skillMusics = new List<AudioClip>();

    enum skillType
    {
        ASSASSINATION, CHATTERING, GROOMING, HAIRBALL
    }

    public CatSkill()
    {
        Skill = new List<GameObject>();
        IsDelay = false;
        SkillRunnig = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        SkillCreate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!SkillRunnig)
        {
            if (!IsDelay)
                StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        IsDelay = true;
        yield return new WaitForSeconds(2);
        var randomSkillIndex = Random.Range(0, 4);
        //var randomSkillIndex = 3;
        this.GetComponent<AudioSource>().clip = _skillMusics[randomSkillIndex];
        this.GetComponent<AudioSource>().Play();
        switch (randomSkillIndex)
        {
            case (int)skillType.ASSASSINATION:
                gameObject.GetComponent<Animator>().SetBool("IsAssassinationOn", true);
                UnityEngine.Debug.Log("_assassination");
                _assassination.SetActive(true);
                _assassination.GetComponent<CatAssassination>().Cast();  
                SkillRunnig = true;
                break;
            case (int)skillType.CHATTERING:
                gameObject.GetComponent<Animator>().SetBool("IsChatteringOn", true);
                UnityEngine.Debug.Log("_chattering");
                _chattering.SetActive(true);
                _chattering.GetComponent<CatChattering>().Cast();
                SkillRunnig = true;
                break;
            case (int)skillType.GROOMING:
                gameObject.GetComponent<Animator>().SetBool("IsGroomingOn", true);
                UnityEngine.Debug.Log("_grooming");
                _grooming.SetActive(true);
                _grooming.GetComponent<CatGrooming>().Cast();
                SkillRunnig = true;
                break;
            case (int)skillType.HAIRBALL:
                gameObject.GetComponent<Animator>().SetBool("IsHairBallOn", true);
                UnityEngine.Debug.Log("_hairBall");
                _hairBall.SetActive(true);
                _hairBall.GetComponent<CatHairBall>().Cast();
                SkillRunnig = true;
                break;

        }

    }

    void SkillCreate()
    {
        _assassination = Instantiate(Skill[0]);
        _chattering = Instantiate(Skill[1]);
        _grooming = Instantiate(Skill[2]);
        _hairBall = Instantiate(Skill[3]);
    }
}
