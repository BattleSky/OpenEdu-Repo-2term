using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
		public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
            vm.RegisterCommand('>', b => { vm.MemoryPointer++; });
			vm.RegisterCommand('<', b => { vm.MemoryPointer--;});
            vm.RegisterCommand('+', b => { vm.Memory[vm.MemoryPointer]++;});
            vm.RegisterCommand('-', b => { vm.Memory[vm.MemoryPointer]--; });
			vm.RegisterCommand('.', b => { read = () => vm.Memory[vm.MemoryPointer]; } );
            //vm.RegisterCommand(',', b => {write(vm.)});
        }

    }
}