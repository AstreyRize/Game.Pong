using System;

namespace Game.Pong
{
	internal class Ball : GameElement, IBall
	{
		private readonly IGameField _gameField;

		private int _x;

		private int _y;

		private int _impulsX;

		private int _impulsY;

		private int _oldX;

		private int _oldY;

		public Ball(IGameField gameField, int x, int y, string symbol = "B")
		{
			_gameField = gameField;
			_impulsX = 1;
			_impulsY = 1;

			_x = x;
			_oldX = x;
			_y = y;
			_oldY = y;

			Symbol = symbol;
		}

		public override int X
		{
			get => _x;
			set => _x += (_x - value) * _impulsX;
		}

		public override int Y
		{
			get => _y;
			set
			{
				if (value <= _gameField.GetStartYPosition())
				{
					_impulsY = -_impulsY;
				}
				else if (value >= _gameField.GetStartYPosition() + _gameField.GetHeight())
				{
					_impulsY = -_impulsY;
				}

				_y += (_y - value) * _impulsY;
			}
		}

		/// <inheritdoc />
		public override void Draw()
		{
			X++;
			Y++;

			Console.SetCursorPosition(_oldX, _oldY);
			Console.WriteLine(" ");

			Console.SetCursorPosition(X, Y);
			Console.WriteLine(Symbol);

			_oldX = X;
			_oldY = Y;
		}

		/// <inheritdoc cref="IBall" />
		public bool DetectHit(GameElement gameElement)
		{
			for (var i = 0; i < gameElement.Size; i++)
			{
				if (_x == gameElement.X && _y == gameElement.Y + i)
				{
					return true;
				}
			}

			return false;
		}

		/// <inheritdoc />
		public bool DetectDeparture()
		{
			return _x < _gameField.GetStartXPosition() ||
				   _x == _gameField.GetStartXPosition() + _gameField.GetWidth();
		}

		/// <inheritdoc />
		public void Bounce()
		{
			_impulsX = -_impulsX;
		}
	}
}
