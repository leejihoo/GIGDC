using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumNoeHo : MonoBehaviour
{
    public GameObject lionObject;
    private LionPositionController lionPosCon;
    public GameObject skillEffect;

    void Start()
    {
        lionPosCon = lionObject.GetComponent<LionPositionController>();

        //StartCoroutine(Attack_Co());
    }

    public void Attack() { //나중에 Start에 넣기
        StartCoroutine(Attack_Co());
    }

    public IEnumerator Attack_Co() {
        
        yield return lionPosCon.HideRight_Co();

        for(int i = 1; i <= 3; i++) {
            GameObject newSkill = GameObject.Instantiate(skillEffect);
            newSkill.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(i*0.25f, 0.5f, 10f));

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(3.0f);

        yield return lionPosCon.EnterLeft_Co();
        
    }



}
