using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

           /* if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Player")
                {
                    Debug.Log("This is a Player");
                }
                else
                {
                    Debug.Log(hit.transform.name);
                }
            }*/

            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);

            for (int i = 0; i < hits.Length; i++)
            {
                hit = hits[i];
                Renderer rend = hit.transform.GetComponent<Renderer>();
                Debug.Log(hit.transform.name);

                if (rend)
                {
                    // Change the material of all hit colliders
                    // to use a transparent shader.
                    rend.material.shader = Shader.Find("Outlined/UltimateOutline");
                   // Color tempColor = rend.material.color;
                   // tempColor.a = 0.3F;
                    //rend.material.color = Color.red;
                }
            }
        }
       
    }
}
