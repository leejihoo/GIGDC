using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : SkillModel
{
    Animator anim;
    int shildHp = 1000;
    bool shildActive = true;

    
    void Start()
    {
        anim = this.GetComponent<Animator>();    
        StartCoroutine(InitShield());
    }

    public void Init() {
        StartCoroutine(InitShield());

    }

    IEnumerator InitShield() {
        Debug.Log("Start...");
        yield return new WaitForSeconds(10f);
        Debug.Log("Explosion...!");
        anim.SetTrigger("Explosion");
        yield return new WaitForSeconds(5.0f);
        bossController.EndSkillPlaying();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet") && shildActive) {
            shildHp -= 100;
            anim.SetTrigger("Attaked");
            Destroy(other.gameObject);
            if(shildHp <= 0) {
                StopCoroutine(InitShield());
                shildActive = false;
                anim.SetTrigger("Broke");
                StartCoroutine(Wait());
                bossController.EndSkillPlaying();
            }
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(6.0f);
    }


}
