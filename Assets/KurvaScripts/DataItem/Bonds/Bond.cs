using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bond:DataItem
{
    private Atom originAtom, destAtom;
    
    public Bond(Atom init,Atom end)
    {
        originAtom = init;
        destAtom = end;
    }
}
