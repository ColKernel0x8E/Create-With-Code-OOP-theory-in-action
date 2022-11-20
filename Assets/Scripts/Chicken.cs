using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Chicken : Cargo
{
    Animator cargoAnim;

    // POLYMORPHISM
    public override void Start()
    {
        base.Start();
        cargoAnim = GetComponent<Animator>();
        diet = new string[] {"Apple"};
    }

    public override void EatAnimation()
    {
        cargoAnim.SetBool("Eat_b", true);
    }

}
