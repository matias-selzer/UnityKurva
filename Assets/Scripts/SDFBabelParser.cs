using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SDFBabelParser : MonoBehaviour
{
    public string data,data2;

    private const string headerLine = "OpenBabel";
    private const int definitionLine = 8;
    private const int atomsComponentsLine = 3;
    private const int cerosLine = 12;
    private const string endingLine= "$$$$";

    void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
		        WebGLInput.captureAllKeyboardInput = false;
        #endif
        ParseSDF(data);
    }

    void PrintAll(string[] dataLines)
    {
        foreach(string s in dataLines)
        {
            Debug.Log(s);
        }
    }
/*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ParseSDF(data2);
        }
    }*/

    public void ParseSDF(string sdfData)
    {
        GetComponent<MoleculeCreator>().InitializeStructure();
        sdfData = DeleteMultipleSpaces(sdfData);

        string[] moleculesData = sdfData.Split(new string[] { "$$$$" }, StringSplitOptions.None);
        foreach(string s in moleculesData)
            new SDFMolecule(s);

        /*string[] dataLines = GetSeparateNumbers(sdfData);
        //PrintAll(dataLines);
        ParseMolecules(dataLines);
        GetComponent<MoleculeCreator>().ShowMolecules();*/
    }

    public void ChangeBackground (int r, int g, int b)
    {
        Camera.main.backgroundColor = new Color(r, g, b);
    }

    string DeleteMultipleSpaces(string d)
    {
        RegexOptions options = RegexOptions.None;
        Regex regex = new Regex("[ ]{2,}", options);
        return regex.Replace(d, " ");
    }

    string[] GetSeparateNumbers(string input)
    {
        return input.Split(new string[] { " " }, StringSplitOptions.None);
    }

    void ParseMolecules(string[] dataLines)
    {
        int pos = 1;
        while (pos < dataLines.Length-1)
        {
            pos = ParseSingleMolecule(dataLines, pos);
        }
    }

    int ParseSingleMolecule(string[] dataLines, int pos)
    {
        List<Atom> atoms = new List<Atom>();
        List<Bond> bonds = new List<Bond>();

        if (IsHeader(dataLines[pos]))
        {
            pos+=1;
        }

        int cantAtoms = int.Parse(dataLines[pos++]);
        int cantBonds;
        if (cantAtoms > 100000)
        {
            cantBonds = cantAtoms % 1000;
            cantAtoms = cantAtoms / 1000;
        }
        else
        {
            cantBonds = int.Parse(dataLines[pos++]);
        }

        Debug.Log("cant atoms " + cantAtoms);
        Debug.Log("cant bonds " + cantBonds);

        pos += definitionLine+1;

        for(int i = 0; i < cantAtoms; i++)
        {
            //Debug.Log(dataLines[pos]);
            float x = float.Parse(dataLines[pos]);
            float y = float.Parse(dataLines[pos + 1]);
            float z = float.Parse(dataLines[pos + 2]);
            string type = dataLines[pos + 3];

            //Debug.Log("TYpe " + type);

            pos += 16;

            Atom a = new Atom(x,y,z,type);
            atoms.Add(a);
        }

        for(int i = 0; i < cantBonds; i++)
        {
            Debug.Log(dataLines[pos]);
            int begining = int.Parse(dataLines[pos]);
            int ending;
            if (begining > 10000)
            {
                ending = begining % 1000;
                begining = begining / 1000;
            }
            else
            {
                ending = int.Parse(dataLines[pos + 1]);
            }
            pos += 7;
            Bond b = new Bond(begining,ending);
            bonds.Add(b);
        }

        CreateMolecule(atoms, bonds);

        pos = SkipTrash(dataLines, pos);

        return pos;
    }

    int SkipTrash(string[] dataLines,int pos)
    {
        while (!dataLines[pos].Contains(endingLine))
        {
            pos++;
        }
        pos += 1;
        return pos;
    }

    void CreateMolecule(List<Atom> atoms,List<Bond> bonds)
    {
        GetComponent<MoleculeCreator>().CreateMolecule(atoms, bonds);
    }

    bool IsHeader(string s)
    {
        return s.Contains(headerLine);
    }


}
