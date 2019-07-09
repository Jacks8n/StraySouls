using System;

using DS3Enemy = SoulsFormats.MSB3.Part.Enemy;
using SekiroEnemy = SoulsFormats.MSBS.Part.Enemy;

namespace StraySouls.Wrapper
{
    public static class SoulsFormatEntryWrapperHelper
    {
        private const string POSTFIX_CLONE = "_CL";

        public static string GetName<T>(this T entry)
        {
            if (typeof(T) == typeof(DS3Enemy))
                return (entry as DS3Enemy).Name;
            if (typeof(T) == typeof(SekiroEnemy))
                return (entry as SekiroEnemy).Name;

            throw new Exception("rua");
        }

        public static T Clone<T>(this T entry) where T : class
        {
            if (typeof(T) == typeof(DS3Enemy))
            {
                DS3Enemy enemy = entry as DS3Enemy;
                return new DS3Enemy(enemy) { Name = enemy.Name + POSTFIX_CLONE } as T;
            }
            if (typeof(T) == typeof(SekiroEnemy))
            {
                SekiroEnemy enemy = entry as SekiroEnemy;
                return new SekiroEnemy(enemy) { Name = enemy.Name + POSTFIX_CLONE } as T;
            }

            throw new Exception("rua");
        }

        public static TWrapper GetWrapper<TWrapper, TEntry>(this TEntry entry) where TWrapper : ISoulsFormatsEntryWrapper<TWrapper, TEntry>, new()
        {
            TWrapper wrapper = new TWrapper();
            wrapper.AssignEntry(entry);
            return wrapper;
        }
    }
}
