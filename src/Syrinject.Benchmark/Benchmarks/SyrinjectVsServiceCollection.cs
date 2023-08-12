using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Syrinject.Benchmark.Services;
using Syrinject.Core;
using Syrinject.Core.Abstractions;

namespace Syrinject.Benchmark.Benchmarks;

[MemoryDiagnoser(displayGenColumns: false)]
public class SyrinjectVsServiceCollection
{
    private ISyrinjectContainer _syrinjectContainer;
    private IServiceCollection _serviceCollection;

    [GlobalSetup]
    public void Setup()
    {
        _serviceCollection = new ServiceCollection();
        _serviceCollection.AddTransient<IResultProcessor, ResultProcessor>();
        _serviceCollection.AddTransient<ICalculatorService, CalculatorService>();

        _syrinjectContainer = new SyrinjectContainer();
        _syrinjectContainer.AddTransient<IResultProcessor, ResultProcessor>();
        _syrinjectContainer.AddTransient<ICalculatorService, CalculatorService>();
    }

    [Benchmark]
    public void ServiceCollection_Resolve()
    {
        IServiceProvider provider = _serviceCollection.BuildServiceProvider();

        ICalculatorService? calculator = provider.GetService<ICalculatorService>();

        calculator!.AddAndProcess(1, 2);
    }

    [Benchmark]
    public void SyrinjectContainer_Resolve()
    {
        ISyrinjectResolver resolver = _syrinjectContainer.Build();

        ICalculatorService calculator = resolver.Resolve<ICalculatorService>();

        calculator.AddAndProcess(1, 2);
    }
}
