namespace Jawilliam.CDF.Tests.Flad.Awareness
{
    using Jawilliam.CDF.Approach;
    using Jawilliam.CDF.CSharp.RoslynML;
    using Jawilliam.CDF.XObjects.RDSL;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    partial class RoslynMLDeltaExpanderTests
    {
    	 partial void PragmaChecksumDirectiveTriviaServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<PragmaChecksumDirectiveTriviaSyntax> nodes);
    
    	 [TestMethod]
         public void PragmaChecksumDirectiveTriviaServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_OK()
         {
    		var converter = new CDF.CSharp.RoslynML.RoslynML();
    		var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
    		int id = 0; 
    
    	    IEnumerable<PragmaChecksumDirectiveTriviaSyntax> nodes = null;
    	    string expectedLabel = null;
    	    PragmaChecksumDirectiveTriviaServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref nodes);
    		foreach(var node in nodes)
    		{
    			expectedLabel = Enum.GetName(typeof(SyntaxKind), node.Kind());
    
    			var oElement = converter.Visit(node);
    			converter.SetGumTreefiedIDs(oElement, ref id);
    			converter.SetRoslynMLIDs(oElement, ref id);
    			converter.Prune(oElement, selector.PruneSelector); 
    			converter.Defoliate(oElement);
    
    			var mElement = converter.Visit(node);
    			converter.SetGumTreefiedIDs(mElement, ref id);
    			converter.SetRoslynMLIDs(mElement, ref id);
    			converter.Prune(mElement, selector.PruneSelector); 
    			converter.Defoliate(mElement);
    
    			var oFullElement = converter.Visit(node);
    			converter.SetGumTreefiedIDs(oFullElement, ref id);
    			converter.SetRoslynMLIDs(oFullElement, ref id);
    			converter.Prune(oFullElement, selector.PruneSelector); 
    			converter.Defoliate(oFullElement);
    
    			var mFullElement = converter.Visit(node);
    			converter.SetGumTreefiedIDs(mFullElement, ref id);
    			converter.SetRoslynMLIDs(mFullElement, ref id);
    			converter.Prune(mFullElement, selector.PruneSelector); 
    			converter.Defoliate(mFullElement);
    
    			DeltaExpander expander = new DeltaExpander();
    
    			// Match
    			expander.Expand(
    				new RevisionPair<XElement> { Original = oElement, Modified = mElement },
    				new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement }, 
    				(Matches: new XElement[] 
    				{ 
    					new XElement("Match", 
    						new XAttribute("oId", oElement.GtID()),
    						new XAttribute("oLb", oElement.Label()),
    						new XAttribute("mId", mElement.GtID()), 
    						new XAttribute("mLb", mElement.Label())) 
    				},
    			Actions: new XElement[0]));
    			
    			var existingProperties = 7;
    
    			Assert.AreEqual(expander.FullDelta.Matches.Count(), existingProperties + 1);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID()).Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == expectedLabel).Attribute("mLb").Value == expectedLabel);
    
    			var HashTokenLabel = Enum.GetName(typeof(SyntaxKind), node.HashToken.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == HashTokenLabel).Attribute("mLb").Value == HashTokenLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == HashTokenLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var PragmaKeywordLabel = Enum.GetName(typeof(SyntaxKind), node.PragmaKeyword.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == PragmaKeywordLabel).Attribute("mLb").Value == PragmaKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == PragmaKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var ChecksumKeywordLabel = Enum.GetName(typeof(SyntaxKind), node.ChecksumKeyword.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == ChecksumKeywordLabel).Attribute("mLb").Value == ChecksumKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == ChecksumKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var FileLabel = Enum.GetName(typeof(SyntaxKind), node.File.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == FileLabel).Attribute("mLb").Value == FileLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == FileLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var GuidLabel = Enum.GetName(typeof(SyntaxKind), node.Guid.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == GuidLabel).Attribute("mLb").Value == GuidLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == GuidLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var BytesLabel = Enum.GetName(typeof(SyntaxKind), node.Bytes.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == BytesLabel).Attribute("mLb").Value == BytesLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == BytesLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var EndOfDirectiveTokenLabel = Enum.GetName(typeof(SyntaxKind), node.EndOfDirectiveToken.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == EndOfDirectiveTokenLabel).Attribute("mLb").Value == EndOfDirectiveTokenLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == EndOfDirectiveTokenLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.AreEqual<int>(expander.FullDelta.Actions.Count(), 0);
    
    			// Insert
    			expander.Expand(
    				new RevisionPair<XElement> { Original = oElement, Modified = mElement },
    				new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement }, 
    				(Matches: new XElement[] 
    				{ 
    					new XElement("Insert", 
    						new XAttribute("eId", mElement.GtID()), 
    						new XAttribute("eLb", mElement.Label()), 
    						new XAttribute("eVl", "##"), 
    						new XAttribute("pId", mElement.GtID()), 
    						new XAttribute("pLb", mElement.Label()), 
    						new XAttribute("pos", "-1")) 
    				},
    			Actions: new XElement[0]));
    
    			Assert.AreEqual(expander.FullDelta.Matches.Count(), existingProperties + 1);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID()).Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == expectedLabel).Attribute("mLb").Value == expectedLabel);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == HashTokenLabel).Attribute("mLb").Value == HashTokenLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == HashTokenLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == PragmaKeywordLabel).Attribute("mLb").Value == PragmaKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == PragmaKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == ChecksumKeywordLabel).Attribute("mLb").Value == ChecksumKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == ChecksumKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == FileLabel).Attribute("mLb").Value == FileLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == FileLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == GuidLabel).Attribute("mLb").Value == GuidLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == GuidLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == BytesLabel).Attribute("mLb").Value == BytesLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == BytesLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == EndOfDirectiveTokenLabel).Attribute("mLb").Value == EndOfDirectiveTokenLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == EndOfDirectiveTokenLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.AreEqual<int>(expander.FullDelta.Actions.Count(), 0);
    		}
         }
    }
}
