

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter {
            get {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        // TODO
        public char? EndingLetter { get 
            {
                return Persons[-1].FirstName[0];
            }
        }

        public int Count => Persons.Count;

        public Person this[int i]
        {
            get
            {
                if (Persons == null)
                    throw new NullReferenceException("Persons is null");

                if (i < 0 || i > Persons.Count)
                    throw new IndexOutOfRangeException();

                Persons.Sort();
                return Persons[i];
            }
        }

        public PersonGroup(List<Person> persons = null)
        {
            if( persons != null)
            {
                foreach(var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons)+ "]";
        }


        // TODO
        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
            //list for group lists
            var personGroups = new List<PersonGroup>();

            //sort input list
            persons.Sort();

            // It's is just a sample of how to interact with the classes.
            var currentGroup = new PersonGroup();

            foreach (var person in persons)
            {
                if (currentGroup.Count == 0)
                {
                    currentGroup.Add(person);
                }

                else if (person.Distance(person) <= distance)
                {
                    currentGroup.Add(person);
                }

                else
                {
                    personGroups.Add(currentGroup);
                    var newGroup = new List<Person>();
                    newGroup.Add(person);
                    GeneratePersonGroups(newGroup, distance);
                }
            }


            return personGroups;
        }

    }
}
