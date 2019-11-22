using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualItemsFactory 
{
    private VisualItemsFactory() { }

    private static VisualItemsFactory instance = new VisualItemsFactory();

    public static VisualItemsFactory getInstance()
    {
        return instance;
    }

    public VisualAtom createVisualAtom(Atom atom)
    {
        return new VisualCarbon(atom.getPosition());
    }
}
