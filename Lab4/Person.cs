using System.Diagnostics.CodeAnalysis;

namespace Lab4
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person(string firstName, string lastName, DateTime birthday) : this(firstName, lastName)
        {
            Birthday = birthday;
        }

        public int CompareTo([AllowNull] Person other)
        {
            if (other == null)
            {
                throw new NullReferenceException("Other Person must not be null");
            }

            return this.FirstName.CompareTo(other.FirstName);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }


        // TODO
        /// <summary>
        /// Computes the alphabetic distance between this person and the given pereson
        /// </summary>
        /// <param name="other">The other person</param>
        /// <returns>The distance (case insensitively) between this person and the given person.
        /// Note that this distance is always positive. 
        /// </returns>
        public int Distance(Person other)
        {
            // check that other isn't null
            if (other == null)
            {
                throw new NullReferenceException("Other Person must not be null");
            }

            // compute distance between first letters of first name

            string alphabetString = "abcdefghijklmnopqrstuvwxyz";
            IDictionary<int, string> alphabetAndNumber = new Dictionary<int, string>();
            int count = 0;
            int cValue = 0;
            int dValue = 0;

            foreach (var character in alphabetString)
            {
                alphabetAndNumber.Add(count, $"{character}");
                count++;
            }

            char c = char.ToLower(this.FirstName[0]);
            char d = char.ToLower(other.FirstName[0]);

            foreach (var entry in alphabetAndNumber)
            {
                if (char.Parse(entry.Value) == c)
                {
                    cValue = entry.Key;
                    break;
                }

            }

            foreach (var entry in alphabetAndNumber)
            {
                if (char.Parse(entry.Value) == d)
                {
                    dValue = entry.Key;
                    break;
                }

            }

            int difference = Math.Abs( cValue - dValue );
            Console.WriteLine(difference);


            return difference;
        }


    }
}