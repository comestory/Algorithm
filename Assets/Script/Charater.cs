using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charater : MonoBehaviour {

    public enum UserDirection
    {
        East = 0,
        North,
        West,
        South
    }

    public bool isCol = false;

    public UserDirection nowDirection;
    public int directionValue = 90;

	// Use this for initialization
	void Start () {
        nowDirection = UserDirection.East;
	}
	
    public int SetCharacterRotate(bool reftSpin)
    {
        if(reftSpin)
        {
            directionValue -= 90;
        }
        else
        {
            directionValue += 90;
        }

        if (directionValue == 0)
        {
            nowDirection = UserDirection.North;
        }
        else if(directionValue == 90)
        {
            nowDirection = UserDirection.East;
        }
        else if (directionValue == 180)
        {
            nowDirection = UserDirection.South;
        }
        else
        {
            nowDirection = UserDirection.West;
        }
        return directionValue;
    }
}
