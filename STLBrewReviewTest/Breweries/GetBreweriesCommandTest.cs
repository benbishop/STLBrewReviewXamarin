﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using STLBrewReview.Mobile.Breweries.List;
using FakeItEasy;
using Should;
using MonkeyArms;
using STLBrewReview.Mobile.Global;
using STLBrewReview.Mobile.Breweries;

namespace STLBrewReviewTest
{
	[TestFixture ()]
	public class GetBreweriesCommandTest
	{
		GetBreweriesCommand CommandUT;

		IGetBreweriesWebService FakeWebService;

		BreweriesListViewModel FakeVM;

		[Test ()]
		public void Verify_WebService_Executes ()
		{

			A.CallTo (() => FakeWebService.Execute ()).MustHaveHappened ();
		}

		[Test]
		public void Verify_Command_Sets_Breweries_On_VM_When_Breweries_Received ()
		{

			FakeVM.Breweries.Count.ShouldEqual (0);
			FakeWebService.BreweriesReceived += Raise.With (new BreweriesReceivedEventArgs (new List<Brewery> (){ new Brewery () }) as EventArgs).Now;
			FakeVM.Breweries.Count.ShouldEqual (1);
		}

		[Test]
		public void Verify_Command_Sets_Ready_True_On_VM_When_Breweries_Received ()
		{

			FakeVM.Ready.ShouldBeFalse ();
			FakeWebService.BreweriesReceived += Raise.With (new BreweriesReceivedEventArgs (new List<Brewery> (){ new Brewery () }) as EventArgs).Now;
			FakeVM.Ready.ShouldBeTrue ();
		}

		[SetUp]
		public void InitCommandUT ()
		{
			CommandUT = new GetBreweriesCommand ();
			FakeWebService = A.Fake<IGetBreweriesWebService> ();
			CommandUT.WebService = FakeWebService;

			FakeVM = A.Fake<BreweriesListViewModel> ();
			CommandUT.Execute (new ViewModelInvokerArgs (FakeVM));

		}
	}
}

