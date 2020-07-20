using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestyProjekt.Data
{
	/// <summary>
	/// Klasa odpowiadająca za przetworzenie danych dla zakładki "Construction progress"
	/// </summary>
	public class ConstructionProgressConnection
	{
		private string addres = "https://api.warframestat.us/pc/constructionProgress";

		/// <summary>
		///	Metoda tworząca obiekt
		/// </summary>
		/// Z danych pobranych przez metodę DownloadData
		/// metoda tworzy obiekt na podstawie klas Temperatures.
		/// Zwraca obiekt root.
		/// <returns>root</returns>
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
		/// Zwraca string testRequest.
		/// <returns>testRequest</returns>
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