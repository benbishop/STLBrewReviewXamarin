﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using STLBrewReview.Mobile.Breweries;
using FakeItEasy;
using Should;

namespace STLBrewReviewTest
{
	[TestFixture ()]
	public class GetBreweriesCommandTest
	{
		GetBreweriesCommand CommandUT;

		IGetBreweriesWebService FakeWebService;

		BreweriesViewModel FakeVM;

		[Test ()]
		public void Verify_WebService_Executes ()
		{
			CommandUT.Execute (null);
			A.CallTo (() => FakeWebService.Execute ()).MustHaveHappened ();
		}

		[Test]
		public void Verify_Command_Sets_Breweries_On_VM_When_Breweries_Received ()
		{
			CommandUT.Execute (null);
			FakeVM.Breweries.Count.ShouldEqual (0);
			FakeWebService.BreweriesReceived += Raise.With (new BreweriesReceivedEventArgs (new List<Brewery> (){ new Brewery () }) as EventArgs).Now;
			FakeVM.Breweries.Count.ShouldEqual (1);
		}

		[SetUp]
		public void InitCommandUT ()
		{
			CommandUT = new GetBreweriesCommand ();
			FakeWebService = A.Fake<IGetBreweriesWebService> ();
			CommandUT.WebService = FakeWebService;

			FakeVM = A.Fake<BreweriesViewModel> ();
			CommandUT.VM = FakeVM;
		}
	}
}

