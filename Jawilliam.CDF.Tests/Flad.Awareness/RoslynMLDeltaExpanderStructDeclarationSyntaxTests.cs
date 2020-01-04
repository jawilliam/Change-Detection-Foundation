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
         /// <summary>
         /// Provides the element revision pair(s) to test in <see cref="StructDeclarationServiceProvider_RoslynMLDeltaExpander_OK"/>.
         /// </summary>
         /// <param name="nodeRevisionPairs"> the element revision pair(s) to test</param>
    	 partial void StructDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref IEnumerable<(StructDeclarationSyntax, StructDeclarationSyntax)> nodeRevisionPairs);
    
    	 /// <summary>
         /// Tests expansion logic for <see cref="StructDeclarationSyntax"/>.
         /// </summary>
    	 [TestMethod]
         public void StructDeclarationServiceProvider_RoslynMLDeltaExpander_OK()
         {
    		var converter = new CDF.CSharp.RoslynML.RoslynML();
    		var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
    		int id = 0; 
    
    	    IEnumerable<(StructDeclarationSyntax, StructDeclarationSyntax)> nodeRevisionPairs = null;
    	    string oExpectedLabel = null, mExpectedLabel = null;
    	    StructDeclarationServiceProvider_RoslynMLDeltaExpander_DataToTest(ref nodeRevisionPairs);
    		foreach(((StructDeclarationSyntax Original, StructDeclarationSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
    			.SelectMany(n => new List<((StructDeclarationSyntax, StructDeclarationSyntax), Action<RoslynML, XElement>)>
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
    			
    			var totalProperties = 5;
    			var matchedProperties = totalProperties;
    			var unmatchedOriginalProperties = 0;
    			var unmatchedModifiedProperties = 0;
    			matchedProperties = oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken") && 
    			                    mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken")
    				? matchedProperties 
    				: (matchedProperties - 1);
    			if(!oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken") && 
    			    mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
    				unmatchedModifiedProperties++; 
    			if(oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken") && 
    			   !mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
    				unmatchedOriginalProperties++; 
    
    			var relevantDescendants = 0;
    
    			Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + relevantDescendants);
    			Assert.AreEqual(expander.FullDelta.Actions.Count(), unmatchedOriginalProperties + unmatchedModifiedProperties);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
    				.Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
    				.Attribute("mLb").Value == mExpectedLabel);
    
    			var oKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Keyword.Kind());
    			var mKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Keyword.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oKeywordLabel)
    				.Attribute("mLb").Value == mKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oKeywordLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mKeywordLabel).GtID());
    
    			var oIdentifierLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.Identifier.Kind());
    			var mIdentifierLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.Identifier.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oIdentifierLabel)
    				.Attribute("mLb").Value == mIdentifierLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oIdentifierLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mIdentifierLabel).GtID());
    
    			var oOpenBraceTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.OpenBraceToken.Kind());
    			var mOpenBraceTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.OpenBraceToken.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oOpenBraceTokenLabel)
    				.Attribute("mLb").Value == mOpenBraceTokenLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oOpenBraceTokenLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mOpenBraceTokenLabel).GtID());
    
    			var oCloseBraceTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.CloseBraceToken.Kind());
    			var mCloseBraceTokenLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.CloseBraceToken.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oCloseBraceTokenLabel)
    				.Attribute("mLb").Value == mCloseBraceTokenLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oCloseBraceTokenLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mCloseBraceTokenLabel).GtID());
    
    			var oSemicolonTokenLabel = nodeRevisionPair.Original.SemicolonToken == null || nodeRevisionPair.Original.SemicolonToken.Kind() == SyntaxKind.None
    				? null 
    				: Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.SemicolonToken.Kind());
    			var mSemicolonTokenLabel = nodeRevisionPair.Modified.SemicolonToken == null || nodeRevisionPair.Modified.SemicolonToken.Kind() == SyntaxKind.None
    				? null 
    				: Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.SemicolonToken.Kind());
    			if(oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken") &&
    			   mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oSemicolonTokenLabel)
    					.Attribute("mLb").Value == mSemicolonTokenLabel);
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    					.Attribute("mId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mSemicolonTokenLabel).GtID());
    			} 
    			else if(oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken") &&
    			        !mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    				.Attribute("eLb").Value == oSemicolonTokenLabel);
    			}
    			else if(!oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken") &&
    			        mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mSemicolonTokenLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mSemicolonTokenLabel).GtID())
    					.Attribute("pId").Value == oFullElement.GtID());
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
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedModifiedProperties + relevantDescendants);
    
                Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == mElement.GtID())
    				.Attribute("pId").Value == mElement.GtID());
    	        Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mExpectedLabel)
    				.Attribute("pLb").Value == mExpectedLabel);
    
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mKeywordLabel)
    					.Attribute("pLb").Value == mExpectedLabel);
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mKeywordLabel).GtID())
    				.Attribute("pId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mIdentifierLabel)
    					.Attribute("pLb").Value == mExpectedLabel);
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mIdentifierLabel).GtID())
    				.Attribute("pId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mOpenBraceTokenLabel)
    					.Attribute("pLb").Value == mExpectedLabel);
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mOpenBraceTokenLabel).GtID())
    				.Attribute("pId").Value == mFullElement.GtID());
    
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mCloseBraceTokenLabel)
    					.Attribute("pLb").Value == mExpectedLabel);
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mCloseBraceTokenLabel).GtID())
    				.Attribute("pId").Value == mFullElement.GtID());
    
    			if(mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mSemicolonTokenLabel)
    					.Attribute("pLb").Value == mExpectedLabel);
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
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + 1 + unmatchedOriginalProperties + relevantDescendants);
    
                Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == oElement.GtID())
    				.Attribute("eLb").Value == oElement.Label());
    
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oKeywordLabel).GtID())
    				.Attribute("eLb").Value == oKeywordLabel);
    
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oIdentifierLabel).GtID())
    				.Attribute("eLb").Value == oIdentifierLabel);
    
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oOpenBraceTokenLabel).GtID())
    				.Attribute("eLb").Value == oOpenBraceTokenLabel);
    
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oCloseBraceTokenLabel).GtID())
    				.Attribute("eLb").Value == oCloseBraceTokenLabel);
    
    			if(oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
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
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mKeywordLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mKeywordLabel).Value = "v0";
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mIdentifierLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mIdentifierLabel).Value = "v1";
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mOpenBraceTokenLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mOpenBraceTokenLabel).Value = "v2";
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mCloseBraceTokenLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mCloseBraceTokenLabel).Value = "v3";
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mSemicolonTokenLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mSemicolonTokenLabel).Value = "v4";
    
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
    			
                Assert.AreEqual(expander.FullDelta.Matches.Count(), matchedProperties + 1 + relevantDescendants);
                Assert.AreEqual(expander.FullDelta.Actions.Count(), matchedProperties + unmatchedOriginalProperties + unmatchedModifiedProperties);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
    				.Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
    				.Attribute("mLb").Value == mExpectedLabel);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oKeywordLabel)
    				.Attribute("mLb").Value == mKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oKeywordLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mKeywordLabel).GtID());
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oKeywordLabel)
    					.Attribute("val").Value == "v0");
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oKeywordLabel).GtID())
    				.Attribute("val").Value == "v0");
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oIdentifierLabel)
    				.Attribute("mLb").Value == mIdentifierLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oIdentifierLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mIdentifierLabel).GtID());
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oIdentifierLabel)
    					.Attribute("val").Value == "v1");
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oIdentifierLabel).GtID())
    				.Attribute("val").Value == "v1");
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oOpenBraceTokenLabel)
    				.Attribute("mLb").Value == mOpenBraceTokenLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oOpenBraceTokenLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mOpenBraceTokenLabel).GtID());
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oOpenBraceTokenLabel)
    					.Attribute("val").Value == "v2");
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oOpenBraceTokenLabel).GtID())
    				.Attribute("val").Value == "v2");
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oCloseBraceTokenLabel)
    				.Attribute("mLb").Value == mCloseBraceTokenLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oCloseBraceTokenLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mCloseBraceTokenLabel).GtID());
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oCloseBraceTokenLabel)
    					.Attribute("val").Value == "v3");
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oCloseBraceTokenLabel).GtID())
    				.Attribute("val").Value == "v3");
    
    			if(oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken") &&
    			   mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oSemicolonTokenLabel)
    					.Attribute("mLb").Value == mSemicolonTokenLabel);
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    					.Attribute("mId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mSemicolonTokenLabel).GtID());
    
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oSemicolonTokenLabel)
    					.Attribute("val").Value == "v4");
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    						oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    					.Attribute("val").Value == "v4");
    			} 
    			else if(oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken") &&
    			        !mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oSemicolonTokenLabel).GtID())
    				.Attribute("eLb").Value == oSemicolonTokenLabel);
    			}
    			else if(!oFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken") &&
    			        mFullElement.Elements().Any(e => e.Attribute("part").Value == "SemicolonToken"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mSemicolonTokenLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mSemicolonTokenLabel).GtID())
    					.Attribute("pId").Value == oFullElement.GtID());
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
