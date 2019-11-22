using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculesManager : MonoBehaviour
{
    private List<Molecule> molecules;
    private List<VisualItem> visualItems;

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

    public void renderMolecules()
    {
        visualItems = new List<VisualItem>();
        foreach(Molecule m in molecules)
        {
            for(int i = 0; i < m.atomsCount(); i++)
            {
                VisualCarbon vc = new VisualCarbon(m.getAtom(i).getPosition());
            }
        }

    }
}
