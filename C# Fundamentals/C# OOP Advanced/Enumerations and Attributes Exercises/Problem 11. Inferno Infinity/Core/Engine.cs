﻿using System;
using Problem_11.Inferno_Infinity.Interfaces;

namespace Problem_11.Inferno_Infinity.Core
{
    public class Engine : IEngine
    {
        private CommandDispatcher dispatcher;
        private InputHandler inHandler;

        public Engine()
        {
            this.dispatcher = new CommandDispatcher();
            this.inHandler = new InputHandler();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = inHandler.SplitInput(input, ";");
                dispatcher.ExecuteCommand(tokens);
            }
        }
    }
}
