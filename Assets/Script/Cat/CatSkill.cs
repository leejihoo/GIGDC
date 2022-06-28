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
        //var randomSkillIndex = Random.Range(0, 4);
        var randomSkillIndex = 3;
        switch (randomSkillIndex)
        {
            case (int)skillType.ASSASSINATION:
                UnityEngine.Debug.Log("_assassination");
                _assassination.SetActive(true);
                _assassination.GetComponent<CatAssassination>().Cast();  
                SkillRunnig = true;
                break;
            case (int)skillType.CHATTERING:
                UnityEngine.Debug.Log("_chattering");
                _chattering.SetActive(true);
                _chattering.GetComponent<CatChattering>().Cast();
                SkillRunnig = true;
                break;
            case (int)skillType.GROOMING:
                UnityEngine.Debug.Log("_grooming");
                _grooming.SetActive(true);
                _grooming.GetComponent<CatGrooming>().Cast();
                SkillRunnig = true;
                break;
            case (int)skillType.HAIRBALL:
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
