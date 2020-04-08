using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleculeCreator : MonoBehaviour
{
    private List<Molecule> molecules;
    public GameObject genericAtom;
    public GameObject containerPrefab;
    public GameObject billboardBond;
    private Transform container;
    private ThreeDeeMatix matrix;

    public Toggle bondsToggle, hToggle,invertOpacityToggle;
    public Slider densitySlider,atomsSizeSlider,bondsSizeSlider,opacitySlider;

    private float generalOpacity;

    private bool invertOpacity = false;

    private float densityFilter = 0.0f, atomsSize = 1, bondsSize = 1;

    // Start is called before the first frame update
    void Awake()
    {
        molecules = new List<Molecule>();
    }



    public void InitializeStructure()
    {
        if(container!=null)DestroyImmediate(container.gameObject);
        GameObject newContainer = Instantiate(containerPrefab) as GameObject;
        container = newContainer.transform;
        molecules = new List<Molecule>();
        bondsToggle.isOn = true;
        hToggle.isOn = true;
    }


	public void CreateMolecule(List<Atom> atoms, List<Bond> bonds)
    {
        molecules.Add(new Molecule(atoms, bonds));
	}

    public void ShowMolecules(ThreeDeeMatix mat)
    {
        matrix = mat;
        InsertAtomsInMatrix();

        foreach(Molecule m in molecules)
        {
            ShowAtoms(m.Atoms);
            ShowBonds(m.Atoms,m.Bonds);
        }

        matrix.AssignDensityLevel();
        atomsSize = atomsSizeSlider.value;
        bondsSize = bondsSizeSlider.value;
        generalOpacity = opacitySlider.value;
        UpdateVisualization();
        densitySlider.maxValue = matrix.MaxAtomsInCell;
        // matrix.PrintAllMatrix();
    }

    private void InsertAtomsInMatrix()
    {
        foreach (Molecule m in molecules)
        {
            foreach(Atom a in m.Atoms)
            {
                matrix.InsertAtom(a);
            }
        }
    }

    private void UpdateVisualization()
    {
        foreach (Molecule m in molecules)
        {
            foreach (Atom a in m.Atoms)
            {
                float density=a.Density;

                if (!invertOpacity)
                {
                    if (densityFilter < density)
                    {
                        ChangeAtomColor(a.GraphicAtom, a.getType(), GetAtomOpacity(density));
                    }
                    else
                    {
                        ChangeAtomColor(a.GraphicAtom, a.getType(), 0);
                    }
                }
                else
                {
                    if (densityFilter > density)
                    {
                        ChangeAtomColor(a.GraphicAtom, a.getType(), GetAtomOpacity(density));
                    }
                    else
                    {
                        ChangeAtomColor(a.GraphicAtom, a.getType(), 0);
                    }
                }

                ChangeAtomSize(a);
                
            }
            foreach(Bond b in m.Bonds)
            {
                ChangeBondColor(b, m.Atoms);
                ChangeBondSize(b);
            }
        }
    }

    private float GetAtomOpacity(float density)
    {
        float toReturn = 0;
        toReturn = generalOpacity * (density / matrix.MaxAtomsInCell);
        bool smallDensityThreshold = density < matrix.MaxAtomsInCell * 0.3f;
        if (invertOpacity)
        {
            toReturn = generalOpacity * (1-((density)/matrix.MaxAtomsInCell));
            if (!smallDensityThreshold) toReturn /= matrix.MaxAtomsInCell;
        } 
        return toReturn;
    }


    private void ChangeAtomSize(Atom a)
    {
        a.GraphicAtom.transform.localScale = new Vector3(atomsSize, atomsSize, atomsSize);
    }

    private void ChangeBondSize(Bond b)
    {
        b.GraphicBond.transform.localScale = new Vector3(bondsSize, b.GraphicBond.transform.localScale.y, bondsSize);
    }

    private void ChangeBondColor(Bond bond,List<Atom> atoms)
    {
        Atom start = ((Atom)atoms[((Bond)bond).startPos - 1]);
        Atom end = ((Atom)atoms[((Bond)bond).endPos - 1]);

        float bondOpacity;

        if (!invertOpacity)
        {

            if (densityFilter < start.Density && densityFilter < end.Density)
            {
                bondOpacity = (GetAtomOpacity(start.Density) + GetAtomOpacity(end.Density)) / 2.0f;
            }
            else
            {
                bondOpacity = 0;
            }
        }
        else
        {
            if (densityFilter > start.Density || densityFilter > end.Density)
            {
                bondOpacity = (GetAtomOpacity(start.Density) + GetAtomOpacity(end.Density)) / 2.0f;
            }
            else
            {
                bondOpacity = 0;
            }
        }

        Color c = bond.GraphicBond.GetComponent<MeshRenderer>().material.color;
        //if (bondOpacity <= 0.5f) bondOpacity = 0;
        c.a = bondOpacity;
        bond.GraphicBond.GetComponent<MeshRenderer>().material.color = c;
    }

	public void ShowAtoms(List<Atom> atoms){
		for (int i = 0; i < atoms.Count; i++) {

			GameObject newAtom = Instantiate (genericAtom, ((Atom)atoms [i]).getPosition (), transform.rotation)as GameObject;
            //newAtom.transform.localScale /= 3.0f;
            ((Atom)atoms[i]).GraphicAtom = newAtom;

            //ChangeAtomColor(newAtom, ((Atom)atoms[i]).getType(), ((Atom)atoms[i]).GetOpacity());
            if (((Atom)atoms[i]).getType().Equals("H"))
            {
                container.GetComponent<MoleculsGraphicContainer>().InsertHAtom(newAtom);
            }
            else
            {
                container.GetComponent<MoleculsGraphicContainer>().InsertAtom(newAtom);
            }
            
		}
	}



    public void OnChangeAtomsSizeSlider()
    {
        atomsSize = atomsSizeSlider.value;
        UpdateVisualization();
    }

    public void OnChangeBondsSizeSlider()
    {
        bondsSize = bondsSizeSlider.value;
        UpdateVisualization();
    }

    public void OnChangeDensitySlider()
    {
        if (invertOpacity)
        {
            densityFilter = densitySlider.maxValue-densitySlider.value;
        }
        else
        {
            densityFilter = densitySlider.value;
        }
        
        //matrix.AssignOpacityLevel(opacityFilter);

        UpdateVisualization();
    }

    public void OnChangeOpacitySlider()
    {
        generalOpacity = opacitySlider.value;
        UpdateVisualization();
    }

    private void ChangeAtomColor(GameObject atom, string c,float opacity)
    {
        Color newColor = AtomsDictionaryUtils.GetAtomColor(c);
        //Color newColor;
        /*if (c.Equals("H"))
        {
            newColor = Color.white;
        }else if (c.Equals("C"))
        {
            newColor = Color.black;
        }else if (c.Equals("N"))
        {
            newColor = Color.blue;
        }
        else // O 
        {
            newColor = Color.red;
        }*/
        //newColor.a = generalOpacity;
        //Debug.Log(opacity);
        newColor.a = opacity;
        atom.GetComponent<MeshRenderer>().material.color = newColor;
    }



	public void ShowBonds(List<Atom> atoms, List<Bond> bonds)
    {
		for (int i = 0; i < bonds.Count; i++) {
            Atom start = ((Atom)atoms[((Bond)bonds[i]).startPos - 1]);
            Atom end = ((Atom)atoms[((Bond)bonds[i]).endPos - 1]);
            float bondOpacity = (start.GetOpacity() + end.GetOpacity()) / 2.0f;
            GameObject newBond= SpawnBond(start.getPosition(), end.getPosition(),bondOpacity);
            ((Bond)bonds[i]).GraphicBond = newBond;

           

            if (start.getType().Equals("H") || end.getType().Equals("H"))
            {
                container.GetComponent<MoleculsGraphicContainer>().InsertHBond(newBond);
            }
            else
            {
                container.GetComponent<MoleculsGraphicContainer>().InsertBond(newBond);
            }
        }
	}

    GameObject SpawnBond(Vector3 startPos, Vector3 endPos,float opacity)
    {
        GameObject newBond = Instantiate(billboardBond) as GameObject;

        //LO DEJO POR LAS DUDAS

        //Vector3 centerPos = new Vector3(startPos.x + endPos.x, startPos.y + endPos.y) / 2;
        //newBond.transform.parent = container.transform;

        /*float scaleX = Mathf.Abs(startPos.x - endPos.x);
        float scaleY = Mathf.Abs(startPos.y - endPos.y);

        centerPos.x -= 0.5f;
        centerPos.y += 0.5f;
        newBond.transform.position = centerPos;
        newBond.transform.localScale = new Vector3(scaleX, scaleY, 1);
        */

        /*Vector3 between = endPos - startPos;
        float distance = between.magnitude;
        newBond.transform.localScale = new Vector3(between.x, between.y, between.z);
        newBond.transform.position = startPos + (between / 2.0f);
        newBond.transform.LookAt(endPos);

        Color c = newBond.GetComponent<MeshRenderer>().material.color;
        c.a = generalAlpha;
        newBond.GetComponent<MeshRenderer>().material.color = c;

        newBond.transform.parent = container.transform;*/


        newBond.transform.position = (endPos + startPos) / 2.0F;

        // Rotation
        Vector3 dirV = Vector3.Normalize(endPos - startPos);

        Vector3 rotAxisV = dirV + new Vector3(0,1,0);

        rotAxisV = Vector3.Normalize(rotAxisV);

        newBond.transform.rotation = new Quaternion(rotAxisV.x, rotAxisV.y, rotAxisV.z, 0);

        // Scale        
        float dist = Vector3.Distance(endPos, startPos);

        newBond.transform.localScale = new Vector3(0.3f, dist / 2, 0.3f);
        /*
        Color c = newBond.GetComponent<MeshRenderer>().material.color;
        if (opacity <= 0.5f) opacity = 0;
        c.a = opacity;
        newBond.GetComponent<MeshRenderer>().material.color = c;
        */
        //newBond.transform.parent = container.transform;
        return newBond;
    }


    public void ToggleBonds()
    {
        container.GetComponent<MoleculsGraphicContainer>().ToggleBonds(bondsToggle.isOn);
    }

    public void ToggleHAtoms()
    {
        container.GetComponent<MoleculsGraphicContainer>().ToggleHAtoms(hToggle.isOn);
    }

    public void ToggleInvertOpacity()
    {
        invertOpacity = invertOpacityToggle.isOn;
        UpdateVisualization();
    }

}
