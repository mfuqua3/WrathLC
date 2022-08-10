namespace WrathLc.Common.Utilities.DataContracts;

public interface IUnique<T> where T:IEquatable<T>
{
    T Id { get; set; }
}