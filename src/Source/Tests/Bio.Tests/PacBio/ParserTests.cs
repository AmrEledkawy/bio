﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Bio.IO.PacBio;

namespace Bio.Tests.PacBio
{
    [TestFixture]
    public static class ParserTests
    {
        [Test]
        [Category("PacBio")]
        public static void SimpleCCSTest ()
        {
            string fname = System.IO.Path.Combine ("TestUtils", "PacBio", "ccs.bam");
            var csp = new PacBioCCSBamReader ();
            var seqs = csp.Parse (fname).Select(z => z as PacBioCCSRead).ToList();

            var seq4 = seqs [4];
            Assert.AreEqual (273, seq4.HoleNumber);
            Assert.AreEqual (12, seq4.NumPasses);
            Assert.AreEqual (1, seq4.ReadCountBadZscore);
            Assert.AreEqual (1946, seq4.Sequence.Count);
            Assert.AreEqual (14, seq4.ZScores.Length);
            Assert.AreEqual("m150930_045019_42194_c100916310150000001823201204291662_s1_p0/273/ccs",
                             seq4.Sequence.ID);
            var seq = new Sequence (DnaAlphabet.Instance, seq4.Sequence.ToArray (), true);
            Assert.AreEqual("TGTCACTCATCTGAGTGATCCCGCGAAATTAATACGACTCACTATAGGGGAATTGTGAGCGGATAACAATTCCCCTCTAGAAATAATTTTGTTTAACTTTAAGAAGGAGATATACATATGAAACACATGCCACGTAAAATGTATTCCTGCGACTTTGAGACTACACCAAGGTTGAAGATTGCCGCGTATGGGCATACGGTTACATGAACATCGAAGACCACTCCGAGTATAAGATTGGTAACTCCCTGGATGAATTTATGGCTTGGGTTCTGAAAGTTCAGGCTGACCTGTACTTCCACAATCTGAAATTTGATGGCGCATTCATCATCAACTGGCTGGAACGTAACGGTTTTAAATGGTCCGCAGATGGTCTGCCAAATACCTACAACACCATCATTTCTCGCATGGGCCAGTGGTATATGATTGATATTTGCCTGGGTTACAAGGGTAAACGCAAGATCCACACCGTGATCTACGACTCTCTGAAGAAACTGCCGTTTCCGGTTAAGAAAATTGCGAAAGACTTTAAGCTGACGGTACTGAAAGGCGACATCGACTATCATAAGGAGCGCCCGGTCGTTACAAAATCACCCGGAAGAATATGCCTACATTAAAAACGATATTCAGATTATCGCAGAAGCTCTGCTGATCCAGTTCAAGCAGGGTCTGGATCGTATGACGGCAGGTTCTGACTCTCTGAAAGGCTTCAAAGACATTATCACCACCAAGAAGTTTAAAAAGGTTTCCCGACCCTGAGCCTGGGTCTGGACAAGGAAGTTCGTTATGCCTACCGTGGTGGTTTCACCTGGCTGAATGACCGTTTTAAAGAAAAAGAGATCGGCGAAGGTATGGTTTTTGATGTTAATTCCCTGTACCCAGCGCAAATGTACTCTCGCCTGCTGCCGTACGGCGAGCCGATCGTATTCGAGGGTAAATACGTCTGGGACGAGGACTACCCTCTGCACATTCAGCACATTCGTTGTGAATTTGAACTGAAGGAAGGCTACATCCCGACCATCCAGATCAATCGTTCCCGTTTCTACAAGGGTAACGAATACCTGAAATCTTCCGGCGGTGAAATTGCTGACCTGTGGCTGTCTAATGTTGATCTGGAACTGATGAAAGAGCACTACGACCTGTACAATGTTGAATATATCTCTGGTCTGAAGTTCAAAGCAACCACTGGCCTGTTCAAGGACTTTATCGACAAATGGACGTATATCAAAACTACCTCTGAAGGCGCCATCAAACAGCTGGCGAAGCTGATCCTGAACAGCCTGTACGGTAAATTCGCGTCCAACCCGGACGTTACCGGTAAAGTGCCATACCTGAAAGAGAACGGTGCTCTGGGTTTTCGTCTGGGTGAGGAGGAAACGAAAGACCCTGTATATACCCGATGGGTGTCTTTATCACGGCCTGGGCACGCTATACGACCATCACGGCAGCGCAGGCTTGTTATGATCGTATTATCTACTGCGATACCGATTCTATTCACCTGACTGGTACTGAAATTCCGGACGTTATCAAAGACATCGTAGACCCGAAGAAACTGGGCTACTGGGCGCACGAATCTACTTTTAAGCGTGCAAAATATCTGCGTCAGAAAACCTACATCCAGGATATTTACATGAAAGAAGTAGACGGCAAATTGGTAGAGGGCTCTCCTGACGACTACACTGACATCAAGTTCTCTGTGAAATGCGCAGGCATGACGGACAAAATCAAAAAGGAAGTGACTTTCGAAAACTTCAAAGTGGGTTTTTCTCGTAAAATGAAACCGAAGCCTGTTCAGGTACCGGGTGGCGTAGTGCTGGTTGATGACACTTTTACTATCAAATAACTCGAGCTGCAGGAATTCAAGCTTGGATCCGGCTGCTAACAAAGCCCGAAAGGAAGCTGAGTTGGCTGCTGCCACCGCTGAGCAATAACTTGTCACTCATCTGAGT",
                seq.ConvertToString());

            Assert.AreEqual (seqs.Count, 7);
        }
    }
}
