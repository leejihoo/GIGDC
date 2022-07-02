using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Animator anim;
    Collider2D collider;
    int shildHp = 1000;
    bool shildActive = true;

    
    void Start()
    {
        anim = this.GetComponent<Animator>();    
        collider = this.GetComponent<Collider2D>();
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
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet") && shildActive) {
            shildHp -= 200;
            anim.SetTrigger("Attaked");
            Destroy(other.gameObject);
            if(shildHp <= 0) {
                StopCoroutine(InitShield());
                shildActive = false;
                anim.SetTrigger("Broke");
            }
        }
    }


}
