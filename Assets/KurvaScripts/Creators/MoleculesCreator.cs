using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoleculesCreator 
{
    public abstract List<Molecule> createMolecules(MoleculesData data);
}
