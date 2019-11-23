using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualItemsFactory : Visitator
{
    private VisualItemsFactory() { }

    private static VisualItemsFactory instance = new VisualItemsFactory();

    public static VisualItemsFactory getInstance()
    {
        return instance;
    }

    public VisualItem createVisualAtom(Atom atom)
    {
        return atom.accept(this);
    }

    public override VisualCarbon visit(Carbon atom)
    {
        return new VisualCarbon(atom.getPosition());
    }

    public override VisualHydrogen visit(Hydrogen atom)
    {
        return new VisualHydrogen(atom.getPosition());
    }

    public override VisualNytrogen visit(Nytrogen atom)
    {
        return new VisualNytrogen(atom.getPosition());
    }

    public override VisualOxygen visit(Oxygen atom)
    {
        return new VisualOxygen(atom.getPosition());
    }
}
