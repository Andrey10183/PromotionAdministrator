using System.Reflection;

namespace Comandante.Infrastructure;

public class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
