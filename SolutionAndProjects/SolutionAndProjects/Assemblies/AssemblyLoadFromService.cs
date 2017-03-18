using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Assemblies
{
    public class AssemblyLoadFromService
    {
        private readonly AppDomain _appDomain;
        private readonly IEnumerable<AssemblyFileInfo> _allAssemblies;

        public AssemblyLoadFromService(AppDomain appDomain, IEnumerable<AssemblyFileInfo> allAssemblies)
        {
            if (appDomain == null)
            {
                throw new ArgumentNullException(nameof(appDomain));
            }

            if (allAssemblies == null)
            {
                throw new ArgumentNullException(nameof(allAssemblies));
            }
            _appDomain = appDomain;
            _allAssemblies = allAssemblies;
            _appDomain.AssemblyResolve += AppDomain_AssemblyResolve;
        }

        public void Cleanup()
        {
            _appDomain.AssemblyResolve -= AppDomain_AssemblyResolve;
        }

        public IEnumerable<Type> GetAllTypes(AssemblyFileInfo assemblyFileInfo)
        {
            if (assemblyFileInfo == null)
            {
                throw new ArgumentNullException(nameof(assemblyFileInfo));
            }

            var assembly = Assembly.LoadFrom(assemblyFileInfo.Value.FullName);
            var types = assembly.GetTypes();
            return types;
        }

        public IEnumerable<Type> GetAllTypes(IEnumerable<AssemblyFileInfo> assemblyFileInfos)
        {
            if (assemblyFileInfos == null)
            {
                throw new ArgumentNullException(nameof(assemblyFileInfos));
            }

            var result = assemblyFileInfos.SelectMany(GetAllTypes);
            return result;
        }

        private Assembly AppDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = args.Name.Substring(0, args.Name.IndexOf(",", StringComparison.Ordinal));
            var missingAssembly = _allAssemblies.FirstOrDefault(item => item.Value.Name.StartsWith(assemblyName));
            return missingAssembly != null ? Assembly.LoadFrom(missingAssembly.Value.FullName) : null;
        }
    }
}
