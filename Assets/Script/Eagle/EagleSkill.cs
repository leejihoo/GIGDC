using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class EagleSkill : MonoBehaviour
{
    public List<GameObject> Skill;
    public bool IsDelay;
    public bool SkillRunnig;

    private List<GameObject> _feathers;
    private GameObject _fly;
    private GameObject _tornado;
    private GameObject _sonicBoom;
    [SerializeField]
    private List<AudioClip> _skillMusics = new List<AudioClip>();

    enum skillType
    {
        FEATHER, FLY, TORNADO, SONICBOOM
    }
    public EagleSkill()
    {
        Skill = new List<GameObject>();
        _feathers = new List<GameObject>();
        
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
        //if (!SkillRunnig)
        //{
        //    _fly.GetComponent<EagleFly>().Cast();
        //    SkillRunnig = true;
        //}

        //if (!SkillRunnig)
        //{
        //    _sonicBoom.SetActive(true);
        //    _sonicBoom.GetComponent<EagleSonicBoom>().Cast();
        //    SkillRunnig = true;
        //}

        //if (!IsDelay)
        //{
        //    StartCoroutine(Delay());
        //}

        if (!SkillRunnig)
        {
            if(!IsDelay)
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
            case (int)skillType.FEATHER:
                gameObject.GetComponent<Animator>().SetBool("IsFeatherBladeOn", true);
                UnityEngine.Debug.Log("feather");
                foreach (var feather in _feathers)
                {
                    feather.SetActive(true);
                    feather.GetComponent<EagleBladecaller>().Cast();
                }
                SkillRunnig = true;
                break;
            case (int)skillType.FLY:
                gameObject.GetComponent<Animator>().SetBool("IsFlyOn", true);
                UnityEngine.Debug.Log("_fly");
                _fly.SetActive(true);
                _fly.GetComponent<EagleFly>().Cast();
                SkillRunnig = true;
                break;
            case (int)skillType.TORNADO:
                gameObject.GetComponent<Animator>().SetBool("IsTornadoOn", true);
                UnityEngine.Debug.Log("_tornado");
                _tornado.SetActive(true);
                _tornado.GetComponent<EagleTornado>().Cast();
                SkillRunnig = true;
                break;
            case (int)skillType.SONICBOOM:
                gameObject.GetComponent<Animator>().SetBool("IsSonicBoomOn", true);
                UnityEngine.Debug.Log("_sonicBoom");
                _sonicBoom.SetActive(true);
                _sonicBoom.GetComponent<EagleSonicBoom>().Cast();
                SkillRunnig = true;
                break;

        }

    }

    void SkillCreate()
    {
        for (int i = 0; i < 10; i++)
        {
            var feather = Instantiate(Skill[0]);
            feather.SetActive(false);
            _feathers.Add(feather);
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
    
}
