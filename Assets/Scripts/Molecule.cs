using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule 
{
    private List<Atom> atoms;
    private List<Bond> bonds;

    public Molecule(List<Atom> atoms, List<Bond> bonds)
    {
        this.atoms = atoms;
        this.bonds = bonds;
    }

    public List<Atom> Atoms
    {
        get
        {
            return atoms;
        }

        set
        {
            atoms = value;
        }
    }

    public List<Bond> Bonds
    {
        get
        {
            return bonds;
        }

        set
        {
            bonds = value;
        }
    }
}
