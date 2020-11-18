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
            vm.RegisterCommand('>', b =>
            {
                vm.MemoryPointer++;
                if (vm.MemoryPointer >= vm.Memory.Length)
                    vm.MemoryPointer = 0;
            });
			vm.RegisterCommand('<', b =>
            {
                vm.MemoryPointer--;
                if (vm.MemoryPointer < 0)
                    vm.MemoryPointer = vm.Memory.Length - 1;
                
            });
            vm.RegisterCommand('+', b =>
            {
                if (vm.Memory[vm.MemoryPointer] >= 255)
                    vm.Memory[vm.MemoryPointer] = 0;
                else vm.Memory[vm.MemoryPointer]++;
            });
            vm.RegisterCommand('-', b =>
            {
                if (vm.Memory[vm.MemoryPointer] <= 0)
                    vm.Memory[vm.MemoryPointer] = 255;
                else vm.Memory[vm.MemoryPointer]--;
            });

            vm.RegisterCommand(',', b =>
                vm.Memory[vm.MemoryPointer] = (byte)read());

            vm.RegisterCommand('.', b => write( (char)vm.Memory[vm.MemoryPointer]));

            var constant = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";

            foreach (var letter in constant)
            {
                vm.RegisterCommand(letter, b => vm.Memory[vm.MemoryPointer] = (byte)letter);
            }
        }

    }
}