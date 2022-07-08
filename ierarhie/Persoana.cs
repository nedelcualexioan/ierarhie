using System;

namespace ierarhie
{
    public class Persoana
    {
        private String firstname;
        private String lastname;
        private int age;
        private String role;

        public Persoana(string firstname, string lastname, int age, string role)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
            this.role = role;
        }

        public Persoana(String line) : this(line.Split(',')[0], line.Split(',')[1], int.Parse(line.Split(',')[2]),
            line.Split(',')[3])
        {

        }

        public string Firstname
        {
            get => firstname;
            set => firstname = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Persoana pers)
            {
                return this.Firstname.Equals(pers.Firstname) && this.Lastname.Equals(pers.Lastname) &&
                       this.Age.Equals(pers.Age) && this.Role.Equals(pers.Role);
            }

            return false;
        }

        public override string ToString()
        {
            String text = "";

            text += "Firstname: " + firstname + "\n";
            text += "Lastname: " + lastname + "\n";
            text += "Age: " + age + "\n";
            text += "Role: " + role + "\n";

            return text;
        } 

        public string Lastname
        {
            get => lastname;
            set => lastname = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public string Role
        {
            get => role;
            set => role = value;
        }
    }
}