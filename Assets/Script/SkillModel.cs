using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillModel : MonoBehaviour
{
    public LionPositionController lionPosCon;
    public Shark shark;
    public BossController_Shark bossController_Shark;
    public Transform defaultPoint, hidePoint, returnPoint;
    public BossController_Lion bossController;
    public GameObject dummy;
    public string Name;
    public bool IsCanParrying;
    public int Damage;
    public int HoldingTime;

    public virtual void Cast() { }
}
