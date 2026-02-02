using System;
using ConsoleApp3;
using Terminal.Gui.App;
using Terminal.Gui.Configuration;

ConfigurationManager.RuntimeConfig = """{ "Theme": "Amber Phosphor" }""";
ConfigurationManager.Enable(ConfigLocations.All);

using (var app = Application.Create().Init())
{
    app.Run<WindowWindow>();
}
