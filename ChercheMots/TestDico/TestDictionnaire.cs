using ChercheMots.Metier;
using System;
using Xunit;

namespace TestDico
{
    public class TestDictionnaire
    {
        private Dictionnaire DicoTest
        {
            get
            {
                Dictionnaire tst = new Dictionnaire();                
                tst.Ajouter("ordinateur", "machine machine pour faire des programmes");
                tst.Ajouter("prof", "super professionnel qui transforme des étudiants en informaticiens");
                tst.Ajouter("ropf", "truc qui n'existe pas mais qui permet de tester les anagrammes");
                tst.Ajouter("orpf", "truc qui n'existe pas non plus");
                tst.Ajouter("niche", "la où dort le chien");
                tst.Ajouter("chien", "ce qu'on trouve dans une niche");
                tst.Ajouter("chienne", "femelle du chien");
                return tst;
            }
        }
        [Fact]
        public void TestAjouter()
        {
            Dictionnaire test = DicoTest;
            test.Ajouter("test", "test");
            Assert.Equal(8, test.NbMots);
            Assert.Throws<MotExisteException>(() => { test.Ajouter("test", "again"); });
        }

        [Fact]
        public void TestDefinition()
        {
            Dictionnaire test = DicoTest;
            Assert.Equal("la où dort le chien", test.Definition("niche"));
        }

        [Fact]
        public void TestMotAlea()
        {
            Dictionnaire test = DicoTest;
            for(int i=0;i<10;i++)
            {
                string mot = test.MotAleatoire;
                Assert.True(test.Contient(mot));
            }
            
        }

        [Fact]
        public void TestAnagrammes()
        {
            Dictionnaire test = DicoTest;
            var test1 = test.Anagrammes("chien");
            Assert.Single(test1);
            Assert.Equal("niche", test1[0]);
            var test2 = test.Anagrammes("prof");
            Assert.Equal(2, test2.Count);
            var test3 = test.Anagrammes("ordinateur");
            Assert.Empty(test3);
        }
    }
}
