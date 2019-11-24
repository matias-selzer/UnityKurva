using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proxy : MonoBehaviour
{
    public string data;

    private float alpha = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
		                WebGLInput.captureAllKeyboardInput = false;
        #endif
        loadMoleculesFromSDF(data);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            alpha += 0.05f;
            GetComponent<MoleculesManager>().changeAlpha(alpha);
            Debug.Log("aprete arriba");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            alpha -= 0.05f;
            GetComponent<MoleculesManager>().changeAlpha(alpha);
            Debug.Log("aprete abajo");
        }
    }

    public void loadMoleculesFromSDF(string data)
    {
        List<Molecule> molecules = new SDFMoleculesCreator().createMolecules(new SDFdata(data));
        GetComponent<MoleculesManager>().setMolecules(molecules);
        GetComponent<MoleculesManager>().renderMolecules();
        GetComponent<MoleculesManager>().changeAlpha(alpha);
    }

    
}
