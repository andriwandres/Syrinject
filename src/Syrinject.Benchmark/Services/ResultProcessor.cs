namespace Syrinject.Benchmark.Services;

public interface IResultProcessor
{
    void PrintResult(int result);
}

public sealed class ResultProcessor : IResultProcessor
{
    public void PrintResult(int result)
    {
        
    }
}
