using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TestyProjekt.Data.Tests
{
	[TestClass()]
	public class NightwaveConnectionTests
	{
		[TestMethod()]
		public async Task MakeObjectsTest()
		{
			NightwaveConnection testy = new NightwaveConnection();
			var x = await testy.MakeObjects();
			Assert.IsNotNull(x);
		}

		[TestMethod()]
		public async Task DownloadDataTest()
		{
			NightwaveConnection testy = new NightwaveConnection();
			var x = await testy.DownloadData();
			Assert.IsNotNull(x);
		}
	}
}