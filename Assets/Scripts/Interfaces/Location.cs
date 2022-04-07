using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Location
{
    string Name
    {
        get;
        set;
    }

    int NumElements
    {
        get;
        set;
    }
    

    public void setElemObjImg(Sprite s);

    public void onTap();
    public void check();
}
