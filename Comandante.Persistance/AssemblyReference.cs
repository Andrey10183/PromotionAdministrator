using System.Reflection;

namespace Comandante.Persistance;
public class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
