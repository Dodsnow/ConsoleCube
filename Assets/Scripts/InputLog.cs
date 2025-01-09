using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ConsoleCube/InputCommand")]

    //ScriptableObject class for commands
public class InputLog : ScriptableObject
{
    public int logID;
    public string log;
    public string logDescription;
    
}
