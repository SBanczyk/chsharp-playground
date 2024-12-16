using System.Xml.Serialization;
using System.Globalization;

using (var sr = new StreamReader(@"D:\C#\Learning\Learning\obesity.csv"))
{
    var line = sr.ReadLine();
    line = sr.ReadLine();
    List<Person> personsList = new List<Person>() { };
    while(line != null)
    {
        var attributes = line.Split(',');
        personsList.Add(
            new Person(int.Parse(Math.Floor(double.Parse(attributes[0], CultureInfo.InvariantCulture)).ToString()),
            attributes[1], double.Parse(attributes[2], CultureInfo.InvariantCulture),
            double.Parse(attributes[3], CultureInfo.InvariantCulture), attributes[16]));
        line = sr.ReadLine();
    }
    using (var fs = new FileStream(@"D:\C#\Learning\Learning\obesity.xml", FileMode.OpenOrCreate))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
        serializer.Serialize(fs, personsList);
    }
}

public class Person
{
    public Person()
    {
    }

    public Person(int age, string gender, double height, double weight, string obesityType)
    {
        Age = age;
        Gender = gender;
        Height = height;
        Weight = weight;
        ObesityType = obesityType;
    }

    public int Age { get; set; }
    public string Gender { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string ObesityType {  get; set; }
}