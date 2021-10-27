using NLua;

namespace LuaTest
{
    public class LuaEnvironment
    {
        private Lua _lua;

        public LuaEnvironment()
        {
            _lua = new Lua();
            _lua.RegisterFunction("dotnet_add", null, typeof(LuaEnvironment).GetMethod(nameof(Add)));
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
    }
}
