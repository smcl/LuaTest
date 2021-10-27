using Microsoft.Extensions.Configuration;
using NLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuaTest.Extensions.Configuration
{
    public static class LuaConfigurationExtensions
    {
        public static IConfigurationBuilder AddLuaFile(this IConfigurationBuilder builder, string path)
        {
            var state = new Lua();

            state.RegisterFunction("dotnet_add", null, typeof(LuaConfigurationExtensions).GetMethod("Add"));

            var res = state.DoString(@"
                foo = 10 + 30 * dotnet_add(5, 2)

                return ""sean is cool""
            ");

            throw new Exception($"Need to add lua file {path} to builder");
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
