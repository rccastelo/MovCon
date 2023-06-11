using System;

namespace MovConDomain.Enums
{
    public static class ConteinerTipoEnum
    {
        private enum Items
        {
            Vinte = 20,
            Quarenta = 40
        }

        public static bool Validate(string item)
        {
            if (!Enum.TryParse(item, true, out Items _item))
                return false;

            if (!Enum.IsDefined(typeof(Items), _item))
                return false;

            return true;
        }
    }
}
