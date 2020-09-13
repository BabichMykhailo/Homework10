using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern3
{
    class Program
    {
        static void Main(string[] args)
        {
            Command.F();
        }

        public class Command
        {
            public static void F()
            {
                Pult pult = new Pult();
                Conditioner tv = new Conditioner();
                pult.SetCommand(new ConditionerOnCommand(tv));
                pult.PressButton();
                pult.PressUndo();

                Console.ReadLine();
            }
        }

        interface ICommand
        {
            void Execute();
            void Undo();
        }

        // Receiver - Получатель
        class Conditioner
        {
            public void On()
            {
                Console.WriteLine("Conditioner is on");
            }

            public void Off()
            {
                Console.WriteLine("Conditioner is off");
            }
        }

        class ConditionerOnCommand : ICommand
        {
            Conditioner c;
            public ConditionerOnCommand(Conditioner cSet)
            {
                c = cSet;
            }
            public void Execute()
            {
                c.On();
            }
            public void Undo()
            {
                c.Off();
            }
        }

        // Invoker - инициатор
        class Pult
        {
            ICommand command;

            public Pult() { }

            public void SetCommand(ICommand com)
            {
                command = com;
            }

            public void PressButton()
            {
                command.Execute();
            }
            public void PressUndo()
            {
                command.Undo();
            }
        }
    }
}
