using BusinessLogic;
using Shared;
using Ninject;
using System;

namespace Presenter
{
    class Program
    {
        static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        static IModel model = ninjectKernel.Get<IModel>();

        static void Main(string[] args)
        {
            Presenter presenter = new Presenter(model);

            presenter.Start();
        }
    }
}