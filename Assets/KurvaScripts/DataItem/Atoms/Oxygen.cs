using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : Atom
{
    public Oxygen(Vector3 pos):base(pos)
    {
    }

    public override VisualItem accept(Visitator visitator)
    {
        return visitator.visit(this);
    }
}
