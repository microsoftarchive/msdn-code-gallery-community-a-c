using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using BTL.Infrastructure;

namespace BTL.DataAccess
{
    public class DataContextFactory : Disposable
    {
        private static readonly Type EntityType = typeof(EntityTypeConfiguration<>);

        private static readonly Type ComplexType = typeof(ComplexTypeConfiguration<>);

        private static readonly ConcurrentDictionary<string, IDictionary<MethodInfo, object>>

        MappingConfigurations = new ConcurrentDictionary<string, IDictionary<MethodInfo, object>>();

        private readonly string _nameOrConnectionString;

        private static Type _dataContextType = typeof(DataContext);

        private DataContext _context;

        public DataContextFactory(string nameOrConnectionString)
        {
            //Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(nameOrConnectionString));

            _nameOrConnectionString = nameOrConnectionString;
        }

        public static Type DataContextType
        {
            get
            {
                return _dataContextType;
            }

            set
            {
                //Contract.Requires<ArgumentNullException>(value != null);
                //Contract.Requires<ArgumentException>(typeof(DataContext).IsAssignableFrom(value));

                _dataContextType = value;
            }
        }

        public virtual DataContext GetContext()
        {
            return _context ?? (_context = CreateContext());
        }

        protected override void DisposeCore()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        private static IDictionary<MethodInfo, object> BuildConfigurations()
        {
            var addMethods = typeof(ConfigurationRegistrar).GetMethods()
                .Where(m => m.Name.Equals("Add"))
                .ToList();

            var entityTypeMethod = addMethods.First(m =>
                m.GetParameters()
                 .First()
                 .ParameterType
                 .GetGenericTypeDefinition()
                 .IsAssignableFrom(EntityType));

            var complexTypeMethod = addMethods.First(m =>
                m.GetParameters().First()
                 .ParameterType
                 .GetGenericTypeDefinition()
                 .IsAssignableFrom(ComplexType));

            var configurations = new Dictionary<MethodInfo, object>();

            var types = typeof(DataContextFactory).Assembly
                .GetExportedTypes()
                .Where(IsMappingType)
                .ToList();

            foreach (var type in types)
            {
                MethodInfo typedMethod;
                Type modelType;

                if (IsMatching(
                    type, out modelType, t => EntityType.IsAssignableFrom(t)))
                {
                    typedMethod = entityTypeMethod.MakeGenericMethod(
                        modelType);
                }
                else if (IsMatching(
                    type, out modelType, t => ComplexType.IsAssignableFrom(t)))
                {
                    typedMethod = complexTypeMethod.MakeGenericMethod(
                        modelType);
                }
                else
                {
                    continue;
                }

                configurations.Add(
                    typedMethod, Activator.CreateInstance(type));
            }

            return configurations;
        }

        private static bool IsMappingType(Type matchingType)
        {
            if (!matchingType.IsClass ||
                matchingType.IsAbstract)
            {
                return false;
            }

            Type temp;

            return IsMatching(
                matchingType,
                out temp,
                t => EntityType.IsAssignableFrom(t) || ComplexType.IsAssignableFrom(t));
        }

        private static bool IsMatching(
            Type matchingType,
            out Type modelType,
            Predicate<Type> matcher)
        {
            modelType = null;

            while (matchingType != null)
            {
                if (matchingType.IsGenericType)
                {
                    var definationType = matchingType
                        .GetGenericTypeDefinition();

                    if (matcher(definationType))
                    {
                        modelType = matchingType.GetGenericArguments().First();
                        return true;
                    }
                }

                matchingType = matchingType.BaseType;
            }

            return false;
        }

        private DataContext CreateContext()
        {
            var configurtions = MappingConfigurations.GetOrAdd(
                _nameOrConnectionString,
                key => BuildConfigurations());

            var localContext = (DataContext)Activator.CreateInstance(
                DataContextType,
                new object[] { _nameOrConnectionString, configurtions });

            return localContext;
        }
    }
}