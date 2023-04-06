using System;

namespace Lab4;
class Program
{
    static void Main(string[] args)
    {
        var kaylee = new Person("Kaylee", "Odom", new DateTime(1, 2, 3));
        var austin = new Person("Austin", "Applegate", new DateTime(1, 2, 3));
        var priscilla = new Person("Priscilla", "Harris", new DateTime(1, 2, 3));
        var kenan = new Person("Kenan", "Casey", new DateTime(1, 2, 3));
        var abbie = new Person("Abbie", "Vance", new DateTime(1, 2, 3));
        var sam = new Person("Sam", "Flowers", new DateTime(1, 2, 3));
        var luke = new Person("Luke", "Noles", new DateTime(1, 2, 3));
        var gavin = new Person("Gavin", "Boler", new DateTime(1, 2, 3));
        var tucker = new Person("Tucker", "Brown", new DateTime(1, 2, 3));
        var avery = new Person("Avery", "Harris", new DateTime(1, 2, 3));
        var allison = new Person("allison", "walker", new DateTime(1, 2, 3));
        var savannah = new Person("savannah", "martin", new DateTime(1, 2, 3));
        var brigitte = new Person("brigitte", "turner");
        var christian = new Person("christian", "stackpole");
        var wesley = new Person("Wesley", "Baker");

        Person[] persons = { kaylee, austin, priscilla, kenan, abbie, sam, luke,
            gavin, tucker, avery, allison, savannah, brigitte, christian, wesley };

        var personGroups = PersonGroup.GeneratePersonGroups(new List<Person>(persons), 3);

        foreach (var group in personGroups)
        {
            Console.WriteLine(group);
        }

    }
}

