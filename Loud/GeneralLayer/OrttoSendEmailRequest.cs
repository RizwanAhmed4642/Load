//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//namespace SAS.GeneralLayer
//{
//	// Define a class to hold the request data
//	public class SendEmailRequest
//	{
//		public Asset Asset { get; set; }
//		public Email[] Emails { get; set; }
//		public string[] MergeBy { get; set; }
//		public int MergeStrategy { get; set; }
//		public int FindStrategy { get; set; }
//		public bool SkipNonExisting { get; set; }
//	}

//	public class Asset
//	{
//		public string FromEmail { get; set; }
//		public string FromName { get; set; }
//		public string[] Cc { get; set; }
//		public string Subject { get; set; }
//		public string EmailName { get; set; }
//		public bool NoClickTracks { get; set; }
//		public bool NoOpensTracks { get; set; }
//		public string HtmlBody { get; set; }
//		public bool LiquidSyntaxEnabled { get; set; }
//	}

//	public class Email
//	{
//		public Fields Fields { get; set; }
//		public object Location { get; set; }
//	}

//	public class Fields
//	{
//		[JsonProperty("bol::sp")]
//		public bool BolSp { get; set; }
//		[JsonProperty("str::email")]
//		public string Email { get; set; }
//		[JsonProperty("str::first")]
//		public string FirstName { get; set; }
//		[JsonProperty("str::last")]
//		public string LastName { get; set; }
//		[JsonProperty("str::soi-ctx")]
//		public string SoiContext { get; set; }
//	}

//	public async Task<string> SendEmail()
//	{
//		var apiEndpoint = "https://api.ap3api.com/v1/transactional/send";
//		var apiKey = "YOUR-CUSTOM-API-KEY";

//		var sendEmailRequest = new SendEmailRequest
//		{
//			Asset = new Asset
//			{
//				FromEmail = "jenny@ortto.com",
//				FromName = "Jenny Spencer",
//				Cc = new[] { "help@ortto.com" },
//				Subject = "Booking confirmation for {{ people.first-name }}",
//				EmailName = "confirm-booking",
//				NoClickTracks = false,
//				NoOpensTracks = false,
//				HtmlBody = "",
//				LiquidSyntaxEnabled = true
//			},
//			Emails = new[]
//			{
//			new Email
//			{
//				Fields = new Fields
//				{
//					BolSp = true,
//					Email = "chris@ortto.com",
//					FirstName = "Chris",
//					LastName = "Sharkey",
//					SoiContext = "API (Booking confirmation)"
//				},
//				Location = null
//			}
//		},
//			MergeBy = new[] { "str::email" },
//			MergeStrategy = 2,
//			FindStrategy = 0,
//			SkipNonExisting = false
//		};

//		var json = JsonConvert.SerializeObject(sendEmailRequest);

//		using (var client = new HttpClient())
//		{
//			client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
//			client.DefaultRequestHeaders.Add("Content-Type", "application/json");
//			var response = await client.PostAsync(apiEndpoint, new StringContent(json, Encoding.UTF8, "application/json"));

//			if (response.IsSuccessStatusCode)
//			{
//				var responseContent = await response.Content.ReadAsStringAsync();
//				return responseContent;
//			}
//			else
//			{
//				throw new HttpRequestException($"Error sending email: {response.StatusCode}");
//			}
//		}
//	}
//}