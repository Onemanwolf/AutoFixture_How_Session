namespace DemoCode
{
    public interface ITypeJoiner<T>
    {
        T Joined { get; set; }

        bool IsNumeric(object value);
        void Join(dynamic value1, dynamic value2);
    }
}