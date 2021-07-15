namespace Game.Pong
{
	internal interface IBall
	{
		bool DetectHit(GameElement gameElement);

		bool DetectDeparture();

		void Bounce();
	}
}