

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter
        {
            get
            {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        public char? EndingLetter
        {
            get
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
            if (persons != null)
            {
                foreach (var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons) + "]";
        }

        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
            //list for group lists
            var personGroups = new List<PersonGroup>();

            //sort input list
            persons.Sort();

            // Creates space for current group
            var currentGroup = new PersonGroup();

            foreach (var person in persons)
            {
                //if current group is empty, then add the person
                if (currentGroup.Count == 0)
                {
                    currentGroup.Persons.Add(person);
                }

                //if current group isn't empty, check to see if the current person is within distance
                else if (person.Distance(currentGroup[0]) <= distance)
                {
                    //if within distance, add person to the current group
                    currentGroup.Persons.Add(person);
                }

                //otherwise, create new group for the pending persons
                else
                {
                    //adds currentGroup to personGroups list
                    personGroups.Add(currentGroup);

                    //creates new group
                    var newGroup = new PersonGroup();

                    //newGroup becomes the currentGroup; the new group is used in the next iteration
                    currentGroup = newGroup;
                    newGroup.Persons.Add(person);
                }
            }

            return personGroups;
        }

    }
}