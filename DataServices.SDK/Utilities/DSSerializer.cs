// <copyright file="Serializer.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.SDK.Utilities
{
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Formatting;

    /// <summary>
    /// Helper methods to serialize \ deserialize objects using a supplied formatter.
    /// </summary>
    public static class DSSerializer
    {
        /// <summary>
        /// Deserialize the supplied string into an object using the specified formatter.
        /// </summary>
        /// <typeparam name="T">The expected object type.</typeparam>
        /// <param name="formatter">The formatter to use.</param>
        /// <param name="str">The string representation of the object to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T Deserialize<T>(MediaTypeFormatter formatter, string str) where T : class
        {
            // Write the serialized string to a memory stream.
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;

            // Deserialize to an object of type T
            return formatter.ReadFromStreamAsync(typeof(T), stream, null, null).Result as T;
        }

        /// <summary>
        /// Serialize the supplied object into a string using the specified formatter.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="formatter">The formatter to use.</param>
        /// <param name="value">The object to serialize.</param>
        /// <returns>The string representation of the object.</returns>
        public static string Serialize<T>(MediaTypeFormatter formatter, T value)
        {
            // Create a dummy HTTP Content.
            var stream = new MemoryStream();
            var content = new StreamContent(stream);

            // Serialize the object.
            formatter.WriteToStreamAsync(typeof(T), value, stream, content, null).Wait();

            // Read the serialized string.
            stream.Position = 0;
            return content.ReadAsStringAsync().Result;
        }
    }
}
