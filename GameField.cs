namespace Game.Pong
{
	/// <inheritdoc />
	class GameField : IGameField
	{
		/// <summary>
		/// Начальная позиция игрового поля по X.
		/// </summary>
		private readonly int _startXPosition;

		/// <summary>
		/// Высота игрового поля по X.
		/// </summary>
		private readonly int _height;

		/// <summary>
		/// Начальная позиция игрового поля по Y.
		/// </summary>
		private readonly int _startYPosition;

		/// <summary>
		/// Ширина игрового поля по Y.
		/// </summary>
		private readonly int _width;

		public GameField(int startXPosition, int height, int startYPosition, int width)
		{
			_startXPosition = startXPosition;
			_height = height;
			_startYPosition = startYPosition;
			_width = width;
		}

		/// <inheritdoc />
		public int GetStartXPosition()
		{
			return _startXPosition;
		}

		/// <inheritdoc />
		public int GetHeight()
		{
			return _height;
		}

		/// <inheritdoc />
		public int GetStartYPosition()
		{
			return _startYPosition;
		}

		/// <inheritdoc />
		public int GetWidth()
		{
			return _width;
		}
	}

	/// <summary>
	/// Игровое поле.
	/// </summary>
	internal interface IGameField
	{
		/// <summary>
		/// Получить начальную позицию игрового поля по X.
		/// </summary>
		/// <returns>Начальная позиция игрового поля по X.</returns>
		int GetStartXPosition();

		/// <summary>
		/// Получить ширину поля по оси X.
		/// </summary>
		/// <returns>Ширина поля по очи X.</returns>
		int GetWidth();

		/// <summary>
		/// Получить начальную позицию игрового поля по Y.
		/// </summary>
		/// <returns>Начальная позиция игрового поля по Y.</returns>
		int GetStartYPosition();

		/// <summary>
		/// Получить высоту поля по оси Y.
		/// </summary>
		/// <returns>Высота поля по очи Y.</returns>
		int GetHeight();
	}
}
