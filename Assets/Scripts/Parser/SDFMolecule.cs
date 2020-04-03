using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDFMolecule
{

    private SDFDefinitionLine definitionLine;
    private SDFAtoms atoms;
    private SDFBonds bonds;


    public SDFMolecule(string data)
    {
        //data ya viene con espacios simples
        string[] moleculeDataLines = data.Split(new string[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries);
        //Debug.Log(moleculeDataLines.Length);

        int headerPos = FindHeaderPos(moleculeDataLines);
        string header = moleculeDataLines[headerPos];
        string defLine = moleculeDataLines[headerPos + 1];
        //Debug.Log(header);
        //Debug.Log(defLine);
        definitionLine= new SDFDefinitionLine(defLine);
        atoms = new SDFAtoms(moleculeDataLines, headerPos + 2, definitionLine.GetCantAtoms());
        bonds = new SDFBonds(moleculeDataLines, headerPos + 2 + definitionLine.GetCantAtoms(), definitionLine.GetCantBonds());
    }

    public SDFAtoms Atoms
    {
        get
        {
            return atoms;
        }
    }

    public SDFBonds Bonds
    {
        get
        {
            return bonds;
        }
    }

    int FindHeaderPos(string[] moleculeDataLines)
    {
        int toReturn = 0;
        bool found = false;
        for(int i=0;i<moleculeDataLines.Length && !found; i++)
        {
            found = moleculeDataLines[i].Contains("OpenBabel");
            toReturn = i;
        }
        return toReturn;
    }
}
