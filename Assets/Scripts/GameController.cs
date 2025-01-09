using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Public variables
    public TextMeshProUGUI displayText;
    public List<InputLog> inputCommands = new();
    
    //Private variables
    List<string> actionLog = new();
    [SerializeField] private GameObject cube;
    [SerializeField] private bool isConsoleActive = false;

    // Function to get users input and display users log
    public void GetUserInput(string inputLog)
    {
        string userInput = inputLog;
        Debug.Log(userInput);
        actionLog.Add(userInput);
        DisplayUserInput();
        CheckInput(userInput);
        // actionLog.Remove(userInput);
    }

    // Function to display users log
    private void DisplayUserInput()
    {
        string displayInputText = string.Join("\n", actionLog.ToArray());
        displayText.text = displayInputText;
    }

    //Function to check user's log for existing command and proceeding them
    private void CheckInput(string input)
    {
        for ( int x = 0; x < inputCommands.Count; x++)
        {
            if (input.Contains(inputCommands[x].log))
            {
                if (input == "/start")
                {
                    string outputText = "Console is Active.";
                    isConsoleActive = true;
                    displayText.color = Color.green;
                    displayText.text = outputText;
                    actionLog.Add(outputText);
                }

                if (isConsoleActive)
                {
                    if (input == "/end")
                    {
                        string outputText = "Console is offline.";
                        isConsoleActive = false;
                        displayText.color = Color.red;
                        displayText.text = "Console is offline.";
                        actionLog.Add(outputText);

                    }

                    if (input.Contains("/rotate"))
                    {
                        int numberOfChar = input.Length;
                        Debug.Log(numberOfChar);
                        if (numberOfChar == 13)
                        {
                            float rotationX = Convert.ToSingle(input.Substring(8, 1));
                            float rotationY = Convert.ToSingle(input.Substring(10, 1));
                            float rotationZ = Convert.ToSingle(input.Substring(12, 1));
                            cube.transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);

                        }

                        if (numberOfChar == 16)
                        {
                            float rotationX = Convert.ToSingle(input.Substring(8, 2));
                            float rotationY = Convert.ToSingle(input.Substring(12, 2));
                            float rotationZ = Convert.ToSingle(input.Substring(14, 2));  
                            cube.transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);

                        }

                        if (numberOfChar == 19)
                        {
                            float rotationX = Convert.ToSingle(input.Substring(8, 3));
                            float rotationY = Convert.ToSingle(input.Substring(13, 3));
                            float rotationZ = Convert.ToSingle(input.Substring(16, 3));  
                            cube.transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
                        }
                        
                    }

                    if (input.Contains("/echo"))
                    {
                        displayText.color = Color.green;
                        displayText.text = input.Remove(0, 5);
                    }

                    if (input.Contains("/moveX"))
                    {
                        Debug.Log(Convert.ToSingle(input.Substring(6)));
                        float positionX = Convert.ToSingle(input.Substring(6));
                        cube.transform.position += new Vector3(positionX, 0, 0);
                    }

                    if (!input.Contains(inputCommands[x].log))
                    {
                        string outputText = "Wrong command.";
                        displayText.color = Color.red;
                        displayText.text = outputText;
                        actionLog.Add(outputText);
                    }
                    
                    
                  
                }

               
            }
            if (!isConsoleActive)
            {
                string outputText = "App is offline.";
                displayText.color = Color.red;
                displayText.text = outputText;
                actionLog.Add(outputText);
            }
           
        }
    }
}