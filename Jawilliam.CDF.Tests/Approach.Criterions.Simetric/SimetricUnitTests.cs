/*Modified by jawilliam (jawilliam@gmail.com) to fix current project conventions: 
  namespaces, code guidelines (naming and mode...)
  
  Removing tests related with descriptions*/

using System;
using System.Globalization;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.Data.Simetric.Tests {
    [TestClass]
    public sealed class SimetricUnitTests
    {
        #region Tests

        [TestMethod]
        public void Bigrams_Simetric()
        {
            // For binary data Bigrams is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            NGramsSimetric<char> simetric = new NGramsSimetric<char>(2);

            Assert.AreEqual(0.7.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Bigrams test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.7647059.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Bigrams test - " + nameOne + ' ' + nameTwo);

            nameOne = "guillermo";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.25.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Bigrams test - " + nameOne + ' ' + nameTwo);

            nameOne = "mariam";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.3076923.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Bigrams test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Bigrams test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("aa", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Bigrams test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "aa").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Bigrams test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Bigrams test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Bigrams test - " + nameOne + ' ' + nameTwo);
        }

        [TestMethod]
        public void Trigrams_Simetric()
        {
            // For binary data Trigrams is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            NGramsSimetric<char> simetric = new NGramsSimetric<char>(3);

            Assert.AreEqual(0.3333333.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Trigrams test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.6875.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Trigrams test - " + nameOne + ' ' + nameTwo);

            nameOne = "guillermo";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.1428571.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Trigrams test - " + nameOne + ' ' + nameTwo);

            nameOne = "mariam";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.1818182.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Trigrams test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Trigrams test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("aa", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Trigrams test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "aa").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Trigrams test - " + nameOne + ' ' + nameTwo);
        }

        [TestMethod]
        public void MatchingCoefficient_Simetric()
        {
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            SimpleMatchingCoefficientSimetric<char> simetric = new SimpleMatchingCoefficientSimetric<char>();

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MatchingCoefficient test - " + nameOne + ' ' + nameTwo);

            nameOne = "RISTOHPHERC";
            nameTwo = "CHSTRIOPHER";
            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MatchingCoefficient test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.7142857.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MatchingCoefficient test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MatchingCoefficient test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MatchingCoefficient test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MatchingCoefficient test - " + nameOne + ' ' + nameTwo);

            simetric.D = (s1, s2) => 25 - Math.Max(s1.Length, s2.Length);
            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.76.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MatchingCoefficient test - " + nameOne + ' ' + nameTwo);
        }

        [TestMethod]
        public void RogersTanimotoCoefficient_Simetric()
        {
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            RogersTanimotoSimetric<char> simetric = new RogersTanimotoSimetric<char>();

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with RogersTanimotoCoefficient test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.5555556.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with RogersTanimotoCoefficient test - " + nameOne + ' ' + nameTwo);

            simetric.D = (s1, s2) => 25 - Math.Max(s1.Length, s2.Length);
            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.6129032.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with RogersTanimotoCoefficient test - " + nameOne + ' ' + nameTwo);

            simetric.D = (s1, s2) => 0;
            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with RogersTanimotoCoefficient test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with RogersTanimotoCoefficient test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with RogersTanimotoCoefficient test - '' a");
        }

        [TestMethod]
        public void JaccardIndex_Simetric()
        {
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            JaccardSimetric<char> simetric = new JaccardSimetric<char>() { GetComponents = VectorComponents.ByPositionEquality};

            Assert.AreEqual(0.6363636.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaccardIndex test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.2380952.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaccardIndex test - " + nameOne + ' ' + nameTwo);

            simetric.GetComponents = VectorComponents.ByTermFrequency;
            nameOne = "apple";
            nameTwo = "applet";
            Assert.AreEqual(0.875.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Cosine test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.8235294.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaccardIndex test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with JaccardIndex test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaccardIndex test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaccardIndex test - '' a");
        }

        [TestMethod]
        public void DiceCoefficient_Simetric()
        {
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            DiceCoefficientSimetric<char> simetric = new DiceCoefficientSimetric<char> { GetComponents = VectorComponents.ByPositionEquality };

            Assert.AreEqual(0.7777778.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with DiceCoefficient test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.3846154.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with DiceCoefficient test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with DiceCoefficient test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with DiceCoefficient test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with DiceCoefficient test - '' a");
        }

        [TestMethod]
        public void CosineCoefficient_Simetric()
        {
            CosineSimetric<char> simetric = new CosineSimetric<char> { GetComponents = VectorComponents.ByTermFrequency };

            var nameOne = "CHRISTOPHER";
            var nameTwo = "CHSTRIOPHER";
            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Cosine test - " + nameOne + ' ' + nameTwo);

            nameOne = "apple";
            nameTwo = "applet";
            Assert.AreEqual(0.935414.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Cosine test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.9348928.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Cosine test - " + nameOne + ' ' + nameTwo);

            simetric.GetComponents = VectorComponents.ByPositionEquality;

            nameOne = "CHRISTOPHER";
            nameTwo = "CHSTRIOPHER";
            Assert.AreEqual(0.797724.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Cosine test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.48795.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Cosine test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Cosine test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Cosine test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Cosine test - '' a");
        }

        [TestMethod]
        public void Canberra_Simetric()
        {
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            CanberraSimetric<char> simetric = new CanberraSimetric<char> { GetComponents = VectorComponents.ByPositionEquality };

            // Like jaccard for absent/present data.
            Assert.AreEqual(0.6363636.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Canberra test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.2380952.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Canberra test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Canberra test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Canberra test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Canberra test - '' a");
        }

        [TestMethod]
        public void Ruzicka_Simetric()
        {
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            RuzickaSimetric<char> simetric = new RuzickaSimetric<char> { GetComponents = VectorComponents.ByPositionEquality };

            // Like jaccard for absent/present data.
            Assert.AreEqual(0.6363636.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Ruzicka test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.2380952.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Ruzicka test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Ruzicka test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Ruzicka test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Ruzicka test - '' a");
        }

        [TestMethod]
        public void EuclideanDistance_Simetric()
        {
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            EuclideanDistanceSimetric<char> simetric = new EuclideanDistanceSimetric<char> { GetComponents = VectorComponents.ByPositionEquality };

            Assert.AreEqual(0.3333333.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Euclidean test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.2.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Euclidean test - " + nameOne + ' ' + nameTwo);

            simetric.GetComponents = VectorComponents.ByTermFrequency;
            Assert.AreEqual(0.2898979.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Euclidean test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Euclidean test - '' ''");

            Assert.AreEqual(0.5.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Euclidean test - a ''");

            Assert.AreEqual(0.5.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Euclidean test - '' a");
        }

        [TestMethod]
        public void BlockDistance_Simetric()
        {
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            BlockDistanceSimetric<char> distanceSimetric = new BlockDistanceSimetric<char> { GetComponents = VectorComponents.ByPositionEquality };

            Assert.AreEqual(0.2.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with BlockDistance test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.05882353.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with BlockDistance test - " + nameOne + ' ' + nameTwo);

            distanceSimetric.GetComponents = VectorComponents.ByTermFrequency;
            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.1428571.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with BlockDistance test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               distanceSimetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with BlockDistance test - '' ''");

            Assert.AreEqual(0.5.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with BlockDistance test - a ''");

            Assert.AreEqual(0.5.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with BlockDistance test - '' a");
        }

        [TestMethod]
        public void SoergelDistance_Simetric()
        {
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            SoergelDistanceSimetric<char> distanceSimetric = new SoergelDistanceSimetric<char> { GetComponents = VectorComponents.ByTermExistence };

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with SoergelDistance test - " + nameOne + ' ' + nameTwo);

            distanceSimetric.GetComponents = VectorComponents.ByPositionEquality;
            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with SoergelDistance test - " + nameOne + ' ' + nameTwo);

            //nameOne = "CHRISTOPHER PARKINSON";
            //nameTwo = "CHRIS PARKINSON";
            //Assert.AreEqual(0.05882353.ToString("F3", CultureInfo.InvariantCulture),
            //    distanceSimetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
            //    "Problem with SoergelDistance test - " + nameOne + ' ' + nameTwo);

            distanceSimetric.GetComponents = VectorComponents.ByTermFrequency;
            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.3333333.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with SoergelDistance test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               distanceSimetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with SoergelDistance test - '' ''");

            Assert.AreEqual(0.5.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with SoergelDistance test - a ''");

            Assert.AreEqual(0.5.ToString("F3", CultureInfo.InvariantCulture),
                distanceSimetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with SoergelDistance test - '' a");
        }

        [TestMethod]
        public void Czekanowski_Simetric()
        {
            // For binary data Czekanowski is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            CzekanowskiSimetric<char> simetric = new CzekanowskiSimetric<char> { GetComponents = VectorComponents.ByPositionEquality };

            Assert.AreEqual(0.7777778.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Czekanowski test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.3846154.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Czekanowski test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Czekanowski test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Czekanowski test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Czekanowski test - '' a");
        }

        [TestMethod]
        public void Motyka_Simetric()
        {
            // For binary data Motyka is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            MotykaSimetric<char> simetric = new MotykaSimetric<char> { GetComponents = VectorComponents.ByPositionEquality };

            Assert.AreEqual(0.3888888.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Motyka test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.19230769.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Czekanowski test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Czekanowski test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Czekanowski test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Czekanowski test - '' a");
        }

        [TestMethod]
        public void BaroniUrbaniBuser2Simetric_Simetric()
        {
            // For binary data BaroniUrbaniBuser2Simetric is equivalent to Dice
            BaroniUrbaniBuser2Simetric<char> simetric = new BaroniUrbaniBuser2Simetric<char>();

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with BaroniUrbaniBuser2 test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with BaroniUrbaniBuser2 test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with BaroniUrbaniBuser2 test - '' a");
        }

        [TestMethod]
        public void Levenshtein_Simetric()
        {
            // For binary data Levenshtein is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            LevenshteinSimetric<char> simetric = new LevenshteinSimetric<char>();

            Assert.AreEqual(0.6363636.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Levenshtein test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.7142857.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Levenshtein test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Levenshtein test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Levenshtein test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Levenshtein test - '' a");
        }

        [TestMethod]
        public void LCS_Simetric()
        {
            // For binary data LCS is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            LongestCommonSubsequenceSimetric<char> simetric = new LongestCommonSubsequenceSimetric<char>();

            Assert.AreEqual(0.8181818.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with LCS test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.8333333.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with LCS test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with LCS test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with LCS test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with LCS test - '' a");
        }

        [TestMethod]
        public void Overlap_Simetric()
        {
            // For binary data Overlap is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            OverlapCoefficientSimetric<char> simetric = new OverlapCoefficientSimetric<char>();

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Overlap test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Overlap test - " + nameOne + ' ' + nameTwo);

            nameOne = "guillermo";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.444444444.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Overlap test - " + nameOne + ' ' + nameTwo);

            nameOne = "mariam";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.666666.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Overlap test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Overlap test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Overlap test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Overlap test - '' a");
        }

        [TestMethod]
        public void Jaro_Simetric()
        {
            // For binary data Jaro is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            JaroSimetric<char> simetric = new JaroSimetric<char>();

            Assert.AreEqual(0.9393939.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Jaro test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.815873.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Jaro test - " + nameOne + ' ' + nameTwo);

            nameOne = "guillermo";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.6296296.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Jaro test - " + nameOne + ' ' + nameTwo);

            nameOne = "mariam";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.7037037.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Jaro test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with Jaro test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Jaro test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with Jaro test - '' a");
        }

        [TestMethod]
        public void JaroWinkler_Simetric()
        {
            // For binary data JaroWinkler is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            JaroWinklerSimetric<char> simetric = new JaroWinklerSimetric<char>();

            Assert.AreEqual(0.9515152.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaroWinkler test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.8895238.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaroWinkler test - " + nameOne + ' ' + nameTwo);

            nameOne = "guillermo";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.6296296.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaroWinkler test - " + nameOne + ' ' + nameTwo);

            nameOne = "mariam";
            nameTwo = "jawilliam";
            Assert.AreEqual(0.7037037.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(nameOne, nameTwo).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaroWinkler test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with JaroWinkler test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaroWinkler test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with JaroWinkler test - '' a");
        }

        [TestMethod]
        public void ChapmanLengthDeviationSimetric_Simetric()
        {
            // For binary data ChapmanLengthDeviationSimetric is equivalent to Dice
            ChapmanLengthDeviation<char> simetric = new ChapmanLengthDeviation<char>();

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with ChapmanLengthDeviation test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with ChapmanLengthDeviation test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with ChapmanLengthDeviation test - '' a");
        }

        [TestMethod]
        public void ChapmanMeanLength_Simetric()
        {
            // For binary data ChapmanMeanLengthSimetric is equivalent to Dice
            ChapmanMeanLength<char> simetric = new ChapmanMeanLength<char>();

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with ChapmanMeanLength test - '' ''");

            Assert.AreEqual(0.007976031.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with ChapmanMeanLength test - a ''");

            Assert.AreEqual(0.007976031.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with ChapmanMeanLength test - '' a");
        }

        [TestMethod]
        public void MongeElkan_Simetric()
        {
            // For binary data MongeElkan is equivalent to Dice
            string nameOne = "CHRISTOPHER", nameTwo = "CHSTRIOPHER";
            MongeElkanSimetric<string> simetric = new MongeElkanSimetric<string>((c, c1) => c == c1 ? 1 : 0);

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(new []{ "CHRISTOPHER" }, new[] { "CHSTRIOPHER" }).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MongeElkan test - " + nameOne + ' ' + nameTwo);

            nameOne = "CHRISTOPHER PARKINSON";
            nameTwo = "CHRIS PARKINSON";
            Assert.AreEqual(0.5.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(new[] { "CHRISTOPHER", "PARKINSON" }, new[] { "CHRIS", "PARKINSON" }).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MongeElkan test - " + nameOne + ' ' + nameTwo);

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity(new []{""}, new[] { "" }).ToString("F3", CultureInfo.InvariantCulture),
               "Problem with MongeElkan test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(new[] { "a" }, new []{""}).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MongeElkan test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity(new[] { "" }, new[] { "a" }).ToString("F3", CultureInfo.InvariantCulture),
                "Problem with MongeElkan test - '' a");
        }

        [TestMethod]
        public void NeedlemanWunschSimetric_Simetric()
        {
            // For binary data NeedlemanWunschSimetric is equivalent to Dice
            NeedlemanWunschSimetric<char> simetric = new NeedlemanWunschSimetric<char>();

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with NeedlemanWunsch test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with NeedlemanWunsch test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with NeedlemanWunsch test - '' a");
        }

        [TestMethod]
        public void SmithWaterman_Simetric()
        {
            // For binary data SmithWaterman is equivalent to Dice
            SmithWatermanSimetric<char> simetric = new SmithWatermanSimetric<char>();

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with BaroniUrbaniBuser2 test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with BaroniUrbaniBuser2 test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with BaroniUrbaniBuser2 test - '' a");
        }

        [TestMethod]
        public void ChawatheMatchingCriterion2_Simetric()
        {
            // For binary data SmithWaterman is equivalent to Dice
            ChawatheMatchingCriterion2Simetric<char> simetric = new ChawatheMatchingCriterion2Simetric<char>();

            Assert.AreEqual(1.ToString("F3", CultureInfo.InvariantCulture),
               simetric.GetSimilarity("", "").ToString("F3", CultureInfo.InvariantCulture),
               "Problem with ChawatheMatchingCriterion2 test - '' ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("a", "").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with ChawatheMatchingCriterion2 test - a ''");

            Assert.AreEqual(0.ToString("F3", CultureInfo.InvariantCulture),
                simetric.GetSimilarity("", "a").ToString("F3", CultureInfo.InvariantCulture),
                "Problem with ChawatheMatchingCriterion2 test - '' a");
        }

        #endregion
    }
}