using Newtonsoft.Json.Linq;

//Create an instance of a class called HTTPClient, this is what actually makes the api call
var client = new HttpClient();

//Build an api url from where the call comes from
var kanyeURL = "https://api.kanye.rest/";

//Using the HTTPClient instance we made above
//Send a GET request to the url created above, this is going to give us back a string of JSON
var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

//Parse the JSON response we just got back into a JObject, we do this so we can access certain pieces/parts of the JSON
//In this case we will be getting the value of the key "quote" which will give us the actual quote itself and the whole JSON body
//Without ToString() it will be of type JToken, so we could never use it as a string
//var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
var kanyeQuote = JObject.Parse(kanyeResponse)["quote"].ToString();

Console.WriteLine(kanyeQuote);


//USING APPSETTINGS/API KEY SECTION

//Grab the appsettings file and the text
var appsettingsText = File.ReadAllText("appsettings.json");

//Get the api key from the appsettings text using it's key ("apiKey")
var apiKey = JObject.Parse(appsettingsText)["apiKey"].ToString();

//Building the api url using the provided params you chose (I chose the zip code option) along with the api key
var weatherURl = $"http://api.openweathermap.org/data/2.5/weather?zip=35091&appid={apiKey}&units=imperial";