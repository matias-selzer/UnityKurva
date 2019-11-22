using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculesManager : MonoBehaviour
{
    private List<Molecule> molecules;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMolecules(List<Molecule> molecules)
    {
        this.molecules = molecules;
    }
}
