using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Visitator 
{
    public abstract VisualCarbon visit(Carbon atom);
    public abstract VisualHydrogen visit(Hydrogen atom);
    public abstract VisualNytrogen visit(Nytrogen atom);
    public abstract VisualOxygen visit(Oxygen atom);
}
