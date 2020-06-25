using System.Threading.Tasks;

namespace Loftysoft.Demo.Contracts
{
	public interface IMessageRepository
	{
		Task AddMessageAsync(string name, string message, string userHostAddress);
	}
}