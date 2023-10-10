using System;
using UnityEngine;
using System.Collections.Generic;
using Suburb.Utils.Serialization;
using Object = UnityEngine.Object;

namespace Suburb.Utils
{
    public static class Extensions
    {
        public static bool IsClose(this Vector2 source, float closeDistance)
        {
            return Mathf.Abs(source.x) < closeDistance
                && Mathf.Abs(source.y) < closeDistance;
        }

        public static bool IsClose(this Vector3 source, float closeDistance)
        {
            return Mathf.Abs(source.x) < closeDistance
                && Mathf.Abs(source.y) < closeDistance
                && Mathf.Abs(source.z) < closeDistance;
        }

        public static bool IsCloseWithOther(this Vector2 source, Vector2 destination, float closeDistance)
        {
            return Mathf.Abs(source.x - destination.x) < closeDistance 
                && Mathf.Abs(source.y - destination.y) < closeDistance;
        }

        public static bool IsCloseWithOther(this Vector3 source, Vector3 destination, float closeDistance)
        {
            return Mathf.Abs(source.x - destination.x) < closeDistance
                && Mathf.Abs(source.y - destination.y) < closeDistance
                && Mathf.Abs(source.z - destination.z) < closeDistance;
        }

        public static void Log<T>(this T obj, string message, string filter="")
        {
            Debug.Log($"{filter}[{typeof(T).Name}] {message}");
        }

        public static void LogWarning<T>(this T obj, string message, string filter = "")
        {
            Debug.LogWarning($"{filter}[{typeof(T).Name}] {message}");
        }

        public static void LogError<T>(this T obj, string message, string filter = "")
        {
            Debug.LogError($"{filter}[{typeof(T).Name}] {message}");
        }

        public static Vector3Data ToVector3Data(this Vector3 obj)
        {
            return new Vector3Data { X = obj.x, Y = obj.y, Z = obj.z };
        }

        public static void SetActiveGameObjects<T>(this IEnumerable<T> objects, bool isActive)
            where T : Component
        {
            foreach (T obj in objects)
                obj.gameObject.SetActive(isActive);
        }

        public static void SetActiveGameObjects(this IEnumerable<GameObject> objects, bool isActive)
        {
            foreach (GameObject obj in objects)
                obj.SetActive(isActive);
        }

        public static void DestroyGameObjects<T>(this IEnumerable<T> objects)
            where T : Component
        {
            foreach (T obj in objects)
                Object.Destroy(obj.gameObject);

            if (objects is ICollection<T> collection)
                collection.Clear();
        }

        public static void DestroyGameObjects(this IEnumerable<GameObject> objects)
        {
            foreach (GameObject obj in objects)
                Object.Destroy(obj);

            if (objects is List<GameObject> listObjects)
                listObjects.Clear();
        }

        public static Vector2 ChangeX(this Vector2 source, float x)
        {
            return new Vector2(x, source.y);
        }
        
        public static Vector2 ChangeY(this Vector2 source, float y)
        {
            return new Vector2(source.x, y);
        }
        
        public static void ResetLocal(this Transform source)
        {
            source.localPosition = Vector3.zero;
            source.localScale = Vector3.one;
            source.localRotation = Quaternion.identity;
        }
        
        public static void SetLocal(this Transform source, TransformData transformData)
        {
            source.localPosition = transformData.Position;
            source.localScale = transformData.Scale;
            source.localRotation = Quaternion.Euler(transformData.Rotation);
        }

        public static bool HasAndEqual<TKey, TValue>(
            this Dictionary<TKey, TValue> source, 
            TKey checkKey,
            TValue checkValue)
        where TValue : IEquatable<TValue>
        {
            if (!source.TryGetValue(checkKey, out TValue realValue))
                return false;

            return realValue.Equals(checkValue);
        }

        public static bool HasAndEqual<TKey, TValue>(
            this Dictionary<TKey, object> source,
            TKey checkKey,
            TValue checkValue)
        {
            if (!source.TryGetValue(checkKey, out object realValue))
                return false;

            return realValue is TValue tObject && tObject.Equals(checkValue);
        }
    }
}
