using System;
using System.IO;
using System.Xml.Serialization;
using Xunit;
using IFC4;
using Newtonsoft.Json;

namespace test
{
	public class UnitTest1
	{
		[Fact]
		public void SerializeProject()
		{
			var p1 = new IfcProject();
			p1.Name = new IfcLabel("Test Project");
			p1.Description = new IfcText("A test of IFC-dotnet.");
			var settings = new JsonSerializerSettings()
			{
				Formatting = Formatting.Indented,
				TypeNameHandling = TypeNameHandling.All
			};
			var str = JsonConvert.SerializeObject(p1, settings);
			Console.WriteLine(str);

			var p2 = JsonConvert.DeserializeObject<IfcProject>(str);
			Assert.Equal(p1.Name.Value, p2.Name.Value);
			Assert.Equal(p1.Description.Value, p2.Description.Value);
		}
	}
}
