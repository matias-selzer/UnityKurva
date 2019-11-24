using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class SDFMoleculesCreator : MoleculesCreator
{
    private string[] dataLines;
    private int pos;


    public override List<Molecule> createMolecules(MoleculesData data)
    {
        string stringData = deleteMultipleSpaces(data.getStringData());
        #if UNITY_EDITOR
                stringData = replaceDotsForColon(stringData);
        #endif
        pos = 0;
        dataLines = getSeparateLines(stringData);
        return parseData();
    }

 
    string replaceDotsForColon(string s)
    {
        return s.Replace('.', ',');
    }

    string deleteMultipleSpaces(string d)
    {
        RegexOptions options = RegexOptions.None;
        Regex regex = new Regex("[ ]{2,}", options);
        return regex.Replace(d, " ");
    }

    string[] getSeparateLines(string input)
    {
        return input.Split(new string[] { "\\n" }, StringSplitOptions.None);
    }

    private List<Molecule> parseData()
    {
        List<Molecule> molecules = new List<Molecule>();
        List<Atom> atoms = new List<Atom>();
        List<Bond> bonds = new List<Bond>();
        while (!reachEndOfFile())
        {
            pos++;
            string[] line = getElementsOfSingleLine();
            if (isAtomsLine(line))
            {
                Atom a = AtomsFactory.getInstance().createAtom(new Vector3(float.Parse(line[1]), float.Parse(line[2]), float.Parse(line[3])), line[4]);
                atoms.Add(a);
            }
            else if (isBondsLine(line))
            {
                
                Atom origin = atoms[int.Parse(line[1])-1];
                Atom end = atoms[int.Parse(line[2])-1];
                Bond newBond = new Bond(origin, end);
                bonds.Add(newBond);
             
            }
            else if (isEndOfMolecule(line) || reachEndOfFile())
            {
                molecules.Add(new Molecule(atoms, bonds));
                atoms = new List<Atom>();
                bonds = new List<Bond>();
            }
        }
        return molecules;
    }

    bool isEndOfMolecule(string[] line)
    {
        return line[0].Equals("$$$$");
    }

    bool isAtomsLine(string[] line)
    {
        return line.Length == 17;
    }

    bool isBondsLine(string[] line)
    {
        return line.Length == 5;
    }

    string[] getElementsOfSingleLine()
    {
        return dataLines[pos].Split(' ');
    }

    private bool reachEndOfFile()
    {
        return pos >= dataLines.Length - 1;
    }
}
