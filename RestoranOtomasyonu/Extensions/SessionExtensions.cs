using Newtonsoft.Json;

namespace RestoranOtomasyonu.Extensions
{
    public static class SessionExtensions
    {
        // Sessiona obje atamak için kullanılacak extension metot
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Sessiondan obje çekmek için kullanılacak extension metot
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
