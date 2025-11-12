using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.ClassLevel)]
