using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveBase Base { get; set; } // Create a reference to MoveBase.cs in this folder
    public int PP { get; set; }

    public Move(MoveBase pBase) {
        Base = pBase;
        PP = pBase.PP;
    }
}
