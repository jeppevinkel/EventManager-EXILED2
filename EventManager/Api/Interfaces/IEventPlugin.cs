namespace EventManager.Api.Interfaces
{
	public interface IEventPlugin
	{
		void OnEventStarted();

		void OnEventStopped();
	}
}
