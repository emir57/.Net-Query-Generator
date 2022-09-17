namespace WriteParameter.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public abstract class WriteParameterPropertyAttribute : WriteParameterBaseAttribute
{
}
