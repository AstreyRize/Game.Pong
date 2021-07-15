namespace Game.Pong
{
	internal abstract class GameElement
	{
		public string Symbol { get; protected set; }

		public uint Size { get; protected set; }

		public virtual int X { get; set; }

		public virtual int Y { get; set; }

		public abstract void Draw();
	}
}