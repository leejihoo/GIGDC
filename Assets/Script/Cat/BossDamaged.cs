using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamaged : MonoBehaviour
{
    public GameObject bossDamagedSound;

    Animator anim;
    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void Damaged()
    {
        anim.SetTrigger("hit");
        StageClearInfo stageClearInfo = new StageClearInfo() { stageId = StageNumber.CurrentStage, isClear = true, bestScore = 0 };
        if(this.GetComponent<Boss>().Hp <= 0)
        {
            Debug.Log("�������");
            GameObject.Find("BattleSceneManager").GetComponent<BattleSceneManager>().Wrap(stageClearInfo);
        }
        bossDamagedSound.GetComponent<AudioSource>().Play();
        this.GetComponent<Boss>().Hp -= 1;
        Debug.Log("����ü�°���: " + this.GetComponent<Boss>().Hp);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Damaged();
            Destroy(other.gameObject);
        }
            
    }

}
