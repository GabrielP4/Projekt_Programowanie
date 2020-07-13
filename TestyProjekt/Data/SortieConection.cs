using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestyProjekt.Data
{
	
	public class SortieConection
	{
		private string addres = "https://api.warframestat.us/pc/sortie";

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
					if(response.StatusCode == HttpStatusCode.OK)
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
	}


	public partial class Temperatures
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("activation")]
		public DateTimeOffset Activation { get; set; }

		[JsonProperty("expiry")]
		public DateTimeOffset Expiry { get; set; }

		[JsonProperty("rewardPool")]
		public string RewardPool { get; set; }

		[JsonProperty("variants")]
		public List<Variant> Variants { get; set; }

		[JsonProperty("boss")]
		public string Boss { get; set; }

		[JsonProperty("faction")]
		public string Faction { get; set; }

		[JsonProperty("expired")]
		public bool Expired { get; set; }

		[JsonProperty("eta")]
		public string Eta { get; set; }
	}

	public partial class Variant
	{
		[JsonProperty("node")]
		public string Node { get; set; }

		[JsonProperty("boss")]
		public string Boss { get; set; }

		[JsonProperty("missionType")]
		public string MissionType { get; set; }

		[JsonProperty("planet")]
		public string Planet { get; set; }

		[JsonProperty("modifier")]
		public string Modifier { get; set; }

		[JsonProperty("modifierDescription")]
		public string ModifierDescription { get; set; }
	}
}
