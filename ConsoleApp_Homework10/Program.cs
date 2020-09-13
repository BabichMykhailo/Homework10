using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Homework10
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            hero.Move(); // делаем выстрел, осталось 9 патронов
            GameHistory game = new GameHistory();

            game.History.Push(hero.SaveState()); // сохраняем игру

            hero.Move(); //делаем выстрел, осталось 8 патронов

            hero.RestoreState(game.History.Pop());

            hero.Move(); //делаем выстрел, осталось 8 патронов

            Console.Read();
        }
    }

    // Originator
    class Hero
    {
        private int steps = 10; 
        private int lives = 5; 

        public void Move()
        {
            if (steps > 0)
            {
                steps--;
                Console.WriteLine("Делаем ход. Осталось {0} ходов", steps);
            }
            else
                Console.WriteLine("Патронов больше нет");
        }
        // сохранение состояния
        public HeroMemento SaveState()
        {
            Console.WriteLine("Сохранение игры. Параметры: {0} ходов, {1} жизней", steps, lives);
            return new HeroMemento(steps, lives);
        }

        // восстановление состояния
        public void RestoreState(HeroMemento memento)
        {
            this.steps = memento.Steps;
            this.lives = memento.Lives;
            Console.WriteLine("Восстановление игры. Параметры: {0} ходов, {1} жизней", steps, lives);
        }
    }
    // Memento
    class HeroMemento
    {
        public int Steps { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int patrons, int lives)
        {
            this.Steps = patrons;
            this.Lives = lives;
        }
    }

    // Caretaker
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }

}

