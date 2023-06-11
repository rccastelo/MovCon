using System;

namespace MovConDomain.Enums
{
    public static class ConteinerStatusEnum
    {
        private enum Items
        {
            Cheio,
            Vazio
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
