using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CatHairBall : SkillModel
{

    public CatHairBall()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
    }

    public override void Cast()
    {
        gameObject.transform.SetParent(GameObject.Find("Cat").transform);
        //this.GetComponent<ParticleSystem>().collision.AddPlane(GameObject.Find("RightWall").transform);
        //this.GetComponent<ParticleSystem>().collision.AddPlane(GameObject.Find("LeftWall").transform);
        //this.GetComponent<ParticleSystem>().collision.AddPlane(GameObject.Find("BottomWall").transform);
        //this.GetComponent<ParticleSystem>().collision.AddPlane(GameObject.Find("UpWall").transform);
        StartCoroutine(ContinueSkill());
    }

    IEnumerator ContinueSkill()
    {
        yield return new WaitForSeconds(5); 
        GameObject.Find("Cat").GetComponent<CatSkill>().SkillRunnig = false;
        GameObject.Find("Cat").GetComponent<CatSkill>().IsDelay = false; 
        GameObject.Find("Cat").GetComponent<Animator>().SetBool("IsHairBallOn", false);
        GameObject.Find("Cat").GetComponent<AudioSource>().Stop();
        gameObject.SetActive(false);
    }

    private void OnParticleCollision(GameObject other)
    {
        StageClearInfo stageClearInfo = new StageClearInfo() { stageId = StageNumber.CurrentStage, isClear = false, bestScore = 0 };
        if (other.name == "Player")
        {
            GameObject.Find("BattleSceneManager").GetComponent<BattleSceneManager>().Wrap(stageClearInfo);
            Debug.Log("게임종료");
        }
    }
}
