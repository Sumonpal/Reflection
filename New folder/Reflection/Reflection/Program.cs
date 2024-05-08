using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"F:\file\.Net Code\Reflection\Reflection\config.txt";
            var configText = File.ReadAllText(path);

            var initClassName = configText.Split('=')[1].Trim();

            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types) 
            { 
                if(type.Name == initClassName)
                {
                    var constructor = type.GetConstructor(new Type[0]);
                    var initializerInstance = constructor.Invoke(new object[0]);

                    MethodInfo method = type.GetMethod("InitStartup");
                    method.Invoke(initializerInstance, new object[0]);
                }
            }
        }
    }
}