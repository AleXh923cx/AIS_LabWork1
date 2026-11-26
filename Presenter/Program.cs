using BusinessLogic;
using View_WinForms;
using View_ConsoleApp;
using Shared;
using Ninject;
using System;
using System.Configuration;

namespace Presenter
{
    class Program
    {
        static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        static IModel model = ninjectKernel.Get<IModel>();

        [STAThread]
        static void Main(string[] args)
        {
            // Читаем настройку из App.config; по умолчанию — консоль.
            string viewType = ConfigurationManager.AppSettings["ViewType"] ?? "console";

            Presenter presenter;

            switch (viewType)
            {
                case "winforms":
                    Form1 form = new Form1();
                    presenter = new Presenter(model, form);
                    break;
                case "console":
                default:
                    ConsoleView consoleView = new ConsoleView();
                    presenter = new Presenter(model, consoleView);
                    break;
            }

            presenter.Start();
        }
    }
}