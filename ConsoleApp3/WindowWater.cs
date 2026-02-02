using System.IO;

namespace ConsoleApp3;

using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;


public sealed class WindowWindow : Runnable
{
    public WindowWindow()
    {
        
        var PersonalData = "Inform";

        
        Title = $"Example App ({Application.QuitKey} to quit)";

        var UsernameLabel = new Label { Text = "Username:" };

        var UserNameText = new TextField
        {
            X = Pos.Right(UsernameLabel) + 1,

            Width = Dim.Fill()
        };

        var passwordLabel = new Label
        { 
            Text = "Password:", 
            X = Pos.Left(UsernameLabel), 
            Y = Pos.Bottom(UsernameLabel) + 1 
        };

        var passwordText = new TextField
        {
            Secret = true,

            X = Pos.Left(UserNameText),
            Y = Pos.Top(passwordLabel),
            Width = Dim.Fill()
        };
        

        
        var btnLogin = new Button
        {
            Text = "Login",
            Y = Pos.Bottom(passwordLabel) + 1,
            
            X = Pos.Center(),
            IsDefault = true
        };

        btnLogin.Accepting += (s, e) =>
        {
            foreach (string lines in File.ReadLines(PersonalData))
            {
                var line = lines.Split(' ');
                if (UserNameText.Text.Equals(line[0]) && passwordText.Text.Equals(line[1]))
                {
                    
                    MessageBox.Query(App!, "Logging In", "Login Successful", "Ok");

                    App!.RequestStop();  
                    using (var app = Application.Create().Init())
                    {
                        app.Run<OutputWindow>();
                    }

                    
                }
                else
                {
                    MessageBox.ErrorQuery((s as View)?.App!, "Logging In", "Incorrect username or password", "Ok");
                }
                
                
            }


            e.Handled = true;
        };
        
        Add(UsernameLabel, UserNameText, passwordLabel, passwordText,btnLogin);
    }
}