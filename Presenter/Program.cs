using BusinessLogic;
using View_WinForms;
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
            Form1 form = new Form1();
            Presenter presenter = new Presenter(model, form);

            presenter.Start();
        }
    }
}