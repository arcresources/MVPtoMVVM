using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;
using StructureMap;

namespace MVPtoMVVM.mvp
{
    public class Bootstrap
    {
        public void Execute()
        {
            ObjectFactory.Initialize(x => 
                x.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(TodoItem));
                    scanner.AssemblyContainingType(typeof(TodoItemPresenter));
                    scanner.WithDefaultConventions();
                })
            );

        }
    }
}