using System.Collections.Generic;
using System.IO;

namespace ConsoleApp3;
using Terminal.Gui.App;
using Terminal.Gui.Views;



public class OutputWindow: Runnable
{
    private string path = "Info";

    List<string> info = new List<string>();
    public OutputWindow()
    {
        Title = $"Example App ({Application.QuitKey} to quit)";
        
        foreach(string lins in File.ReadLines(path))
        {
            info.Add(lins);
        }        

        var label = new Label()
        {
 
            Text = $"{string.Join("\n", info)}"
        };
        
        Add(label);
    }
}