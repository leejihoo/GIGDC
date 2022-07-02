using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAttack : MonoBehaviour
{
    public GameObject bullet;

    public void Attack() {
        GameObject newBullet = GameObject.Instantiate(bullet);
        newBullet.transform.position = this.transform.GetChild(0).transform.position;
        newBullet.transform.Translate(0,0,1);


    }


}
