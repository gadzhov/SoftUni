using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_1___Cubic_Artillery
{
    class Startup
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            var bunkers = new Queue<string>();
            var weapons = new Queue<int>();
            int freeCapacity = maxCapacity;

            Regex rgx = new Regex("[a-zA-Z]");

            string input = Console.ReadLine();
            while (input != "Bunker Revision")
            {
                string[] tokens = input.Split(new char[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in tokens)
                {
                    if (rgx.IsMatch(item))
                    {
                        bunkers.Enqueue(item);
                    }
                    else
                    {
                        int weaponCapacity = int.Parse(item);

                        bool weaponContained = false;
                        while (bunkers.Count > 1)
                        {
                            if (freeCapacity >= weaponCapacity)
                            {
                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                                weaponContained = true;
                                break;
                            }

                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> {string.Join(", ", weapons)}");
                            }

                            bunkers.Dequeue();
                            weapons.Clear();
                            freeCapacity = maxCapacity;
                        }

                        if (!weaponContained && bunkers.Count == 1)
                        {
                            if (maxCapacity >= weaponCapacity)
                            {
                                if (freeCapacity < weaponCapacity)
                                {
                                    while (freeCapacity < weaponCapacity)
                                    {
                                        int removedWeapon = weapons.Dequeue();
                                        freeCapacity += removedWeapon;
                                    }
                                }

                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                            }
                        }
                    }

                }

                input = Console.ReadLine();
            }
        }
    }
}
