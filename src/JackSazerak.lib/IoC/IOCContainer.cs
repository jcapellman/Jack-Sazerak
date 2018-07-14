using JackSazerak.lib.BaseImplementations;

using Ninject;

namespace JackSazerak.lib.IoC
{
    public static class IOCContainer
    {
        private static IKernel Kernel { get; set; } = new StandardKernel();

        public static BaseGraphicsRenderer GfxRenderer => Kernel.Get<BaseGraphicsRenderer>();

        public static void Initialize(BaseGraphicsRenderer graphicsRenderer)
        {
            Kernel.Bind<BaseGraphicsRenderer>().To(graphicsRenderer.GetType()).InSingletonScope();            
        }
    }
}