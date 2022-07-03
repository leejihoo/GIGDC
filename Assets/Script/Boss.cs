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
}