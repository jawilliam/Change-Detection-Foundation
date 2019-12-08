﻿namespace Jawilliam.CDF.Tests.Flad.Awareness
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
    	 partial void IndexerDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(IndexerDeclarationSyntax, IndexerDeclarationSyntax)> nodeRevisionPairs);
    
    	 [TestMethod]
         public void IndexerDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_OK()
         {
    		var converter = new CDF.CSharp.RoslynML.RoslynML();
    		var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
    		int id = 0; 
    
    	    IEnumerable<(IndexerDeclarationSyntax, IndexerDeclarationSyntax)> nodeRevisionPairs = null;
    	    string oExpectedLabel = null, mExpectedLabel = null;
    	    IndexerDeclarationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref nodeRevisionPairs);
    		foreach(((IndexerDeclarationSyntax Original, IndexerDeclarationSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
    			.SelectMany(n => new List<((IndexerDeclarationSyntax, IndexerDeclarationSyntax), Action<RoslynML, XElement>)>
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
    			
    			var totalProperties = 2;
    			var existingProperties = totalProperties;
    			existingProperties = (oFullElement.Elements().Any(e => e.Label() == "SemicolonToken") &&
    			                      mFullElement.Elements().Any(e => e.Label() == "SemicolonToken"))
    				? existingProperties 
    				: (existingProperties - 1);
    
    			Assert.AreEqual(expander.FullDelta.Matches.Count(), existingProperties + 1);
    			Assert.AreEqual(expander.FullDelta.Actions.Count(), totalProperties - existingProperties);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
    				.Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
    				.Attribute("mLb").Value == mExpectedLabel);
    
    			var oThisKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.ThisKeyword.Kind());
    			var mThisKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.ThisKeyword.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oThisKeywordLabel)
    				.Attribute("mLb").Value == mThisKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oThisKeywordLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mThisKeywordLabel).GtID());
    
    			var oSemicolonTokenLabel = nodeRevisionPair.Original.SemicolonToken == null || nodeRevisionPair.Original.SemicolonToken.Kind() == SyntaxKind.None
    				? null 
    				: Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.SemicolonToken.Kind());
    			var mSemicolonTokenLabel = nodeRevisionPair.Modified.SemicolonToken == null || nodeRevisionPair.Modified.SemicolonToken.Kind() == SyntaxKind.None
    				? null 
    				: Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.SemicolonToken.Kind());
    			if(oFullElement.Elements().Any(e => e.Label() == "SemicolonToken") &&
    			   mFullElement.Elements().Any(e => e.Label() == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oSemicolonTokenLabel)
    					.Attribute("mLb").Value == mSemicolonTokenLabel);
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    					.Attribute("mId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mSemicolonTokenLabel).GtID());
    			} 
    			else if(!oFullElement.Elements().Any(e => e.Label() == "SemicolonToken") &&
    			         mFullElement.Elements().Any(e => e.Label() == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    				.Attribute("eLb").Value == oSemicolonTokenLabel);
    			}
    			else
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mSemicolonTokenLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mSemicolonTokenLabel).GtID())
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
    
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mThisKeywordLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mThisKeywordLabel).GtID())
    				.Attribute("pId").Value == mFullElement.GtID());
    
    			if(oFullElement.Elements().Any(e => e.Label() == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mSemicolonTokenLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mSemicolonTokenLabel).GtID())
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
    
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oThisKeywordLabel).GtID())
    				.Attribute("eLb").Value == oThisKeywordLabel);
    
    			if(oFullElement.Elements().Any(e => e.Label() == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    						oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    					.Attribute("eLb").Value == oSemicolonTokenLabel);
    			}
    
    			// Update
    			var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
    			converter.SetGumTreefiedIDs(mFullElement1, ref mId);
    			converter.SetRoslynMLIDs(mFullElement1, ref mId);
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mThisKeywordLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mThisKeywordLabel).Value = "v0";
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mSemicolonTokenLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mSemicolonTokenLabel).Value = "v1";
    
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
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oThisKeywordLabel)
    				.Attribute("mLb").Value == mThisKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oThisKeywordLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mThisKeywordLabel).GtID());
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oThisKeywordLabel)
    					.Attribute("val").Value == "v0");
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oThisKeywordLabel).GtID())
    				.Attribute("val").Value == "v0");
    
    			if(oFullElement.Elements().Any(e => e.Label() == "SemicolonToken") &&
    			   mFullElement.Elements().Any(e => e.Label() == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oSemicolonTokenLabel)
    					.Attribute("mLb").Value == mSemicolonTokenLabel);
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    					.Attribute("mId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mSemicolonTokenLabel).GtID());
    
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oSemicolonTokenLabel)
    					.Attribute("val").Value == "v1");
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    						oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    					.Attribute("val").Value == "v1");
    			} 
    			else if(!oFullElement.Elements().Any(e => e.Label() == "SemicolonToken") &&
    			         mFullElement.Elements().Any(e => e.Label() == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    				.Attribute("eLb").Value == oSemicolonTokenLabel);
    			}
    			else
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mSemicolonTokenLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mSemicolonTokenLabel).GtID())
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
