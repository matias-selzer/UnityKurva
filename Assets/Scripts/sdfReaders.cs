using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class sdfReaders : MonoBehaviour
{

	public string data,bondsData;
	private ArrayList atoms,bonds;
	public GameObject catom,hatom;
	public Line line;
	public Material lineMaterial;

    // Start is called before the first frame update
	/* void Start()
    {
		atoms = new ArrayList ();
		bonds= new ArrayList ();
		interpretData ();
		showAtoms ();
		showBonds ();
    }
		

	public void interpretData(){
		
		RegexOptions options = RegexOptions.None;
		Regex regex = new Regex("[ ]{2,}", options);     
		data = regex.Replace(data, " ");
		//Debug.Log (data);
		string[] info = data.Split (' ');
		for (int i = 0; i < info.Length/16; i++) {
			//Debug.Log (info [i*16 + 1] + " - " + info [i*16 + 2] + " - " + info [i*16 + 3]+ " - "+info [i*16 + 4]);
			Atom m = new Atom (float.Parse(info[i*16+1]),float.Parse(info[i*16+2]),float.Parse(info[i*16+3]), info[i*16+4]);
			atoms.Add (m);
		}
		//Debug.Log (molecules.Count);
		  
		bondsData = regex.Replace(bondsData, " ");
		string[] bondsInfo = bondsData.Split (' ');
		for (int i = 0; i < bondsInfo.Length/4; i++) {
			Debug.Log (bondsInfo [i*4 + 0] + " - " + bondsInfo [i*4 + 1]);
			Bond b = new Bond ();
			b.startPos = int.Parse (bondsInfo [i * 4 + 0]);
			b.endPos = int.Parse (bondsInfo [i * 4 + 1]);
			bonds.Add (b);
		}
	}

	public void showAtoms(){
		for (int i = 0; i < atoms.Count; i++) {
			//Debug.Log (((Molecule)molecules [i]).getType().Equals ("C"));
			if (((Atom)atoms [i]).getType().Equals ("C")) {
				Instantiate (catom, ((Atom)atoms [i]).getPosition (), transform.rotation);
			} else {
				Instantiate (hatom, ((Atom)atoms [i]).getPosition (), transform.rotation);
			}
		}


	}

	public void showBonds(){
		for (int i = 0; i < bonds.Count; i++) {
			Line l = Instantiate (line) as Line;
			//Debug.Log (i);
			//Debug.Log(((Bond)bonds [i]).startPos);
			l.startingPoint = ((Atom)atoms [((Bond)bonds [i]).startPos-1]).getPosition ();
			l.endPoint=((Atom)atoms [((Bond)bonds [i]).endPos-1]).getPosition ();
			l.LineMaterial = lineMaterial;

			l.SetupLine ();
		}
	}*/
}
