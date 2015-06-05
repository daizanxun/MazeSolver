namespace MazeProject.Algrithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class AlgrithmFactory
    {
        private static IEnumerable<Type> _algrithmsTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IImageMazeAlgrithm)));

        public static T CreateObject<T> ()
        {
            var objectType =_algrithmsTypes.FirstOrDefault(t => typeof (T).IsAssignableFrom(t) && t.IsSealed);
            if (objectType == null)
                throw new ApplicationException("Algrithm Type Cannot Be Found!");

            var constructor = objectType.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, Type.EmptyTypes, null);

            return (T)constructor.Invoke(null);
        }
    }
}
