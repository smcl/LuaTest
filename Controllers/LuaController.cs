using Microsoft.AspNetCore.Mvc;

namespace LuaTest.Controllers
{
    public class LuaController : Controller
    {
        private LuaEnvironment _lua;

        public LuaController(LuaEnvironment lua)
        {
            _lua = lua;
        }

        [HttpPost]
        public string Post(string snippet, string returnVariable)
        {
            return _lua.EvaluateToString(snippet, returnVariable);
        }
    }
}
