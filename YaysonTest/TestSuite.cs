using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Yayson;

namespace YaysonTest
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class TestSuite
    {
        Yayson.Yayson yayson = new Yayson.Yayson();

        // Numbered examples from https://adobe.github.io/Spry/samples/data_region/JSONDataSetSample.html

        [Fact]
        public void UniTest1()
        {            
            var s = "[ 100, 500, 300, 200, 400 ]";
            var token = yayson.MakeToken(s);
            Assert.IsType<JsonList>(token);
            var jList = token as JsonList;
            Assert.StrictEqual(5, jList.GetCount());
            jList.Contents.ForEach(c => Assert.IsType<JsonInteger>(c));
        }

        [Fact(Skip = "non-quoted object keys")]
        public void UniTest2()
        {
            var s = @"[
	            {
		            color: ""red"",

                    value: ""#f00""

                },
	            {
		            color: ""green"",
		            value: ""#0f0""

                },
	            {
		            color: ""blue"",
		            value: ""#00f""
	            },
	            {
		            color: ""cyan"",
		            value: ""#0ff""

                },
	            {
		            color: ""magenta"",
		            value: ""#f0f""

                },
	            {
		            color: ""yellow"",
		            value: ""#ff0""

                },
	            {
		            color: ""black"",
		            value: ""#000""

                }
            ]";

            var token = yayson.MakeToken(s);
            Assert.IsType<JsonList>(token);
            var jList = token as JsonList;
            var firstChild = jList[0] as JsonObject;
            Assert.StrictEqual(7, jList.GetCount());
            Assert.StrictEqual(2, firstChild.GetCount());
        }

        [Fact(Skip = "non-quoted object keys")]
        public void UniTest3()
        {
            var s = @"{
	            color: ""red"",

                value: ""#f00""
            }";

            var token = yayson.MakeToken(s);
            Assert.IsType<JsonObject>(token);
            var jObject = token as JsonObject;
            Assert.StrictEqual(2, jObject.GetCount());
        }

        [Fact]
        public void UniTest4()
        {
            var s = @"{
	            ""id"": ""0001"",

                ""type"": ""donut"",
	            ""name"": ""Cake"",
	            ""ppu"": 0.55,
	            ""batters"":
		            {
                            ""batter"":
                            [
					            { ""id"": ""1001"", ""type"": ""Regular"" },
					            { ""id"": ""1002"", ""type"": ""Chocolate"" },
					            { ""id"": ""1003"", ""type"": ""Blueberry"" },
					            { ""id"": ""1004"", ""type"": ""Devil's Food"" }
				            ]
		            },
	            ""topping"":
		            [
			            { ""id"": ""5001"", ""type"": ""None"" },
			            { ""id"": ""5002"", ""type"": ""Glazed"" },
			            { ""id"": ""5005"", ""type"": ""Sugar"" },
			            { ""id"": ""5007"", ""type"": ""Powdered Sugar"" },
			            { ""id"": ""5006"", ""type"": ""Chocolate with Sprinkles"" },
			            { ""id"": ""5003"", ""type"": ""Chocolate"" },
			            { ""id"": ""5004"", ""type"": ""Maple"" }
		            ]
            }";

            var token = yayson.MakeToken(s);
            Assert.IsType<JsonObject>(token);
            var jObject = token as JsonObject;            
            Assert.StrictEqual(6, jObject.GetCount());
            var topping = jObject["topping"] as JsonList;
            Assert.StrictEqual(7, topping.GetCount());
            var blueberry = jObject["batters"]["batter"][2]["type"];
            Assert.StrictEqual("Blueberry", blueberry.ToString());
        }

        [Fact]
        public void UniTest5()
        {
            var s = @"[
	            {
		            ""id"": ""0001"",
		            ""type"": ""donut"",
		            ""name"": ""Cake"",
		            ""ppu"": 0.55,
		            ""batters"":
			            {
				            ""batter"":
					            [
						            { ""id"": ""1001"", ""type"": ""Regular"" },
						            { ""id"": ""1002"", ""type"": ""Chocolate"" },
						            { ""id"": ""1003"", ""type"": ""Blueberry"" },
						            { ""id"": ""1004"", ""type"": ""Devil's Food"" }
					            ]
			            },
		            ""topping"":
			            [
				            { ""id"": ""5001"", ""type"": ""None"" },
				            { ""id"": ""5002"", ""type"": ""Glazed"" },
				            { ""id"": ""5005"", ""type"": ""Sugar"" },
				            { ""id"": ""5007"", ""type"": ""Powdered Sugar"" },
				            { ""id"": ""5006"", ""type"": ""Chocolate with Sprinkles"" },
				            { ""id"": ""5003"", ""type"": ""Chocolate"" },
				            { ""id"": ""5004"", ""type"": ""Maple"" }
			            ]
	            },
	            {
		            ""id"": ""0002"",
		            ""type"": ""donut"",
		            ""name"": ""Raised"",
		            ""ppu"": 0.55,
		            ""batters"":
			            {
				            ""batter"":
					            [
						            { ""id"": ""1001"", ""type"": ""Regular"" }
					            ]
			            },
		            ""topping"":
			            [
				            { ""id"": ""5001"", ""type"": ""None"" },
				            { ""id"": ""5002"", ""type"": ""Glazed"" },
				            { ""id"": ""5005"", ""type"": ""Sugar"" },
				            { ""id"": ""5003"", ""type"": ""Chocolate"" },
				            { ""id"": ""5004"", ""type"": ""Maple"" }
			            ]
	            },
	            {
		            ""id"": ""0003"",
		            ""type"": ""donut"",
		            ""name"": ""Old Fashioned"",
		            ""ppu"": 0.55,
		            ""batters"":
			            {
				            ""batter"":
					            [
						            { ""id"": ""1001"", ""type"": ""Regular"" },
						            { ""id"": ""1002"", ""type"": ""Chocolate"" }
					            ]
			            },
		            ""topping"":
			            [
				            { ""id"": ""5001"", ""type"": ""None"" },
				            { ""id"": ""5002"", ""type"": ""Glazed"" },
				            { ""id"": ""5003"", ""type"": ""Chocolate"" },
				            { ""id"": ""5004"", ""type"": ""Maple"" }
			            ]
	            }
            ]";

            var token = yayson.MakeToken(s);
            Assert.IsType<JsonList>(token);
            var jList = token as JsonList;
            Assert.StrictEqual(3, jList.GetCount());
            var someType = jList[2]["batters"]["batter"][1]["type"];
            Assert.IsType<JsonString>(someType);
            Assert.StrictEqual("Chocolate", (someType as JsonString).Value);
        }

        [Fact]
        public void UniTest6()
        {
            var s = @"
            {
	            ""id"": ""0001"",

                ""type"": ""donut"",
	            ""name"": ""Cake"",
	            ""image"":
		            {
                            ""url"": ""images/0001.jpg"",
			            ""width"": 200,
			            ""height"": 200

                    },
	            ""thumbnail"":
		            {
                            ""url"": ""images/thumbnails/0001.jpg"",
			            ""width"": 32,
			            ""height"": 32

                    }
            }";

            var token = yayson.MakeToken(s);
            Assert.IsType<JsonObject>(token);
            var jObject = token as JsonObject;
            Assert.StrictEqual(5, jObject.GetCount());
            var width = jObject[4]["thumbnail"]["width"] as JsonInteger;
            Assert.StrictEqual(32, width.Value);
        }

        [Fact]
        public void SmallTests()
        {
            var standAloneString = @"""agurk""";
            var stringToken = yayson.MakeToken(standAloneString) as JsonString;
            Assert.IsType<JsonString>(stringToken);

            var standAloneInt = "221";
            var intToken = yayson.MakeToken(standAloneInt) as JsonInteger;
            Assert.IsType<JsonInteger>(intToken);

            var standAloneBool = "true";
            var boolToken = yayson.MakeToken(standAloneBool) as JsonBoolean;
            Assert.IsType<JsonBoolean>(boolToken);
        }

        [Fact]
        public void MoreNumberTests()
        {
            var negativeIntegerString = "-21";
            var negativeIntToken = yayson.MakeToken(negativeIntegerString) as JsonInteger;
            Assert.StrictEqual(-21, negativeIntToken.Value);

            var negativeDoubleString = "-911.28";
            var negativeDoubleToken = yayson.MakeToken(negativeDoubleString) as JsonDouble;
            Assert.StrictEqual(-911.28, negativeDoubleToken.Value);

            var exponentLittleEString = "2.121e-3";
            var exponentLittleEToken = yayson.MakeToken(exponentLittleEString) as JsonDouble;
            Assert.StrictEqual(0.002121, exponentLittleEToken.Value);

            var negativeExponentBigEString = "-2.121E-3";
            var negativeExponentBigEToken = yayson.MakeToken(negativeExponentBigEString) as JsonDouble;
            Assert.StrictEqual(-0.002121, negativeExponentBigEToken.Value);
        }
    }
}
