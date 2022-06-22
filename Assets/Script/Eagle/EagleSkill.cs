using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class EagleSkill : MonoBehaviour
{
    public List<GameObject> Skill;
    private List<GameObject> _feathers;
    private bool _isDelay;
    private GameObject _fly;
    private GameObject _tornado;
    private GameObject _sonicBoom;
    private bool SkillRunnig;

    public EagleSkill()
    {
        Skill = new List<GameObject>();
        _feathers = new List<GameObject>();
        
        _isDelay = false;
        SkillRunnig = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var feather = Instantiate(Skill[0]);
            feather.SetActive(false);
            _feathers.Add(feather);
            //a.GetComponent<EagleBladecaller>().Cast();
        }
        _tornado = Instantiate(Skill[1]);
        _tornado.SetActive(false);

        
        _fly = Instantiate(Skill[2]);
        _fly.SetActive(false);

        _sonicBoom = Instantiate(Skill[3]);       
        _sonicBoom.transform.SetParent(GameObject.Find("Eagle").transform);
        _sonicBoom.transform.localPosition = Vector3.zero;
        _sonicBoom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (!SkillRunnig)
        //{
        //    _fly.GetComponent<EagleFly>().Cast();
        //    SkillRunnig = true;
        //}

        if (!SkillRunnig)
        {
            _sonicBoom.SetActive(true);
            _sonicBoom.GetComponent<EagleSonicBoom>().Cast();
            SkillRunnig = true;
        }




        //if (!_isDelay)
        //{
        //    StartCoroutine(Delay());
        //}


    }

    IEnumerator Delay()
    {
        _isDelay = true;
        yield return new WaitForSeconds(3);
        foreach (var item in _feathers)
        {
            item.SetActive(true);
            item.GetComponent<EagleBladecaller>().Cast();
        }
    }
    
}
