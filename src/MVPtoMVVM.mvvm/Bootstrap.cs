using MVPtoMVVM.domain;
using StructureMap;

namespace MVPtoMVVM.mvvm
{
    public class Bootstrap
    {
        public void Execute()
        {
            ObjectFactory.Initialize(x => 
                x.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(TodoItem));
                    scanner.WithDefaultConventions();
                })
            );

        }
    }
}