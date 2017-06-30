using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem_13.Family_Tree;
// 80/100
public class FamilyTree
{
    private static Person person = new Person();

    public static void Main()
    {
        var searchedPerson = Console.ReadLine();
        var input = Console.ReadLine();
        var nameNameData = new Dictionary<string, string>();
        var nameDateData = new Dictionary<string, string>();
        var dateNameData = new Dictionary<string, string>();
        var dateDateData = new Dictionary<string, string>();
        var peopleWithDates = new Dictionary<string, string>();
        var savedInput = new List<string>();

        // Checking what kind of input we have and putting it in the correct Dictionary for him
        while (!input.Equals("End"))
        {
            if (input.Contains("-"))
            {
                savedInput.Add(input);
                var relatives = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToArray();

                if (!relatives[0].Contains("/"))
                {
                    if (!relatives[1].Contains("/"))
                    {
                        nameNameData[relatives[0]] = relatives[1];
                    }
                    else
                    {
                        nameDateData[relatives[0]] = relatives[1];
                    }
                }
                else
                {
                    if (!relatives[1].Contains("/"))
                    {
                        dateNameData[relatives[0]] = relatives[1];
                    }
                    else if (relatives[1].Contains("/"))
                    {
                        dateDateData[relatives[0]] = relatives[1];
                    }
                }
            }
            else
            {
                var personNameDate = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToArray();
                peopleWithDates[$"{personNameDate[0]} {personNameDate[1]}"] = personNameDate[2];
            }
            input = Console.ReadLine();
        }

        LocateNameDateForSearchedPerson(searchedPerson, peopleWithDates);

        FindPersonChildren(nameNameData, nameDateData, dateNameData, dateDateData, peopleWithDates);

        FindPersonParrents(nameNameData, nameDateData, dateNameData, dateDateData, peopleWithDates);
        Console.WriteLine();

        PrintSearchedResult(person, savedInput);
    }


    private static void PrintSearchedResult(Person person, List<string> savedInput)
    {
        Console.WriteLine($"{person.Name} {person.BornDate}");
        Console.WriteLine("Parents:");
        var parents = new StringBuilder();
        var children = new StringBuilder();

        // Go through every input line, in the order they were entered, and find if the String is actually a child or parent of the ones we already
        // found and know for the person we are looking for.
        for (int i = 0; i < savedInput.Count; i++)
        {
            foreach (var parent in person.Parents)
            {
                if (savedInput[i].Contains(parent.Name) || savedInput[i].Contains(parent.BornDate))
                {
                    // additional Check, because it's writing duplicates
                    if (!parents.ToString().Contains($"{parent.Name} {parent.BornDate}"))
                    {
                        parents.AppendLine($"{parent.Name} {parent.BornDate}");
                    }
                }
            }
            foreach (var child in person.Children)
            {
                if (savedInput[i].Contains(child.Name) || savedInput[i].Contains(child.BornDate))
                {
                    // additional Check, because it's writing duplicates
                    if (!children.ToString().Contains($"{child.Name} {child.BornDate}"))
                    {
                        children.AppendLine($"{child.Name} {child.BornDate}");
                    }
                }
            }
        }

        Console.Write(parents);
        Console.WriteLine("Children:");
        Console.WriteLine(children);
    }

