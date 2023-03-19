using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugConsole : MonoBehaviour
{
    public KeyCode consoleKey;
    public GameObject console;
    public TMP_InputField inputField;
    public RectTransform historyContainer;
    public GameObject historyTextPrefab;

    List<DebugCommand> _commandList;

    private void Awake()
    {
        console.SetActive(false);

        // stores all the available commands in a list
        _commandList = new List<DebugCommand>
        {
            DebugCommandList.TestCommand,
            DebugCommandList.QuitCommand,
            DebugCommandList.HelpCommand,
            DebugCommandList.StatsCommand,
            DebugCommandList.ClearDeathsRecordsCommand
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(consoleKey))
        {
            console.SetActive(!console.activeSelf);
            if (console.activeSelf)
            {
                Time.timeScale = 0;
                inputField.Select();
            }
            else
                Time.timeScale = 1;
        }

        if (console.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnCommandEnter();
            }
        }
    }

    public void OnCommandEnter()
    {
        var inputText = inputField.text;
        if (inputText == "")
            return;
        HandleInput(inputText);
        
        // clear text
        inputField.text = "";
        // inputField.Select();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void HandleInput(string input)
    {
        bool valid = false;
        string result = "";
        // check if the input contains any valid commands
        for (int i = 0; i < _commandList.Count; i++)
        {
            if (input.Contains(_commandList[i].CommandName))
            {
                result = _commandList[i].Raise(this);
                valid = true;
                XLogger.Log(Category.DebugConsole, result);
                break;
            }
        }

        if (!valid)
        {
            result = $"Command \"{input}\" not found.";
            XLogger.LogWarning(Category.DebugConsole, result);
        }

        var historyCommand = Instantiate(historyTextPrefab, historyContainer);
        var tmpCmd = historyCommand.GetComponent<TextMeshProUGUI>();
        tmpCmd.text = input;
        tmpCmd.color = valid ? Color.green : Color.yellow;
        var history = Instantiate(historyTextPrefab, historyContainer);
        var tmpResult = history.GetComponent<TextMeshProUGUI>();
        tmpResult.text = result;
        tmpResult.color = valid ? Color.white : Color.yellow;
    }
}