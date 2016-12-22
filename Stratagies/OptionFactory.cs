using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithDictionaries2.Stratagies
{
    public class OptionFactory : IOptionFactory
    {
        private readonly Dictionary<Tuple<string, string>, Func<IOptionStragey>> optionStrategyMatrix;

        public OptionFactory()
        {
            optionStrategyMatrix = new Dictionary<Tuple<string, string>, Func<IOptionStragey>>()
            {
                { new Tuple<string, string>("1", "A"), () => new Option1AStrategy() },
                { new Tuple<string, string>("1", "B"), () => new Option1BStrategy() },
                { new Tuple<string, string>("1", "C"), () => new Option1CStrategy() },
                { new Tuple<string, string>("2", "A"), () => new Option2AStrategy() },
                { new Tuple<string, string>("2", "B"), () => new Option2BStrategy() },
                { new Tuple<string, string>("2", "C"), () => new Option2CStrategy() },
            };
        }

        public IOptionStragey CreateFromIfs(string someValue1, string someValue2)
        {
            if (someValue1 == "1" && someValue2 == "A")
            {
                return new Option1AStrategy();
            }
            else if (someValue1 == "1" && someValue2 == "B")
            {
                return new Option1BStrategy();
            }
            else if (someValue1 == "1" && someValue2 == "C")
            {
                return new Option1CStrategy();
            }
            else if (someValue1 == "2" && someValue2 == "A")
            {
                return new Option2AStrategy();
            }
            else if (someValue1 == "2" && someValue2 == "B")
            {
                return new Option2BStrategy();
            }
            else if (someValue1 == "2" && someValue2 == "C")
            {
                return new Option2CStrategy();
            }

            return new NoOpOptionStrategy();
        }

        public IOptionStragey CreateFromSwitch(string someValue1, string someValue2)
        {
            switch ($"{someValue1},{someValue2}")
            {
                case "1,A":
                    return new Option1AStrategy();
                case "1,B":
                    return new Option1BStrategy();
                case "1,C":
                    return new Option1CStrategy();
                case "2,A":
                    return new Option2AStrategy();
                case "2,B":
                    return new Option2BStrategy();
                case "2,C":
                    return new Option2CStrategy();
                default:
                    return new NoOpOptionStrategy();
            }
        }

        public IOptionStragey CreateFromDictionary(string someValue1, string someValue2)
        {
            var key = new Tuple<string, string>(someValue1, someValue2);

            if (this.optionStrategyMatrix.ContainsKey(key))
            {
                return this.optionStrategyMatrix[key].Invoke();
            }

            return new NoOpOptionStrategy();
        }
    }
}
