using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaterInfo
{
    //restart value
    public int life;
    
    //hint value
    int hint;

    //charater 
    GameObject charater;
    
}

public class CharaterManager : MonoBehaviour {

    // Use this for initialization
    void Start() {
        charaterInfo charaterinfo = new charaterInfo();
        charaterinfo.life = 1;
    }
}
