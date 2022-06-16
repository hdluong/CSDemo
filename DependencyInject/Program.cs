using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace DependencyInject
{
    /// <summary>
    /// 
    /// </summary>
    interface IClassB
    {
        public void ActionB();
    }

    /// <summary>
    /// 
    /// </summary>
    interface IClassC
    {
        public void AcitonC();
    }

    /// <summary>
    /// 
    /// </summary>
    class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC is created!");

        public void AcitonC() => Console.WriteLine("Action in ClassC");
    }

    /// <summary>
    /// 
    /// </summary>
    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created!");

        public void AcitonC() => Console.WriteLine("Action in ClassC1");
    }

    /// <summary>
    /// 
    /// </summary>
    class ClassB : IClassB
    {
        IClassC c_dependency;

        public ClassB(IClassC classC)
        {
            c_dependency = classC;
            Console.WriteLine("ClassB is created!");
        }

        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.AcitonC();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class ClassB1 : IClassB
    {
        IClassC c_dependency;

        public ClassB1(IClassC classC)
        {
            c_dependency = classC;
            Console.WriteLine("ClassB1 is created!");
        }

        public void ActionB()
        {
            Console.WriteLine("Action in ClassB1");
            c_dependency.AcitonC();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;

        public ClassB2(IClassC classC, string msg)
        {
            c_dependency = classC;
            message = msg;
            Console.WriteLine("ClassB2 is created!");
        }

        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.AcitonC();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class ClassA
    {
        IClassB b_dependency;

        public ClassA(IClassB classB)
        {
            b_dependency = classB;
            Console.WriteLine("ClassA is created!");
        }

        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }

    #region Use Options
    /// <summary>
    /// 
    /// </summary>
    class MyServiceOptions
    {
        public string data1 { get; set; }

        public int data2 { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    class MyService
    {
        public string data1 { get; set; }

        public int data2 { get; set; }

        public MyService(IOptions<MyServiceOptions> options)
        {
            var _options = options.Value;
            data1 = _options.data1;
            data2 = _options.data2;
        }

        public void PrintData() => Console.WriteLine($"{data1} / {data2}");
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    class Program
    {
#if false
        public static ClassB2 ClassB2Factory(IServiceProvider provider)
        {
            var classC = provider.GetService<IClassC>();
            var classB2 = new ClassB2(classC, "Thuc hien tu ClassB2");
            return classB2;
        }

        static void Main(string[] args)
        {
            // DI Container: ServiceCollection
            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<ClassA>();

            //services.AddSingleton<IClassB, ClassB2>(
            //    (IServiceProvider provider) =>
            //    {
            //        var service_c = provider.GetService<IClassC>();
            //        var classB2 = new ClassB2(service_c, "Message from ClassB2");
            //        return classB2;
            //    }
            //);
            services.AddSingleton<IClassB, ClassB2>(ClassB2Factory);

            //services.AddSingleton<IClassB, ClassB1>();
            services.AddSingleton<IClassC, ClassC1>();

            // Create ServiceProvider
            var serviceProvider = services.BuildServiceProvider();

            // Get Service
            var classA = serviceProvider.GetService<ClassA>();

            //
            classA.ActionA();
        }
#endif

        static void Main(string[] args)
        {
            // DI Container: ServiceCollection
            var services = new ServiceCollection();

            // Register Services
            services.AddSingleton<MyService>();
            services.Configure<MyServiceOptions>((options) =>
            {
                options.data1 = "Hello";
                options.data2 = 2022;
            });

            // Create Provider
            var provider = services.BuildServiceProvider();

            // Get Services
            var myService = provider.GetService<MyService>();
            myService.PrintData();
        }
    }
}
