namespace Syrinject.Benchmark.Services;

public interface ICalculatorService
{
    void AddAndProcess(int a, int b);
}

public sealed class CalculatorService : ICalculatorService
{
    private readonly IResultProcessor _processor;

    public CalculatorService(IResultProcessor processor)
    {
        _processor = processor;
    }

    public void AddAndProcess(int a, int b)
    {
        int result = a + b;

        _processor.PrintResult(result);
    }
}
