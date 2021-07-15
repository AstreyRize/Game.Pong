using System;

namespace Game.Pong
{
	internal class Platform : GameElement
	{
		private readonly IGameField _gameField;

		private readonly int[] _oldPosition = new int[3];

		private int _x;

		private int _y;

		public Platform(IGameField gameField, int x, int y, uint size = 3, string symbol = "P")
		{
			_gameField = gameField;
			X = gameField.GetStartXPosition() + x;
			Y = gameField.GetStartYPosition() + y;
			Symbol = symbol;
			Size = size;
		}

		public sealed override int X
		{
			get => _x;
			set
			{
				if (value <= _gameField.GetStartXPosition())
				{
					_x = _gameField.GetStartXPosition();
				}
				else if (value >= _gameField.GetStartXPosition() + _gameField.GetWidth())
				{
					_x = _gameField.GetStartXPosition() + _gameField.GetWidth();
				}
				else
				{
					_x = value;
				}
			}
		}

		public sealed override int Y
		{
			get => _y;
			set
			{
				if (value <= _gameField.GetStartYPosition())
				{
					_y = _gameField.GetStartYPosition();
				}
				else if (value >= _gameField.GetStartYPosition() + _gameField.GetHeight())
				{
					_y = _gameField.GetStartYPosition() + _gameField.GetHeight();
				}
				else
				{
					_y = value;
				}
			}
		}

		public override void Draw()
		{
			foreach (var item in _oldPosition)
			{
				Console.SetCursorPosition(X, item);
				Console.WriteLine(" ");
			}

			for (var i = 0; i < Size; i++)
			{
				var newYPosition = Y + i;

				_oldPosition[i] = newYPosition;
				Console.SetCursorPosition(X, newYPosition);
				Console.WriteLine(Symbol);
			}
		}
	}
}
