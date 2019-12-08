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
    	 partial void ArgumentServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ArgumentSyntax, ArgumentSyntax)> nodeRevisionPairs);
    
    	 [TestMethod]
         public void ArgumentServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_OK()
         {
    		var converter = new CDF.CSharp.RoslynML.RoslynML();
    		var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
    		int id = 0; 
    
    	    IEnumerable<(ArgumentSyntax, ArgumentSyntax)> nodeRevisionPairs = null;
    	    string oExpectedLabel = null, mExpectedLabel = null;
    	    ArgumentServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref nodeRevisionPairs);
    		foreach(((ArgumentSyntax Original, ArgumentSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
    			.SelectMany(n => new List<((ArgumentSyntax, ArgumentSyntax), Action<RoslynML, XElement>)>
    				{ (n, (r, n1) => { }), (n, (r, n1) => r.Defoliate(n1)) }))
    		{
    			id = 0;
    			oExpectedLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Kind());
    			mExpectedLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Kind());
    
    			var oElement = converter.Visit(nodeRevisionPair.Original);
    			converter.SetGumTreefiedIDs(oElement, ref id);
    			converter.SetRoslynMLIDs(oElement, ref id);
    			converter.Prune(oElement, selector.PruneSelector); 
    			defoliate(converter, oElement);
    
    			var mId = id;
    
    			var mElement = converter.Visit(nodeRevisionPair.Modified);
    			converter.SetGumTreefiedIDs(mElement, ref id);
    			converter.SetRoslynMLIDs(mElement, ref id);
    			converter.Prune(mElement, selector.PruneSelector); 
    			defoliate(converter, mElement);
    
    			id = 0;
    			var oFullElement = converter.Visit(nodeRevisionPair.Original);
    			converter.SetGumTreefiedIDs(oFullElement, ref id);
    			converter.SetRoslynMLIDs(oFullElement, ref id);
    
    			var mFullElement = converter.Visit(nodeRevisionPair.Modified);
    			converter.SetGumTreefiedIDs(mFullElement, ref id);
    			converter.SetRoslynMLIDs(mFullElement, ref id);
    
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
    			
    			var totalProperties = 1;
    			var existingProperties = totalProperties;
    			existingProperties = (oFullElement.Elements().Any(e => e.Label() == "RefKindKeyword") &&
    			                      mFullElement.Elements().Any(e => e.Label() == "RefKindKeyword"))
    				? existingProperties 
    				: (existingProperties - 1);
    
    			Assert.AreEqual(expander.FullDelta.Matches.Count(), existingProperties + 1);
    			Assert.AreEqual(expander.FullDelta.Actions.Count(), totalProperties - existingProperties);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
    				.Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
    				.Attribute("mLb").Value == mExpectedLabel);
    
    			var oRefKindKeywordLabel = nodeRevisionPair.Original.RefKindKeyword == null || nodeRevisionPair.Original.RefKindKeyword.Kind() == SyntaxKind.None
    				? null 
    				: Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.RefKindKeyword.Kind());
    			var mRefKindKeywordLabel = nodeRevisionPair.Modified.RefKindKeyword == null || nodeRevisionPair.Modified.RefKindKeyword.Kind() == SyntaxKind.None
    				? null 
    				: Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.RefKindKeyword.Kind());
    			if(oFullElement.Elements().Any(e => e.Label() == "RefKindKeyword") &&
    			   mFullElement.Elements().Any(e => e.Label() == "RefKindKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oRefKindKeywordLabel)
    					.Attribute("mLb").Value == mRefKindKeywordLabel);
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oRefKindKeywordLabel).GtID())
    					.Attribute("mId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mRefKindKeywordLabel).GtID());
    			} 
    			else if(!oFullElement.Elements().Any(e => e.Label() == "RefKindKeyword") &&
    			         mFullElement.Elements().Any(e => e.Label() == "RefKindKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oRefKindKeywordLabel).GtID())
    				.Attribute("eLb").Value == oRefKindKeywordLabel);
    			}
    			else
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mRefKindKeywordLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mRefKindKeywordLabel).GtID())
    					.Attribute("pId").Value == mFullElement.GtID());
    			}
    
    			// Insert
    			expander.Expand(
    				new RevisionPair<XElement> { Original = oElement, Modified = mElement },
    				new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement }, 
    				(Matches: new XElement[0],
    				 Actions: new XElement[] 
    				 { 
    				 	new XElement("Insert", 
    				 		new XAttribute("eId", mElement.GtID()), 
    				 		new XAttribute("eLb", mElement.Label()), 
    				 		new XAttribute("eVl", "##"), 
    				 		new XAttribute("pId", mElement.GtID()), 
    				 		new XAttribute("pLb", mElement.Label()), 
    				 		new XAttribute("pos", "-1")) 
    				 }));
    			
                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), existingProperties + 1);
    
                Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == mElement.GtID())
    				.Attribute("pId").Value == mElement.GtID());
    	        Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mExpectedLabel)
    				.Attribute("pLb").Value == oExpectedLabel);
    
    			if(oFullElement.Elements().Any(e => e.Label() == "RefKindKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mRefKindKeywordLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mRefKindKeywordLabel).GtID())
    					.Attribute("pId").Value == mFullElement.GtID());
    			}
    
    			// Delete
    			expander.Expand(
    				new RevisionPair<XElement> { Original = oElement, Modified = mElement },
    				new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement }, 
    				(Matches: new XElement[0],
    				 Actions: new XElement[] 
    				 { 
    				 	new XElement("Delete", 
    				 		new XAttribute("eId", oElement.GtID()), 
    				 		new XAttribute("eLb", oElement.Label()), 
    				 		new XAttribute("eVl", "##"))
    				 }));
    			
                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), existingProperties + 1);
    
                Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == oElement.GtID())
    				.Attribute("eLb").Value == oElement.Label());
    
    			if(oFullElement.Elements().Any(e => e.Label() == "RefKindKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    						oFullElement.Elements().Single(e => e.Label() == oRefKindKeywordLabel).GtID())
    					.Attribute("eLb").Value == oRefKindKeywordLabel);
    			}
    
    			// Update
    			var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
    			converter.SetGumTreefiedIDs(mFullElement1, ref mId);
    			converter.SetRoslynMLIDs(mFullElement1, ref mId);
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mRefKindKeywordLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mRefKindKeywordLabel).Value = "v0";
    
    			expander.Expand(
    				new RevisionPair<XElement> { Original = oElement, Modified = mElement },
    				new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement1 }, 
    				(Matches: new XElement[] 
    				{ 
    					new XElement("Match", 
    						new XAttribute("oId", oElement.GtID()),
    						new XAttribute("oLb", oElement.Label()),
    						new XAttribute("mId", mElement.GtID()), 
    						new XAttribute("mLb", mElement.Label())) 
    				},
    			    Actions: new XElement[0]));
    			
                Assert.AreEqual(expander.FullDelta.Matches.Count(), existingProperties + 1);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), totalProperties);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
    				.Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
    				.Attribute("mLb").Value == mExpectedLabel);
    
    			if(oFullElement.Elements().Any(e => e.Label() == "RefKindKeyword") &&
    			   mFullElement.Elements().Any(e => e.Label() == "RefKindKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oRefKindKeywordLabel)
    					.Attribute("mLb").Value == mRefKindKeywordLabel);
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oRefKindKeywordLabel).GtID())
    					.Attribute("mId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mRefKindKeywordLabel).GtID());
    
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oRefKindKeywordLabel)
    					.Attribute("val").Value == "v0");
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    						oFullElement.Elements().Single(e => e.Label() == oRefKindKeywordLabel).GtID())
    					.Attribute("val").Value == "v0");
    			} 
    			else if(!oFullElement.Elements().Any(e => e.Label() == "RefKindKeyword") &&
    			         mFullElement.Elements().Any(e => e.Label() == "RefKindKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oRefKindKeywordLabel).GtID())
    				.Attribute("eLb").Value == oRefKindKeywordLabel);
    			}
    			else
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mRefKindKeywordLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mRefKindKeywordLabel).GtID())
    					.Attribute("pId").Value == mFullElement.GtID());
    			}
    
    			// Update
    			expander.Expand(
    				new RevisionPair<XElement> { Original = oElement, Modified = mElement },
    				new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement }, 
    				(Matches: new XElement[0],
    				Actions: new XElement[] 
    				{ 
    					new XElement("Update",
    						new XAttribute("eId", oFullElement.GtID()),
    						new XAttribute("eLb", oFullElement.Attribute("kind")?.Value ?? oFullElement.Name.LocalName),
    						new XAttribute("eVl", mFullElement.GtID()),
    						new XAttribute("val", "t#v"))
    				}));			
                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), 1);
    
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oExpectedLabel)
    					.Attribute("val").Value == "t#v");
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == oFullElement.GtID())
    				.Attribute("val").Value == "t#v");	
    
    			// Move
    			expander.Expand(
    				new RevisionPair<XElement> { Original = oElement, Modified = mElement },
    				new RevisionPair<XElement> { Original = oFullElement, Modified = mFullElement }, 
    				(Matches: new XElement[0],
    				 Actions: new XElement[] 
    				 { 
    				 	new XElement("Move", 
    				 		new XAttribute("eId", oElement.GtID()),
    				 		new XAttribute("eLb", oElement.Label()),
    				 		new XAttribute("pId", mFullElement.GtID()),
    				 		new XAttribute("pLb", mFullElement.Label()),
    				 		new XAttribute("pos", "-1")) 
    				 }));			
                Assert.AreEqual(expander.FullDelta.Matches.Count(), 0);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), 1);
    
                Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Move" && a.Attribute("eId").Value == oElement.GtID())
    				.Attribute("pId").Value == mFullElement.GtID());
    	        Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Move" && a.Attribute("eLb").Value == oExpectedLabel)
    				.Attribute("pLb").Value == mExpectedLabel);
    		}
         }
    }
}
