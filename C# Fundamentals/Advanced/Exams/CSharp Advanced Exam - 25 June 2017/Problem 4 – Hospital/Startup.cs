using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4___Hospital
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            var hospital = new Dictionary<string, Dictionary<int, List<string>>>();
            var doctorDictionary = new Dictionary<string, List<string>>();
            while ((input = Console.ReadLine()) != "Output")
            {
                var pationsTokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var department = pationsTokens[0];
                var doctor = $"{pationsTokens[1]} {pationsTokens[2]}";
                var patient = pationsTokens[3];

                if (!hospital.ContainsKey(department))
                {
                    hospital.Add(department, new Dictionary<int, List<string>>());
                    hospital[department].Add(1, new List<string>());
                    hospital[department][1].Add(patient);
                }
                else
                {
                    if (!hospital[department].ContainsKey(hospital[department].Count))
                    {
                        hospital[department].Add(hospital[department].Count, new List<string>());
                    }
                    else
                    {
                        if (hospital[department][hospital[department].Count].Count < 3)
                        {
                            hospital[department][hospital[department].Count].Add(patient);
                        }
                        else
                        {
                            if (hospital[department].Count < 20)
                            {
                                hospital[department][hospital[department].Count + 1] = new List<string> {patient};
                            }
                        }
                    }
                }
                if (hospital[department].Count <= 20)
                {
                    if (!doctorDictionary.ContainsKey(doctor))
                    {
                        doctorDictionary.Add(doctor, new List<string>());
                        doctorDictionary[doctor].Add(patient);
                    }
                    else
                    {
                        doctorDictionary[doctor].Add(patient);
                    }
                }
            }
            while ((input = Console.ReadLine()) != "End")
            {
                var command = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (command.Length == 2)
                {
                    var value = $"{command[0]} {command[1]}";
                    // doctorname
                    if (doctorDictionary.ContainsKey(value))
                    {
                        foreach (var patient in doctorDictionary[value].OrderBy(p => p))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    // department room
                    else
                    {
                        var department = command[0];
                       var  room = int.Parse(command[1]);
                        if (hospital.ContainsKey(department) && hospital[department].ContainsKey(room))
                        {
                            foreach (var patient in hospital[department][room].OrderBy(p => p))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
                // department
                else
                {
                    var department = command[0];
                    if (hospital.ContainsKey(department))
                    {
                        foreach (var departments in hospital[department])
                        {
                            foreach (var patient in departments.Value)
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
            }

        }
    }
}
