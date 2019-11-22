using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Atom:DataItem
{
    protected Vector3 position;

    public Atom(Vector3 pos) { position = pos; }

}
