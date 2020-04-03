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

    private List<SDFMolecule> molecules;

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
        sdfData = DeleteEndingTrash(sdfData);

        molecules = new List<SDFMolecule>();

        string[] moleculesData = sdfData.Split(new string[] { "$$$$" }, StringSplitOptions.None);
        foreach(string s in moleculesData)
            molecules.Add(new SDFMolecule(s));

        ParseData();

        GetComponent<MoleculeCreator>().ShowMolecules();
    }

    private void ParseData()
    {
        foreach(SDFMolecule mol in molecules)
        {
            List<Atom> atoms = new List<Atom>();
            List<Bond> bonds = new List<Bond>();
            for(int i=0;i<mol.Atoms.Data.Length;i++)
            {
                string[] atomLine = mol.Atoms.GetAtomLine(i);
                float x = float.Parse(atomLine[0]);
                float y = float.Parse(atomLine[1]);
                float z = float.Parse(atomLine[2]);
                string type = atomLine[3];
                Atom a = new Atom(x, y, z, type);
                atoms.Add(a);
            }
            for (int i = 0; i < mol.Bonds.Data.Length; i++)
            {
                string[] bondLine = mol.Bonds.GetBondLine(i);
                int begining = int.Parse(bondLine[0]);
                int ending = int.Parse(bondLine[1]);
                Bond b = new Bond(begining, ending);
                //Debug.Log(begining + "-" + ending);
                bonds.Add(b);
            }
            CreateMolecule(atoms, bonds);
        }
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

    string DeleteEndingTrash(string d)
    {
        return d.Substring(0, d.LastIndexOf("$"));
    }


    void CreateMolecule(List<Atom> atoms,List<Bond> bonds)
    {
        GetComponent<MoleculeCreator>().CreateMolecule(atoms, bonds);
    }



}
