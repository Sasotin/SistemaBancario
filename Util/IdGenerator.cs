namespace SistemaBancario.Util
{
    internal static class IdGenerator
    {
        private static readonly Random _rng = new();
        public static int GenerateId<T>(IEnumerable<T> lists, int minVal = 100_000, int maxVal = 999_999) where T : IEntity
        {
            var used = new HashSet<int>(lists.Select(i => i.Id));

            int id;
            do
            {
                id = _rng.Next(minVal, maxVal);
            }
            while(!used.Add(id));
            return id;
        }
    }
}
