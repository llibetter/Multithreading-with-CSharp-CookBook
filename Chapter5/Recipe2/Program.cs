using System;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace Chapter5.Recipe2
{
	class Program
	{
		static  void Main(string[] args)
		{
            WriteLine("主线程1");
            Task t = AsynchronousProcessing();
            WriteLine("主线程2");
			t.Wait();
		}

		static async Task AsynchronousProcessing()
		{
			Func<string, Task<string>> asyncLambda = async name => {
				await Task.Delay(TimeSpan.FromSeconds(2));
                WriteLine("主线程5");

                return
                    $"Task {name} is running on a thread id {CurrentThread.ManagedThreadId}." +
				    $" Is thread pool thread: {CurrentThread.IsThreadPoolThread}";
			};
            WriteLine("主线程3");
            string result = await asyncLambda("async lambda");
            WriteLine("主线程4");
            WriteLine(result);
		}
	}
}
