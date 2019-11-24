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
        Debug.Log("seteando moleculas en manager");
        this.molecules = molecules;
    }

    public void renderMolecules()
    {
        visualItems = new List<VisualItem>();
        foreach(Molecule m in molecules)
        {
            for(int i = 0; i < m.atomsCount(); i++)
            {
                VisualItem newItem = VisualItemsFactory.getInstance().createVisualAtom(m.getAtom(i));
                visualItems.Add(newItem);
                Debug.Log(newItem.getPosition());
            }

            for(int i = 0; i < m.bondsCount(); i++)
            {
                VisualItem newItem = new VisualBond(m.getBond(i).getInitAtom().getPosition(), m.getBond(i).getEndAtom().getPosition());
                visualItems.Add(newItem);
            }
        }
    }

    public void changeAlpha(float alpha)
    {
        //alpha = alpha / molecules.Count;
        foreach(VisualItem vItem in visualItems)
        {
            vItem.changeAlphaColor(alpha);
        }
    }
}
