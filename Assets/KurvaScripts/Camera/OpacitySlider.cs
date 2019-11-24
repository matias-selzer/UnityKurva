using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacitySlider : MonoBehaviour
{
    public MoleculesManager manager;
    
    public void onValueChange()
    {
        manager.changeAlpha(GetComponent<Slider>().value);
    }
}