    // Iterate through all the Dictionaries and find input which is the same as Searched person Name or Date (For Parents)
    private static void FindPersonParrents(Dictionary<string, string> nameNameData, Dictionary<string, string> nameDateData,
        Dictionary<string, string> dateNameData, Dictionary<string, string> dateDateData, Dictionary<string, string> peopleWithDates)
    {
        var parentsFromNameNameData = nameNameData.Where(p => p.Value.Equals(person.Name));
        var parentsFromNameDateData = nameDateData.Where(p => p.Value.Equals(person.BornDate));
        var parentsFromDateNameData = dateNameData.Where(d => d.Value.Equals(person.Name));
        var parentsFromDateDateData = dateDateData.Where(d => d.Value.Equals(person.BornDate));

        if (parentsFromNameNameData.Count() > 0)
        {
            foreach (var par in parentsFromNameNameData)
            {
                var parent = new PersonParents();
                parent.Name = par.Key;
                var parentDate = peopleWithDates.FirstOrDefault(p => p.Key.Equals(par.Key)).Value;
                parent.BornDate = parentDate;
                person.Parents.Add(parent);
            }
        }
        if (parentsFromNameDateData.Count() > 0)
        {
            foreach (var par in parentsFromNameDateData)
            {
                var parent = new PersonParents();
                parent.Name = par.Key;
                var parentDate = peopleWithDates.FirstOrDefault(p => p.Key.Equals(par.Key)).Value;
                parent.BornDate = parentDate;
                person.Parents.Add(parent);
            }
        }
        if (parentsFromDateNameData.Count() > 0)
        {
            foreach (var par in parentsFromDateNameData)
            {
                var parent = new PersonParents();
                parent.BornDate = par.Key;
                var parentName = peopleWithDates.FirstOrDefault(p => p.Value.Equals(par.Key)).Key;
                parent.Name = parentName;
                person.Parents.Add(parent);
            }
        }
        if (parentsFromDateDateData.Count() > 0)
        {
            foreach (var par in parentsFromDateDateData)
            {
                var parent = new PersonParents();
                parent.BornDate = par.Key;
                var parentName = peopleWithDates.FirstOrDefault(p => p.Value.Equals(par.Key)).Key;
                parent.Name = parentName;
                person.Parents.Add(parent);
            }
        }
    }

    // Iterate through all the Dictionaries and find input which is the same as Searched person Name or Date (For Children)
    private static void FindPersonChildren(Dictionary<string, string> nameNameData, Dictionary<string, string> nameDateData,
        Dictionary<string, string> dateNameData, Dictionary<string, string> dateDateData, Dictionary<string, string> peopleWithDates)
    {
        var childrenFromNameNameData = nameNameData.Where(p => p.Key.Equals(person.Name));
        var childrenFromNameDateData = nameDateData.Where(p => p.Key.Equals(person.Name));
        var childrenFromDateNameData = dateNameData.Where(d => d.Key.Equals(person.BornDate));
        var childrenFromDateDateData = dateDateData.Where(d => d.Key.Equals(person.BornDate));

        if (childrenFromNameNameData.Count() > 0)
        {
            foreach (var child in childrenFromNameNameData)
            {
                var children = new PersonChildren();
                children.Name = child.Value;
                var childDate = peopleWithDates.FirstOrDefault(n => n.Key.Equals(child.Value)).Value;
                children.BornDate = childDate;
                person.Children.Add(children);
            }
        }
        if (childrenFromNameDateData.Count() > 0)
        {
            foreach (var child in childrenFromNameDateData)
            {
                var children = new PersonChildren();
                children.BornDate = child.Value;
                var childName = peopleWithDates.FirstOrDefault(n => n.Value.Equals(child.Value)).Key;
                children.Name = childName;
                person.Children.Add(children);
            }
        }
        if (childrenFromDateNameData.Count() > 0)
        {
            foreach (var child in childrenFromDateNameData)
            {
                var children = new PersonChildren();
                children.Name = child.Value;
                var childDate = peopleWithDates.FirstOrDefault(n => n.Key.Equals(child.Value)).Value;
                children.BornDate = childDate;
                person.Children.Add(children);
            }
        }
        if (childrenFromDateDateData.Count() > 0)
        {
            foreach (var child in childrenFromDateDateData)
            {
                var children = new PersonChildren();
                children.BornDate = child.Value;
                var childName = peopleWithDates.FirstOrDefault(n => n.Value.Equals(child.Value)).Key;
                children.Name = childName;
                person.Children.Add(children);
            }
        }
    }

    // Find the Date or the Name for the Searched person, depending on what input it was given for him
    private static void LocateNameDateForSearchedPerson(string searchedPerson, Dictionary<string, string> peopleWithDates)
    {
        if (searchedPerson.Contains("/"))
        {
            person.BornDate = searchedPerson;
            var personName = peopleWithDates.SingleOrDefault(d => d.Value.Equals(searchedPerson)).Key;
            person.Name = personName;
        }
        else
        {
            person.Name = searchedPerson;
            var personDate = peopleWithDates.SingleOrDefault(n => n.Key.Equals(searchedPerson)).Value;
            person.BornDate = personDate;
        }
    }
}