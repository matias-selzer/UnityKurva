using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nytrogen : Atom
{
    public Nytrogen(Vector3 pos) : base(pos)
    {
    }

    public override VisualItem accept(Visitator visitator)
    {
        return visitator.visit(this);
    }
}
