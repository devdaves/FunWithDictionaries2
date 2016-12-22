namespace FunWithDictionaries2.Stratagies
{
    public interface IOptionFactory
    {
        IOptionStragey CreateFromIfs(string someValue1, string someValue2);

        IOptionStragey CreateFromSwitch(string someValue1, string someValue2);

        IOptionStragey CreateFromDictionary(string someValue1, string someValue2);
    }
}