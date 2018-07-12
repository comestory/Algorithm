using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterInfo
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
        CharaterInfo charaterinfo = new CharaterInfo();
        charaterinfo.life = 1;
    }
}
