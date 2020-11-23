using System.Threading.Tasks;
using Loftysoft.Demo.Contracts;

namespace Loftysoft.Demo.Lib
{
	/// <summary>
	/// Null implementation of <see cref="IMessageRepository"/>.
	/// </summary>
	// ReSharper disable once UnusedMember.Global
	// ReSharper disable once ClassNeverInstantiated.Global
	public class NullMessageRepository : IMessageRepository
	{
		public Task AddMessageAsync(string name, string message, string userHostAddress)
		{
			return Task.FromResult<object>(null);
		}
	}
}