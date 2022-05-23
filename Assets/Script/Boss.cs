using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public string Name;
    public double ProjectileSpeed;
    public int Hp;
    public List<object> Skill;
    public List<object> Booty;
}