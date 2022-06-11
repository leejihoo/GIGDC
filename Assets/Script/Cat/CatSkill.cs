using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSkill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Assassination();
    }

    public void Assassination()
    {
        var assassination = gameObject.transform.GetChild(0);
        assassination.gameObject.SetActive(true);
        assassination.GetComponent<CatAssassination>().Cast();
    }

    public void Chattering()
    {

    }

    public void Grooming()
    {

    }

    public void HairBall()
    {

    }
}
