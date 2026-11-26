using BusinessLogic;
using View_WinForms;
using View_ConsoleApp;
using Shared;
using Ninject;
using System;

namespace Presenter
{
    class Program
    {
        static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        static IModel model = ninjectKernel.Get<IModel>();

        [STAThread]
        static void Main(string[] args)
        {
            bool isConsole = true;

            Presenter presenter;
            
            if (isConsole)
            {
                ConsoleView consoleView = new ConsoleView();
                presenter = new Presenter(model, consoleView);
            }
            else
            {
                Form1 form = new Form1();
                presenter = new Presenter(model, form);
            }

            presenter.Start();
        }
    }
}