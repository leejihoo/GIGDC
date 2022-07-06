using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Boss
{
    Animator animator;
    private void Start() {
        animator = this.GetComponent<Animator>();
    }
    public Cat()
    {
        Hp = 500;
    }

}
