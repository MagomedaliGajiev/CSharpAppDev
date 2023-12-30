namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var grandfather = new FamilyMember() { mother = null, father = null, name = "Grandfather", gender = Gender.Male };
            var grandmother = new FamilyMember() { mother = null, father = null, name = "Grandmother", gender = Gender.Female };
            var father = new FamilyMember() { mother = grandmother, father = grandfather, name = "Dad", gender = Gender.Male };
            grandfather.children = new FamilyMember[] { father };
            grandfather.children = new FamilyMember[] { father };
            var mother = new FamilyMember() { mother = null, father = null, name = "Mum", gender = Gender.Female };
            var mother2 = new FamilyMember() { mother = null, father = null, name = "Mum2", gender = Gender.Female };
            var son = new FamilyMember() { mother = mother, father = father, name = "Son", gender = Gender.Male };
            var son2 = new FamilyMember() { mother = mother2, father = father, name = "Son2", gender = Gender.Male };

            father.children = new FamilyMember[] { son, son2 };
            mother.children = new FamilyMember[] { son };
            mother2.children = new FamilyMember[] { son2 };

            grandfather.PrintFamily();
        }
    }
}