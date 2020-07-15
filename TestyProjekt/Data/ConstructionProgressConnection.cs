using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace TestyProjekt.Data
{
	public class ConstructionProgressConnection
	{
		private string addres = "https://api.warframestat.us/pc/constructionProgress";
		public async Task<Temperatures> MakeObjects()
		{
			Temperatures root = new Temperatures();
			try
			{
				root = JsonConvert.DeserializeObject<Temperatures>(await DownloadData());
			}
			catch (Exception ex)
			{
				var a = ex.Message.ToString();
			}
			return root;
		}
		public async Task<string> DownloadData()
		{
			string testRequest = "";
			try
			{
				var request = HttpWebRequest.CreateHttp(addres);
				request.Method = WebRequestMethods.Http.Get;
				request.ContentType = "application/json; charset=utf-8";
				await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null).ContinueWith(task =>
				{
					var response = (HttpWebResponse)task.Result;
					if (response.StatusCode == HttpStatusCode.OK)
					{
						StreamReader responsReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
						string responseData = responsReader.ReadToEnd();
						testRequest = responseData.ToString();
						responsReader.Close();
					}
					response.Close();
				});
			}
			catch (Exception ex)
			{
				var a = ex.Message.ToString();
			}
			return testRequest;
		}
		public class Temperatures
		{
			[JsonProperty("id")]
			public string Id { get; set; }
			[JsonProperty("fomorianProgress")]
			public double FomorianProgress { get; set; }
			[JsonProperty("razorbackProgress")]
			public double RazorbackProgress { get; set; }
			[JsonProperty("unknownProgress")]
			public string UnknownProgress { get; set; }
		}
	}
}