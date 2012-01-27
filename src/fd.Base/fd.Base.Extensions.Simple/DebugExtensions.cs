using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace fd.Base.Extensions.Simple
{
    /// <summary>Extension methods to simplify debugging.</summary>
    public static class DebugExtensions
    {
        private static MethodInfo _writeDepthMethod;
        private static ConstructorInfo _xhtmlWriterConstructor;

        /// <summary>Writes an object's properties to HTML and displays them in default browser.</summary>
        /// <remarks>
        /// <para>Tries to find LINQPad.exe in %ProgramFiles%\LINQPad4. Use Dump{T}(T,string) to specify the full path yourself.</para>
        /// <para>Uses a max depth of 10.</para>
        /// </remarks>
        /// <typeparam name="T">The type of the object to dump.</typeparam>
        /// <param name="obj">The instance to dump.</param>
        public static void Dump<T>(this T obj)
        {
            Dump(obj, 10);
        }

        /// <summary>Writes an object's properties to HTML and displays them in default browser.</summary>
        /// <remarks>Tries to find LINQPad.exe in %ProgramFiles%\LINQPad4. Use Dump{T}(T,string) to specify the full path yourself.</remarks>
        /// <typeparam name="T">The type of the object to dump.</typeparam>
        /// <param name="obj">The instance to dump.</param>
        /// <param name="maxDepth">The max depth of the graph.</param>
        public static void Dump<T>(this T obj, int maxDepth)
        {
            Dump(obj, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"LINQPad4", @"LINQPad.exe"), maxDepth);
        }

        /// <summary>Writes an object's properties to HTML and displays them in default browser.</summary>
        /// <remarks>Uses a max depth of 10.</remarks>
        /// <typeparam name="T">The type of the object to dump.</typeparam>
        /// <param name="obj">The instance to dump.</param>
        /// <param name="pathToLinqPadAssembly">The path to the linq pad assembly.</param>
        public static void Dump<T>(this T obj, string pathToLinqPadAssembly)
        {
            Dump(obj, pathToLinqPadAssembly, 10);
        }

        /// <summary>Writes an object's properties to HTML and displays them in default browser.</summary>
        /// <typeparam name="T">The type of the object to dump.</typeparam>
        /// <param name="obj">The instance to dump.</param>
        /// <param name="pathToLinqPadAssembly">The path to the linq pad assembly.</param>
        /// <param name="maxDepth">The max depth of the graph.</param>
        public static void Dump<T>(this T obj, string pathToLinqPadAssembly, int maxDepth)
        {
            var localUrl = Path.GetTempFileName() + @".html";
            try
            {
                if (_xhtmlWriterConstructor == null)
                {
                    var linqPadAssembly = Assembly.LoadFile(pathToLinqPadAssembly);
                    var type = linqPadAssembly.GetType(@"LINQPad.ObjectGraph.Formatters.XhtmlWriter");
                    _xhtmlWriterConstructor = type.GetConstructor(new[] { typeof(bool), typeof(bool) });
                    _writeDepthMethod = type.GetMethod("WriteDepth", new[] { typeof(object), typeof(int?) });

                    // ..GetMethod(
                    // @"CreateXhtmlWriter", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(bool) }, new ParameterModifier[] { });
                }

                using (dynamic writer = _xhtmlWriterConstructor.Invoke(new object[] { true, true }))
                {
                    _writeDepthMethod.Invoke(writer, new object[] { obj, maxDepth });
                    File.WriteAllText(localUrl, writer.ToString());
                }
            }
            catch (Exception e)
            {
                File.WriteAllText(localUrl, "Couldn't use LINQPad's Dump method..." + Environment.NewLine + e);
            }

            Process.Start(localUrl);
        }
    }
}
