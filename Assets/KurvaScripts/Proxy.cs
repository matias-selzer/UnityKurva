using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proxy : MonoBehaviour
{
    public string data;
    // Start is called before the first frame update
    void Start()
    {
        loadMoleculesFromSDF(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadMoleculesFromSDF(string data)
    {
        List<Molecule> molecules = new SDFMoleculesCreator().createMolecules(new SDFdata(data));
        GetComponent<MoleculesManager>().setMolecules(molecules);
        GetComponent<MoleculesManager>().renderMolecules();
        GetComponent<MoleculesManager>().changeAlpha();
    }
}
