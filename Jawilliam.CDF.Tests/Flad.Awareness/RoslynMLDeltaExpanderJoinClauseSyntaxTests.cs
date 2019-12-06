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
    	 partial void JoinClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<JoinClauseSyntax> nodes);
    
    	 [TestMethod]
         public void JoinClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_OK()
         {
    		var converter = new CDF.CSharp.RoslynML.RoslynML();
    		var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
    		int id = 0; 
    
    	    IEnumerable<JoinClauseSyntax> nodes = null;
    	    string expectedLabel = null;
    	    JoinClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref nodes);
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
    			
    			var existingProperties = 5;
    
    			Assert.AreEqual(expander.FullDelta.Matches.Count(), existingProperties + 1);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID()).Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == expectedLabel).Attribute("mLb").Value == expectedLabel);
    
    			var JoinKeywordLabel = Enum.GetName(typeof(SyntaxKind), node.JoinKeyword.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == JoinKeywordLabel).Attribute("mLb").Value == JoinKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == JoinKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var IdentifierLabel = Enum.GetName(typeof(SyntaxKind), node.Identifier.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == IdentifierLabel).Attribute("mLb").Value == IdentifierLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == IdentifierLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var InKeywordLabel = Enum.GetName(typeof(SyntaxKind), node.InKeyword.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == InKeywordLabel).Attribute("mLb").Value == InKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == InKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var OnKeywordLabel = Enum.GetName(typeof(SyntaxKind), node.OnKeyword.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == OnKeywordLabel).Attribute("mLb").Value == OnKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == OnKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var EqualsKeywordLabel = Enum.GetName(typeof(SyntaxKind), node.EqualsKeyword.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == EqualsKeywordLabel).Attribute("mLb").Value == EqualsKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == EqualsKeywordLabel).GtID())
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
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == JoinKeywordLabel).Attribute("mLb").Value == JoinKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == JoinKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == IdentifierLabel).Attribute("mLb").Value == IdentifierLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == IdentifierLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == InKeywordLabel).Attribute("mLb").Value == InKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == InKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == OnKeywordLabel).Attribute("mLb").Value == OnKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == OnKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == EqualsKeywordLabel).Attribute("mLb").Value == EqualsKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == EqualsKeywordLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.AreEqual<int>(expander.FullDelta.Actions.Count(), 0);
    		}
         }
    }
}
