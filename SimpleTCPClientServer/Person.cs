using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int accessLevel;

	public Person(string first, string last, int level)
	{
        firstName = first;
        lastName = last;
        accessLevel = level;
	}

    public int FirstName()
    {
        get
        {
            return firstName;
        }
    }
}
