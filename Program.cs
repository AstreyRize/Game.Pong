using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Pong
{
	class Program
	{
		private static readonly int _deltaTimeMs = 100;

		static void Main(string[] args)
		{
			Console.CursorVisible = false;

			var gameElements = new List<GameElement>();
			var gameField = new GameField(1, 10, 1, Console.WindowWidth / 2);
			var playerOne = new Platform(gameField, 0, 0, symbol: "O");
			var playerTwo = new Platform(gameField, gameField.GetWidth() - 1, 0, symbol: "T");
			var ball = new Ball(gameField, gameField.GetWidth() / 2, gameField.GetHeight() / 2);

			gameElements.Add(playerOne);
			gameElements.Add(playerTwo);
			gameElements.Add(ball);

			Task.Run(() =>
			{
				do
				{
					gameElements.ForEach(element => element.Draw());

					if (ball.DetectDeparture())
					{
						return;
					}

					if (ball.DetectHit(playerOne))
					{
						ball.Bounce();
					}

					if (ball.DetectHit(playerTwo))
					{
						ball.Bounce();
					}

					Thread.Sleep(_deltaTimeMs);
				} while (true);
			});

			do
			{
				var key = Console.ReadKey(true);

				switch (key.Key)
				{
					case ConsoleKey.W:
						playerOne.Y--;
						break;
					case ConsoleKey.S:
						playerOne.Y++;
						break;
					case ConsoleKey.UpArrow:
						playerTwo.Y--;
						break;
					case ConsoleKey.DownArrow:
						playerTwo.Y++;
						break;
					case ConsoleKey.Q:
						Console.WriteLine(key.Key);
						return;
				}
			} while (true);
		}
	}
}
