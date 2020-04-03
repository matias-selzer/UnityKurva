using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculsGraphicContainer : MonoBehaviour
{
    public Transform atomsContainer, bondsContainer, hAtomsContainer, hBondsContainer;



    public void InsertAtom(GameObject newAtom)
    {
        newAtom.transform.parent = atomsContainer;
    }
    public void InsertHAtom(GameObject newAtom)
    {
        newAtom.transform.parent = hAtomsContainer;
    }
    public void InsertBond(GameObject newBond)
    {
        newBond.transform.parent = bondsContainer;
    }
    public void InsertHBond(GameObject newBond)
    {
        newBond.transform.parent = hBondsContainer;
    }

    public void ToggleBonds(bool activate)
    {
        bondsContainer.gameObject.SetActive(activate);
    }

    public void ToggleHAtoms(bool activate)
    {
        hAtomsContainer.gameObject.SetActive(activate);
        hBondsContainer.gameObject.SetActive(activate);
    }

}
