using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamaged : MonoBehaviour
{
    public GameObject bossDamagedSound;
    public void Damaged()
    {

        StageClearInfo stageClearInfo = new StageClearInfo() { stageId = StageNumber.CurrentStage, isClear = true, bestScore = 0 };
        if (this.GetComponent<Boss>().Hp <= 0)
        {
            Debug.Log("보스사망");
            GameObject.Find("BattleSceneManager").GetComponent<BattleSceneManager>().Wrap(stageClearInfo);
        }
        bossDamagedSound.GetComponent<AudioSource>().Play();
        this.GetComponent<Boss>().Hp -= 1;
        Debug.Log("보스체력감소: " + this.GetComponent<Boss>().Hp);
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
