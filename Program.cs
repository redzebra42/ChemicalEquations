using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    public static List<Atoms> ToMolecule(string molName)
    {
        List<Atoms> molecule = [];
        string currAtomName = "";
        foreach (char c in molName)
        {
            if (c>='0' && c<='9')
            {
                Atoms atm;
                atm.name = currAtomName;
                atm.number = c - '0';
                molecule.Add(atm);
                currAtomName = "";
            }
            else if (c>='A' && c<='Z' && currAtomName.Length >= 1)
            {
                Atoms atm;
                atm.name = currAtomName;
                atm.number = 1;
                molecule.Add(atm);
                currAtomName = c.ToString();
            }
            else
            {
                currAtomName += c;
            }
        }
        return molecule;
    }

    static void Main(string[] args)
    {
        string unbalanced = "HeCO2";

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine("balanced");
        List<Atoms> molecule = ToMolecule(unbalanced);
        foreach (Atoms atm in molecule)
        {
            Console.WriteLine(atm.name + " " + atm.number);
        }
    }
}

struct Atoms
{
    public string name;
    public int number;
}
