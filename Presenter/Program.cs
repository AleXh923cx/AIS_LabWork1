using BusinessLogic;
using Ninject;
using System;

namespace Presenter
{
    class Program
    {
        static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        static void Main(string[] args)
        {
            
        }
    }
}