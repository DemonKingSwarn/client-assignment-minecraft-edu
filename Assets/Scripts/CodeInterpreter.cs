using UnityEngine;
using TMPro;
using System.Diagnostics;
using System.Threading;
using System;
using System.IO;

public class CodeInterpreter : MonoBehaviour
{
    [SerializeField] TMP_InputField codeInputField; // Reference to the input field
    [SerializeField] OutputHandler handler;

    string scriptPath;
    string tmpPath;

    bool pythonScriptFinished = false;

    private void Start()
    {
        GetTmp();
        scriptPath = Path.Combine(tmpPath, "script.py");
    }

    public void ExecutePythonCode()
    {
        string pythonExecutablePath = GetPythonExecutablePath();
        string pythonCode = codeInputField.text;
        pythonCode += "\n\n#success";

        UnityEngine.Debug.Log("Python Executable Path: " + pythonExecutablePath);
        UnityEngine.Debug.Log("Python Code:\n" + pythonCode);

        // Save the Python code to the script.py file
        File.WriteAllText(scriptPath, pythonCode);

        // Run the Python script in a separate thread
        Thread pythonThread = new Thread(() =>
        {
            ProcessStartInfo psi = new ProcessStartInfo(pythonExecutablePath, scriptPath);
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = psi;

            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    string output = e.Data;
                    UnityEngine.Debug.Log("Output: " + output);
                    pythonScriptFinished = true;
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                {
                    string errorOutput = e.Data;
                    UnityEngine.Debug.LogError("Error Output: " + errorOutput);
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            /*
            int exitCode = process.ExitCode;

            // Ensure that you call GreatSuccess on the main thread
            MainThreadDispatcher.Enqueue(() =>
            {
                if (exitCode == 0)
                {
                    handler.GreatSuccess();
                }
            });
            */
        });

        pythonThread.Start();
        ExecutionDone();
    }

    void ExecutionDone()
    {
        handler.GreatSuccess();
    }


    private string GetPythonExecutablePath()
    {
        string pythonExecutablePath = "python"; // Default path for Linux and Mac

        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            pythonExecutablePath = "python.exe"; // Path for Windows
        }

        return pythonExecutablePath;
    }

    void GetTmp()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            tmpPath = "C:\\Users\\AppData\\Local\\Temp\\";
        }
        else if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.LinuxEditor || Application.platform == RuntimePlatform.LinuxPlayer)
        {
            tmpPath = "/tmp/";
        }
    }
}
