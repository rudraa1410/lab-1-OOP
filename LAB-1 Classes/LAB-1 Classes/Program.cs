using System;
using System.Collections.Generic;
using System.Linq;
namespace LAB_1_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();

            Person lan = new Person { personId = 1, firstName = "lan", lastName = "Brooks", favoriteColour = "Red", age = 30, isWorking = true };
            Person Gina = new Person { personId = 2, firstName = "Gina", lastName = "James", favoriteColour = "Green", age = 18, isWorking = false };
            Person Mike = new Person { personId = 3, firstName = "Mike", lastName = "Briscoe", favoriteColour = "Blue", age = 45, isWorking = true };
            Person Mary = new Person { personId = 4, firstName = "Mary", lastName = "Beals", favoriteColour = "Yellow", age = 28, isWorking = true };

            peopleList.Add(lan);
            peopleList.Add(Gina);
            peopleList.Add(Mike);
            peopleList.Add(Mary);

            // Display Gina’s information as a sentence
            Console.WriteLine($"2: {Gina.firstName} {Gina.lastName}'s favorite colour is {Gina.favoriteColour}");

            // Display all of Mike’s information as a list
            Console.WriteLine($"{Mike}");

            // Change Ian’s Favorite Colour to white, and then print his information as a sentence
            lan.ChangeFavoriteColour();
            Console.WriteLine($"1: {lan.firstName} {lan.lastName}'s favorite colour is: {lan.favoriteColour}");

            // Display Mary’s age after ten years
            Console.WriteLine($"{Mary.firstName} {Mary.lastName}'s Age in 10 years is: {Mary.GetAgeInTenYears()}");

            // Create two Relation Objects that show that Gina and Mary are sisters, and that Ian and Mike are brothers.
            Relation ginaMaryRelation = new Relation { relationshipType = Relation.RelationshipType.Sister };
            ginaMaryRelation.ShowRelationShip(Gina, Mary);

            Relation ianMikeRelation = new Relation { relationshipType = Relation.RelationshipType.Brother };
            ianMikeRelation.ShowRelationShip(lan, Mike);

            // Add all the Person objects to a list, and then use the list to display various information
            int totalAge = peopleList.Sum(person => person.age);
            double averageAge = (double)totalAge / peopleList.Count;

            Person youngestPerson = peopleList.OrderBy(person => person.age).First();
            Person oldestPerson = peopleList.OrderByDescending(person => person.age).First();

            Console.WriteLine($"Average age is: {averageAge}");
            Console.WriteLine($"The youngest person is: {youngestPerson.firstName}");
            Console.WriteLine($"The oldest person is: {oldestPerson.firstName}");

            foreach (var person in peopleList.Where(person => person.firstName.StartsWith("M")))
            {
                Console.WriteLine($"{person}");
            }

            foreach (var person in peopleList.Where(person => person.favoriteColour.Equals("Blue", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"{person}");
            }
        }
    }
}

class Person
{
    public int personId;
    public string firstName;
    public string lastName;
    public string favoriteColour;
    public int age;
    public bool isWorking;

    public void DisplayPersonInfo()
    {
        Console.WriteLine($"{personId}: {firstName} {lastName}'s favorite colour is {favoriteColour}");
    }

    public void ChangeFavoriteColour()
    {
        favoriteColour = "White";
    }

    public int GetAgeInTenYears()
    {
        return age + 10;
    }

    public override string ToString()
    {
        return $"{personId}: {firstName} {lastName}\nPersonId: {personId}\nFirstName: {firstName}\nLastName: {lastName}\nFavoriteColour: {favoriteColour}\nAge: {age}\nIsWorking: {isWorking}";
    }
}

class Relation
{
    public enum RelationshipType { Sister, Brother, Mother, Father }
    public RelationshipType relationshipType;

    public void ShowRelationShip(Person person1, Person person2)
    {
        Console.WriteLine($"Relationship between {person1.firstName} and {person2.firstName} is: {relationshipType}hood");
    }
}



