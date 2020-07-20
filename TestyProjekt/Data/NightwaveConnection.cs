using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Grupa_24.Data
{
	/// <summary>
	/// Klasa odpowiadająca za przetworzenie danych dla zakładki "Nightwave"
	/// </summary>
	public class NightwaveConnection
	{
		private string addres = "https://api.warframestat.us/pc/nightwave";

		/// <summary>
		///	Metoda tworząca obiekt
		/// </summary>
		/// Z danych pobranych przez metodę DownloadData
		/// metoda tworzy obiekt na podstawie klas Temperatures, EChallenge.
		/// <returns>obiekt root</returns>
		public async Task<Temperatures> MakeObjects()
		{
			Temperatures root = new Temperatures();
			root = null;
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

		/// <summary>
		/// Metoda towrząca dane
		/// </summary>
		/// Metoda towrzy string z otrzymanych danych do dalszej pracy w programie.
		/// <returns>string testRequest</returns>
		public async Task<string> DownloadData()
		{
			string testRequest = null;
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

		/// <summary>
		/// Klasa zawierająca główny szkielet pobieranego obiektu
		/// </summary>
		public partial class Temperatures
		{
			[JsonProperty("id")]
			public string Id { get; set; }

			[JsonProperty("activation")]
			public DateTimeOffset Activation { get; set; }

			[JsonProperty("expiry")]
			public DateTimeOffset Expiry { get; set; }

			[JsonProperty("rewardTypes")]
			public List<string> RewardTypes { get; set; }

			[JsonProperty("season")]
			public long Season { get; set; }

			[JsonProperty("tag")]
			public string Tag { get; set; }

			[JsonProperty("phase")]
			public long Phase { get; set; }

			[JsonProperty("possibleChallenges")]
			public List<EChallenge> PossibleChallenges { get; set; }

			[JsonProperty("activeChallenges")]
			public List<EChallenge> ActiveChallenges { get; set; }
		}

		/// <summary>
		/// Klasa zawierająca szkielet listy zawartej w obiekcie
		/// </summary>
		public partial class EChallenge
		{
			[JsonProperty("id")]
			public string Id { get; set; }

			[JsonProperty("activation")]
			public DateTimeOffset Activation { get; set; }

			[JsonProperty("expiry")]
			public DateTimeOffset Expiry { get; set; }

			[JsonProperty("isDaily")]
			public bool IsDaily { get; set; }

			[JsonProperty("isElite")]
			public bool IsElite { get; set; }

			[JsonProperty("title")]
			public string Title { get; set; }

			[JsonProperty("desc")]
			public string Desc { get; set; }

			[JsonProperty("reputation")]
			public long Reputation { get; set; }
		}
	}
}