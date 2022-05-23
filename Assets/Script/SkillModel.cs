using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillModel : MonoBehaviour
{
    public string Name;
    public bool IsCanParrying;
    public int Damage;
    public int HoldingTime;

    public virtual void Cast() { }
}
