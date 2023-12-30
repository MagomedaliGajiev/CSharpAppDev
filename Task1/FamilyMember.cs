using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1
{
    enum Gender { Male, Female }
    class FamilyMember
    {
        public string name { get; set; }
        public Gender gender { get; set; }
        public FamilyMember[] children { get; set; }
        public FamilyMember mother { get; set; }
        public FamilyMember father { get; set; }

        public FamilyMember()
        {
            
        }

        public FamilyMember(string name, Gender gender, FamilyMember mother, FamilyMember father, params FamilyMember[]? familyMembers)   
        {
            this.name = name;
            this.gender = gender;
            this.mother = mother;
            this.father = father;
            this.children = familyMembers;
        }

        public void MothersInFamily()
        {
            var adult = this;

            if (adult.mother != null)
            {
                adult = adult.children.Length > 0 && adult.children[0].mother != null ? 
                    adult.children[0].mother : this; 
            }

            while (adult.mother != null)
            {
                adult = adult.mother;
            }

            if (adult.gender == Gender.Female)
            {
                Console.WriteLine($"{adult.name} -> ");
            }

            var femaleChild = true;
            while (femaleChild)
            {
                femaleChild = false;
                Console.WriteLine($"{adult.name} -> ");

                foreach (var child in adult.children)
                {
                    if (adult.gender == Gender.Female)
                    {
                        adult.mother = child;
                        femaleChild = true;
                        break;
                    }
                }
            }
        }

        public List<FamilyMember> GetSiblings()
        {
            List<FamilyMember> siblings = new List<FamilyMember>();
            if (this.mother != null && this.father != null)
            {
                siblings.AddRange(this.mother.children.Where(child => child != this));
                siblings.AddRange(this.father.children.Where(child => child != this));
            }
            if (this.father != null && this.mother == null)
            {
                siblings.AddRange(this.father.children.Where(child => child != this));
            }
            if (this.father == null && this.mother != null)
            {
                siblings.AddRange(this.mother.children.Where(child => child != this));
            }
            return siblings;
        }

        public void PrintFamily()
        {
            FamilyMember secondMember = GetSpouse();

            if (secondMember != null)
            {
                PrintFamily(this, secondMember);
            }
            else
            {
                PrintFamily(this);
            }
        }

        private FamilyMember GetSpouse()
        {
            FamilyMember spouse = null;
            if (this.children != null)
            {
                spouse = this.gender == Gender.Male ? this.children[0].mother :
                    this.children[0].father;
            }

            return spouse;
        }

        public void PrintRelatives()
        {
            Console.Write($"{this.name} ");
            if (GetSiblings != null)
            {
                Console.Write("->");

                var siblings = GetSiblings();
                if (siblings.Count > 0)
                {
                    foreach (var member in siblings.GetRange(0, siblings.Count - 1))
                    {
                        Console.Write($"{member.name} ->");
                    }
                    Console.Write(siblings[siblings.Count - 1].name);
                }
                
            }
            if (GetSpouse() != null)
            {
                Console.WriteLine();
                Console.WriteLine("|");
                Console.Write($"{GetSpouse().name}");
            }
        }

        private void PrintFamily(params FamilyMember []? familyMembers)
        {
            List<FamilyMember> children = new List<FamilyMember>();
            foreach (var familyMember in familyMembers)
            {
                Console.Write($"{familyMember.name} ");
            }
            Console.WriteLine();
            foreach (var familyMember in familyMembers)
            {
                if (familyMember.children != null)
                {
                    foreach (var child in familyMember.children)
                    {
                        if (child.children != null)
                        {
                            foreach (var child2 in child.children)
                            {
                                var second = child.gender == Gender.Male ? child2.mother : child2.father;
                                if (second != null && !children.Contains(second))
                                {
                                    children.Add(second);
                                }
                            }
                        }
                        if (!children.Contains(child))
                        {
                            children.Add(child);
                        }
                    }
                }
            }
            if (children.Count > 0)
            {
                PrintFamily(children.ToArray());
            }
        }
    }
}
