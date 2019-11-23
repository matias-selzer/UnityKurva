using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule 
{
    protected List<Atom> atoms;
    protected List<Bond> bonds;

    public Molecule(List<Atom>atoms, List<Bond> bonds)
    {
        this.atoms = atoms;
        this.bonds = bonds;
    }

    public Atom getAtom(int pos)
    {
        return atoms[pos];
    }

    public Bond getBond(int pos)
    {
        return bonds[pos];
    }

    public int atomsCount()
    {
        return atoms.Count;
    }

    public int bondsCount()
    {
        return bonds.Count;
    }
}
