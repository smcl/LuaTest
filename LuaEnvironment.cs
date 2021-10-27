using NLua;
using System;

namespace LuaTest
{
    public class LuaEnvironment
    {
        private Lua _lua;
        private int _mysteryNumber;

        public LuaEnvironment()
        {
            _lua = new Lua();
            _lua.RegisterFunction("dotnet_add", null, typeof(LuaEnvironment).GetMethod(nameof(Add)));
            _lua.RegisterFunction("dotnet_get_mystery_number", this, typeof(LuaEnvironment).GetMethod(nameof(Mystery)));

            _mysteryNumber = new Random().Next();
        }


        public string EvaluateToString(string snippet, string returnValue)
        {
            var result = _lua.DoString(snippet);

            if (!string.IsNullOrEmpty(returnValue))
            {
                return _lua[returnValue].ToString();
            }

            if (result != null)
            {
                return string.Join("\r\n", result);
            }

            return string.Empty;
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public int Mystery()
        {
            return _mysteryNumber;
        }
    }
}
