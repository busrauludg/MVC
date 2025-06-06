﻿using System.Text.Json;

namespace StoreApp.Infrastructe.Extensions
{
    public static class SessionsExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));
        }
        //biri objeye biri bize bağlı calışoyor
        public static T? GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data is null
                ? default(T)
                :JsonSerializer.Deserialize<T>(data);

        }//anahtar değer verdigimiz veriyi getir  bakıcak seesiondata..
    }
}
