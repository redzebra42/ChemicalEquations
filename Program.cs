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

    public static List<List<Atoms>>[] EquationParsing(string equation)
    {
        List<List<Atoms>>[] equations = [[], []];
        string currMolName = "";
        int i = 0;
        foreach (char c in equation)
        {
            if (c == ' ' && currMolName != "+" && currMolName != "->")
            {
                equations[i].Add(ToMolecule(currMolName));
                currMolName = "";
            }
            else if (c == ' ' && currMolName == "->")
            {
                currMolName = "";
                i++;
            }
            else if (c != ' ')
            {
                currMolName += c;
            }
        }
        equations[i].Add(ToMolecule(currMolName));
        return equations;
    }

    public static List<List<int>> EquationBalancing(List<List<Atoms>>[] equation)
    {
        List<List<int>> coefficients = [[], []];
        
        return coefficients;
    }

    static void Main(string[] args)
    {
        string unbalanced = "HeCO2 + C3H -> HeC7 + 02H3";

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine("balanced");
        foreach (var mol in EquationParsing(unbalanced))
        {
            Console.WriteLine(mol.Count);
        }
    }
}

struct Atoms
{
    public string name;
    public int number;
}
