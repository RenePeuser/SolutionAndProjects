using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Extensions;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Assemblies
{
    public class AssemblyLoadFromService
    {
        private readonly AppDomain _appDomain;
        private readonly IEnumerable<AssemblyFileInfo> _allAssemblies;

        public AssemblyLoadFromService(AppDomain appDomain, IEnumerable<AssemblyFileInfo> allAssemblies)
        {
            Contract.Requires(appDomain.IsNotNull());
            Contract.Requires(allAssemblies.IsNotNull());

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
            Contract.Requires(assemblyFileInfo.IsNotNull());

            var assembly = Assembly.LoadFrom(assemblyFileInfo.Value.FullName);
            var types = assembly.GetTypes();
            return types;
        }

        public IEnumerable<Type> GetAllTypes(IEnumerable<AssemblyFileInfo> assemblyFileInfos)
        {
            Contract.Requires(assemblyFileInfos.IsNotNull());

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
