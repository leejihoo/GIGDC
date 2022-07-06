using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamaged : MonoBehaviour
{

    public void Damaged()
    {
        if(this.GetComponent<Boss>().Hp <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameClearScene");
        }
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
