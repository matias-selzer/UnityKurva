using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Atom:DataItem
{
    protected Vector3 position;

    public Atom(Vector3 pos) { position = pos; }

    public Vector3 getPosition()
    {
        return position;
    }

    public abstract VisualItem accept(Visitator visitator);

}
