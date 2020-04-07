using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTouch : MonoBehaviour
{

    public static bool isTouching;

    public void Touch()
    {
        SliderTouch.isTouching = true;
    }

    public void Untouch()
    {
        SliderTouch.isTouching = false;
    }


}
