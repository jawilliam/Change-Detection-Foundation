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
    	 partial void XmlElementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<XmlElementSyntax> nodes);
    
    	 [TestMethod]
         public void XmlElementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_OK()
         {
    		var converter = new CDF.CSharp.RoslynML.RoslynML();
    		var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
    		int id = 0; 
    
    	    IEnumerable<XmlElementSyntax> nodes = null;
    	    string expectedLabel = null;
    	    XmlElementServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref nodes);
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
    			
    			var existingProperties = 2;
    
    			Assert.AreEqual(expander.FullDelta.Matches.Count(), existingProperties + 1);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID()).Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == expectedLabel).Attribute("mLb").Value == expectedLabel);
    
    			var StartTagLabel = Enum.GetName(typeof(SyntaxKind), node.StartTag.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == StartTagLabel).Attribute("mLb").Value == StartTagLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == StartTagLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			var EndTagLabel = Enum.GetName(typeof(SyntaxKind), node.EndTag.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == EndTagLabel).Attribute("mLb").Value == EndTagLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == EndTagLabel).GtID())
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
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == StartTagLabel).Attribute("mLb").Value == StartTagLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == StartTagLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == EndTagLabel).Attribute("mLb").Value == EndTagLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Attribute("oLb").Value == EndTagLabel).GtID())
    				.Attribute("mId").Value == mFullElement.GtID());
    
    			Assert.AreEqual<int>(expander.FullDelta.Actions.Count(), 0);
    		}
         }
    }
}
