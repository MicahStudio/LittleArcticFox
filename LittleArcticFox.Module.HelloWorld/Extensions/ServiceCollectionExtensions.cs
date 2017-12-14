using LittleArcticFox.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleArcticFox.Module.HelloWorld.Extensions
{
    public static class ModuleExtensions
    {
        public static void HelloWorld(this ModuleOptions moduleOptions)
        {
            Console.WriteLine("Hello World LLittle Arctic Fox");
        }
    }
}
