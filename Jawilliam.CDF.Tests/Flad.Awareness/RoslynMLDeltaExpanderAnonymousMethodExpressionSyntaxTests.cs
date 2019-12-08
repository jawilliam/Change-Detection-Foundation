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
    	 partial void AnonymousMethodExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)> nodeRevisionPairs);
    
    	 [TestMethod]
         public void AnonymousMethodExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_OK()
         {
    		var converter = new CDF.CSharp.RoslynML.RoslynML();
    		var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
    		int id = 0; 
    
    	    IEnumerable<(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)> nodeRevisionPairs = null;
    	    string oExpectedLabel = null, mExpectedLabel = null;
    	    AnonymousMethodExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref nodeRevisionPairs);
    		foreach(((AnonymousMethodExpressionSyntax Original, AnonymousMethodExpressionSyntax Modified) nodeRevisionPair, Action<RoslynML, XElement> defoliate) in nodeRevisionPairs
    			.SelectMany(n => new List<((AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax), Action<RoslynML, XElement>)>
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
    			existingProperties = (oFullElement.Elements().Any(e => e.Label() == "AsyncKeyword") &&
    			                      mFullElement.Elements().Any(e => e.Label() == "AsyncKeyword"))
    				? existingProperties 
    				: (existingProperties - 1);
    
    			Assert.AreEqual(expander.FullDelta.Matches.Count(), existingProperties + 1);
    			Assert.AreEqual(expander.FullDelta.Actions.Count(), totalProperties - existingProperties);
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == oElement.GtID())
    				.Attribute("mId").Value == mElement.GtID());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oExpectedLabel)
    				.Attribute("mLb").Value == mExpectedLabel);
    
    			var oAsyncKeywordLabel = nodeRevisionPair.Original.AsyncKeyword == null || nodeRevisionPair.Original.AsyncKeyword.Kind() == SyntaxKind.None
    				? null 
    				: Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.AsyncKeyword.Kind());
    			var mAsyncKeywordLabel = nodeRevisionPair.Modified.AsyncKeyword == null || nodeRevisionPair.Modified.AsyncKeyword.Kind() == SyntaxKind.None
    				? null 
    				: Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.AsyncKeyword.Kind());
    			if(oFullElement.Elements().Any(e => e.Label() == "AsyncKeyword") &&
    			   mFullElement.Elements().Any(e => e.Label() == "AsyncKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oAsyncKeywordLabel)
    					.Attribute("mLb").Value == mAsyncKeywordLabel);
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oAsyncKeywordLabel).GtID())
    					.Attribute("mId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mAsyncKeywordLabel).GtID());
    			} 
    			else if(!oFullElement.Elements().Any(e => e.Label() == "AsyncKeyword") &&
    			         mFullElement.Elements().Any(e => e.Label() == "AsyncKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oAsyncKeywordLabel).GtID())
    				.Attribute("eLb").Value == oAsyncKeywordLabel);
    			}
    			else
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mAsyncKeywordLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mAsyncKeywordLabel).GtID())
    					.Attribute("pId").Value == mFullElement.GtID());
    			}
    
    			var oDelegateKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Original.DelegateKeyword.Kind());
    			var mDelegateKeywordLabel = Enum.GetName(typeof(SyntaxKind), nodeRevisionPair.Modified.DelegateKeyword.Kind());
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oDelegateKeywordLabel)
    				.Attribute("mLb").Value == mDelegateKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oDelegateKeywordLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mDelegateKeywordLabel).GtID());
    
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
    
    			if(oFullElement.Elements().Any(e => e.Label() == "AsyncKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mAsyncKeywordLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mAsyncKeywordLabel).GtID())
    					.Attribute("pId").Value == mFullElement.GtID());
    			}
    
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mDelegateKeywordLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mDelegateKeywordLabel).GtID())
    				.Attribute("pId").Value == mFullElement.GtID());
    
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
    
    			if(oFullElement.Elements().Any(e => e.Label() == "AsyncKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    						oFullElement.Elements().Single(e => e.Label() == oAsyncKeywordLabel).GtID())
    					.Attribute("eLb").Value == oAsyncKeywordLabel);
    			}
    
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oDelegateKeywordLabel).GtID())
    				.Attribute("eLb").Value == oDelegateKeywordLabel);
    
    			// Update
    			var mFullElement1 = converter.Visit(nodeRevisionPair.Modified);
    			converter.SetGumTreefiedIDs(mFullElement1, ref mId);
    			converter.SetRoslynMLIDs(mFullElement1, ref mId);
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mAsyncKeywordLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mAsyncKeywordLabel).Value = "v0";
    			
    			if(mFullElement1.Elements().Any(e => e.Label() == mDelegateKeywordLabel))
    				mFullElement1.Elements().Single(e => e.Label() == mDelegateKeywordLabel).Value = "v1";
    
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
    
    			if(oFullElement.Elements().Any(e => e.Label() == "AsyncKeyword") &&
    			   mFullElement.Elements().Any(e => e.Label() == "AsyncKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oAsyncKeywordLabel)
    					.Attribute("mLb").Value == mAsyncKeywordLabel);
    				Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oAsyncKeywordLabel).GtID())
    					.Attribute("mId").Value == 
    					mFullElement.Elements().Single(e => e.Label() == mAsyncKeywordLabel).GtID());
    
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oAsyncKeywordLabel)
    					.Attribute("val").Value == "v0");
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    						oFullElement.Elements().Single(e => e.Label() == oAsyncKeywordLabel).GtID())
    					.Attribute("val").Value == "v0");
    			} 
    			else if(!oFullElement.Elements().Any(e => e.Label() == "AsyncKeyword") &&
    			         mFullElement.Elements().Any(e => e.Label() == "AsyncKeyword"))
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Delete" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oAsyncKeywordLabel).GtID())
    				.Attribute("eLb").Value == oAsyncKeywordLabel);
    			}
    			else
    			{
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eLb").Value == mAsyncKeywordLabel)
    					.Attribute("pLb").Value == oExpectedLabel);
    				Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Insert" && a.Attribute("eId").Value == 
    						mFullElement.Elements().Single(e => e.Label() == mAsyncKeywordLabel).GtID())
    					.Attribute("pId").Value == mFullElement.GtID());
    			}
    
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oLb").Value == oDelegateKeywordLabel)
    				.Attribute("mLb").Value == mDelegateKeywordLabel);
    			Assert.IsTrue(expander.FullDelta.Matches.Single(m => m.Attribute("oId").Value == 
    				oFullElement.Elements().Single(e => e.Label() == oDelegateKeywordLabel).GtID())
    				.Attribute("mId").Value == 
    				mFullElement.Elements().Single(e => e.Label() == mDelegateKeywordLabel).GtID());
    			Assert.IsTrue(expander.FullDelta.Actions
    					.Single(a => a.Name.LocalName == "Update" && a.Attribute("eLb").Value == oDelegateKeywordLabel)
    					.Attribute("val").Value == "v1");
    			Assert.IsTrue(expander.FullDelta.Actions
    				.Single(a => a.Name.LocalName == "Update" && a.Attribute("eId").Value == 
    					oFullElement.Elements().Single(e => e.Label() == oDelegateKeywordLabel).GtID())
    				.Attribute("val").Value == "v1");
    
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
