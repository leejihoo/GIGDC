using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public string Name; //보스 이름
    public double ProjectileSpeed; //투사체 속도
    public int Hp;
    //public List<GameObject> Skill;
    public List<object> Booty; //전리품

    public void Damaged()
    {     
        Hp -= 1;
        Debug.Log("보스체력감소: " + Hp);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
            Damaged();
    }
}