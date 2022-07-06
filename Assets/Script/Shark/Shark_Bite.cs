using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_Bite : SkillModel
{
    public GameObject targetBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Hide());
    }

    public IEnumerator Hide() {
        
        while((shark.transform.position.x - hidePoint.position.x) < -0.1f) { //나중에 선형보간
            Vector3 temp = Vector3.Normalize(hidePoint.position - shark.transform.position);
            temp *= 0.1f;
            shark.transform.Translate(temp);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        StartCoroutine(Chase());
    }

    public IEnumerator Chase() {
        float timer = 0.0f;
        shark.transform.position = new Vector3(-shark.transform.position.x, shark.transform.position.y-1, 0);
        shark.transform.rotation = Quaternion.Euler(0, 180, -40);

        targetBox.SetActive(true);
        while(timer < 1.0f){
            targetBox.transform.position = dummy.transform.position;
            timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        StartCoroutine(Bite());
    }

    public IEnumerator Bite() {
        Vector3 initialPoint = shark.transform.position;
        Vector3 destPoint = targetBox.transform.position + Vector3.left*4 + Vector3.down*2;
        float time = 0.0f;
        //물으러가기
        while(time < 1.5f) {
            shark.transform.position = Vector3.Lerp(shark.transform.position, destPoint, Time.deltaTime*10);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        time = 0.0f;
        //돌아가기
        targetBox.SetActive(false);
        while(time < 3.0f) {
            shark.transform.position = Vector3.Lerp(shark.transform.position, initialPoint, Time.deltaTime);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        StartCoroutine(Return());
    }

    public IEnumerator Return() {
        float time = 0.0f;
        shark.transform.rotation = Quaternion.Euler(0,0,0);
        shark.transform.position = returnPoint.transform.position;
        while(time < 2.0f) {
            shark.transform.position = Vector3.Lerp(shark.transform.position, defaultPoint.transform.position, Time.deltaTime*1.5f);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        bossController_Shark.EndSkillPlaying();
        Debug.Log("Skill <Bite> End");
    }

}
